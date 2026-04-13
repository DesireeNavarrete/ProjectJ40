using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasComponent canvasComp;
    public Notifications notis;
    public Stat stat;
    public static bool cumpleAvaible=false;

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
        canvasComp.seguimientoQuests.onClick.AddListener(() => AbrilCerralQuests());
        //canvasComp.cumpleBut.onClick.AddListener(() => Cumple());
        canvasComp.seguimientoQuests.onClick.AddListener(() => Pausa());

    }

    public void Pausa()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }else
            Time.timeScale = 0;
    }

    public void Cumple()
    {
        cumpleAvaible = true;
        canvasComp.cumpleBut.gameObject.SetActive(true);
        //StartCoroutine(UIManager.PopupPanel(canvasComp.growingPanel, 5));
        notis.AddCommand("-¡Enhorabuena!\r\nJavi está ahora preparado para crecer\r\n¡Corre ves a la cocina!");
    }

    public void ChangePhase()
    {
        switch (GrowthController.GrowthFSM.CurrentState)
        {
            case BabyPhase:
                cumpleAvaible = false;
                GrowthController.AdvanceToStage(GrowthStage.Teen);
                break;
            case TeenPhase:
                cumpleAvaible = false;
                GrowthController.AdvanceToStage(GrowthStage.Adult);
                break;
        }
    }

    public void AbrilCerralQuests()
    {
        if (canvasComp.questPanel.activeSelf)
        {
            canvasComp.questPanel.SetActive(false);
        }
        else
            canvasComp.questPanel.SetActive(true);

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
            canvasComp.toiletBut.interactable = false;
            canvasComp.showerBut.interactable = false;
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
            canvasComp.toiletBut.interactable = true;
            canvasComp.showerBut.interactable = true;
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
        canvasPanel.SetActive(true);
        yield return new WaitForSeconds(t);
        canvasPanel.SetActive(false);
    }
}
