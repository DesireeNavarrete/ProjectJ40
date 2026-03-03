using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonpressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonpressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonpressed = false;
    }



}
