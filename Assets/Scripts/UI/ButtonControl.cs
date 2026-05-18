using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonpressed = false;
    Button but;

    private void Start()
    {
        but = gameObject.GetComponent<Button>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (but.interactable == true)
        {
            buttonpressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (but.interactable == true)
        {
            buttonpressed = false;
        }
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
