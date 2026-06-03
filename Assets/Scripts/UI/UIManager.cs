using DG.Tweening;
using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public CanvasComponent canvasComp;
    public Notifications notis;
    public NeedsSystem needs;


    public Stat stat;
    public static bool cumpleAvaible = false;

    public NeedsSystem reactManager;
    public GameObject player;

    private void Start()
    {
        //desactivamos los elementos de la ui que no se necesiten al iniciar
        canvasComp.cocinaCO.SetActive(true);
        canvasComp.labCO.SetActive(false);
        canvasComp.bathCO.SetActive(false);
        canvasComp.dormCO.SetActive(false);
        canvasComp.entradaCO.SetActive(false);
        canvasComp.questPanel.SetActive(false);
        canvasComp.questCompletePanel.SetActive(false);
        canvasComp.growingPanel.SetActive(false);

        //desactivamos las acciones que ahora no tocan
        canvasComp.weldBut.gameObject.SetActive(false);
        canvasComp.quedarBut.gameObject.SetActive(false);
        canvasComp.baloncestoBut.gameObject.SetActive(false);
        canvasComp.bioBut.gameObject.SetActive(false);
        canvasComp.proteinBut.gameObject.SetActive(false);
        canvasComp.coffeBut.gameObject.SetActive(false);
        canvasComp.crossfitBut.gameObject.SetActive(false);
        canvasComp.cumpleBut.gameObject.SetActive(false);
        canvasComp.cumpleBut.onClick.AddListener(() => ChangePhase());

        canvasComp.seguimientoQuests.onClick.AddListener(() => AbrilCerralQuests(canvasComp.questPanel));
        canvasComp.configPanelButton.onClick.AddListener(() => ConfigPanel(canvasComp.configPanel));

        canvasComp.configPanelButton.onClick.AddListener(() => Pausa());
        canvasComp.seguimientoQuests.onClick.AddListener(() => Pausa());
        canvasComp.toiletBut.onClick.AddListener(() => QuitarColaBath());
        canvasComp.showerBut.onClick.AddListener(() => QuitarColaDucha());


        canvasComp.toiletBut.interactable = false;
        canvasComp.toiletBut.onClick.AddListener(() => ToiletButtonReset());
        canvasComp.showerBut.interactable = false;
        canvasComp.showerBut.onClick.AddListener(() => ShowerButtonReset());

        //Activar canvas fade
        canvasComp.canvasPrincipal.GetComponent<CanvasGroup>().DOFade(1, .5f);
        player.SetActive(true);


    }

    void ToiletButtonReset()
    {
        canvasComp.toiletBut.interactable = false;
    }

    void ShowerButtonReset()
    {
        canvasComp.showerBut.interactable = false;
    }

    void QuitarColaBath()
    {
        if (notis.notificationsNeeds.Count > 0)
        {
            for (int i = 0; i < notis.notificationsNeeds.Count; i++)
            {
                if (notis.notificationsNeeds.Contains("caca"))
                {
                    notis.notificationsNeeds.Remove("caca");
                    foreach (Transform child in canvasComp.emocionPanel.transform)
                    {
                        if (child.name == "caca")
                        {
                            //needs.contadorCaca = 0;
                            child.gameObject.SetActive(false);
                            Destroy(child.gameObject, 1);
                        }
                    }
                }
            }
        }
    }

    void QuitarColaDucha()
    {
        if (notis.notificationsNeeds.Count > 0)
        {
            for (int i = 0; i < notis.notificationsNeeds.Count; i++)
            {
                if (notis.notificationsNeeds.Contains("ducha"))
                {
                    notis.notificationsNeeds.Remove("ducha");

                    foreach (Transform child in canvasComp.emocionPanel.transform)
                    {
                        if (child.name == "ducha")
                        {
                            child.gameObject.SetActive(false);
                            Destroy(child.gameObject, 1);
                        }
                    }
                }
            }
        }
    }

    public void Pausa()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
            Time.timeScale = 0;
    }

    public void Cumple()
    {
        cumpleAvaible = true;
        canvasComp.cumpleBut.gameObject.SetActive(true);
        notis.AddNotificationUI("-¡Enhorabuena!\r\nJavi está ahora preparado para crecer\r\n¡Corre ves a la cocina!");
    }

    public void ChangePhase()
    {

        if (canvasComp.questPanelIsntanciar.childCount > 0)
        {
            for (int j = 0; j < canvasComp.questPanelIsntanciar.childCount; j++)
            {
                Destroy(canvasComp.questPanelIsntanciar.GetChild(j).gameObject);
            }
            canvasComp.sliExp.value = 0;
        }

        switch (GrowthController.GrowthFSM.CurrentState)
        {
            case BabyPhase:
                cumpleAvaible = false;
                GrowthController.AdvanceToStage(GrowthStage.Teen);
                QuestManager.level = 1;
                break;
            case TeenPhase:
                cumpleAvaible = false;
                GrowthController.AdvanceToStage(GrowthStage.Adult);
                QuestManager.level = 2;
                break;
        }
    }

    public void AbrilCerralQuests(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
            panel.SetActive(true);

    }

    public void ConfigPanel(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            //volver a activar panelcofig y desactivar opciones
            canvasComp.panelConfig.SetActive(true);
            canvasComp.opciones.SetActive(false);
        }
        else
            panel.SetActive(true);
    }
    void Update()
    {

        //Gestion de UI para el cooldown
        //TODO: poner interacts en el onclick de los bootnes? optimizacion
        #region UIStats
        //cooldown en marcha
        if (ButtonControl.currentCooldown > 0)
        {
            canvasComp.foodBut.interactable = false;
            canvasComp.computerBut.interactable = false;
            //canvasComp.toiletBut.interactable = false;
            //canvasComp.showerBut.interactable = false;
            canvasComp.weldBut.interactable = false;

            canvasComp.coffeBut.interactable = false;
            canvasComp.proteinBut.interactable = false;
            canvasComp.bricolajeBut.interactable = false;
            canvasComp.crossfitBut.interactable = false;
            canvasComp.bioBut.interactable = false;
            canvasComp.baloncestoBut.interactable = false;
            canvasComp.quedarBut.interactable = false;

            canvasComp.cumpleBut.interactable = false;
        }

        if (ButtonControl.currentCooldown <= 0)
        {
            canvasComp.foodBut.interactable = true;
            canvasComp.computerBut.interactable = true;
            //canvasComp.toiletBut.interactable = true;
            //canvasComp.showerBut.interactable = true;
            canvasComp.weldBut.interactable = true;

            canvasComp.coffeBut.interactable = true;
            canvasComp.proteinBut.interactable = true;
            canvasComp.bricolajeBut.interactable = true;
            canvasComp.crossfitBut.interactable = true;
            canvasComp.bioBut.interactable = true;
            canvasComp.baloncestoBut.interactable = true;
            canvasComp.quedarBut.interactable = true;

            canvasComp.cumpleBut.interactable = true;

        }
        #endregion
    }

    //Popup panels, le pasamos el panel y el tiempo de activacion
    public static IEnumerator PopupPanel(GameObject canvasPanel, float t)
    {
        if (canvasPanel.GetComponent<CanvasGroup>() != null)
        {
            canvasPanel.GetComponent<CanvasGroup>().DOFade(1, .5f);
            yield return new WaitForSeconds(t);
            canvasPanel.GetComponent<CanvasGroup>().DOFade(0, .5f);
        }
        else
        {
            canvasPanel.SetActive(true);
            yield return new WaitForSeconds(t);
            canvasPanel.SetActive(false);
        }
    }

    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        ;
    }
}
