using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasComponent canvasComp;
    public Stat stat;

    private void Start()
    {
        canvasComp.cocinaCO.SetActive(true);
        canvasComp.labCO.SetActive(false);
        canvasComp.bathCO.SetActive(false);
        canvasComp.dormCO.SetActive(false);
        canvasComp.entradaCO.SetActive(false);
        canvasComp.questPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    #region UIStats



    #endregion
}
