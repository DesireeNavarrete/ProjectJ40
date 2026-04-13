using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonpressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonpressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Cooldown();
        buttonpressed = false;
    }

    public static float currentCooldown = 0f;
    //Cooldown para las acciones para que no se espameen
    public void Cooldown()
    {
        if (currentCooldown <= 0)
        {
            // Usar accion
            currentCooldown = 5;
        }
    }
}
