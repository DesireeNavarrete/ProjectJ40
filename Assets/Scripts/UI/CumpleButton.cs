using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CumpleButton : MonoBehaviour
{
    public ButtonControl butControl;
    public CanvasComponent canvasComp;

    private void Start()
    {
        butControl = GetComponent<ButtonControl>();
    }

    private void Update()
    {
        if (!UIManager.cumpleAvaible && canvasComp.cumpleBut.interactable == true)
        {
            canvasComp.cumpleBut.gameObject.SetActive(false);
        }
    }

}
