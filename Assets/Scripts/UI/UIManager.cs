using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasComponent canvasComp;
    public Stat stat;

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
    }

    void Update()
    {
        //Gestion de UI para el cooldown
        //TODO: poner interacts en el onclick de los bootnes? optimizacion
        #region UIStats
        if (Stat.currentCooldown > 0)
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
        }

        if (Stat.currentCooldown <= 0)
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
