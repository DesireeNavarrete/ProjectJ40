using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MinijuegoDead : MonoBehaviour
{

    public Text txt;
    public Slider sli;
    public Image sliImg;
    public CanvasComponent canvasComp;

    // Cámara usada para convertir la posición de pantalla a posición del mundo.
    // Si no se asigna desde el Inspector, se usará Camera.main.
    [SerializeField] private Camera cam;

    private void Awake()
    {
        // Si no hemos asignado una cámara manualmente,
        // buscamos la cámara principal de la escena.
        if (cam == null)
            cam = Camera.main;
    }

    private void Update()
    {
        if (sli.value < sli.maxValue)
        {
            sli.value = sli.value - Time.deltaTime * .25f;
        }

        // Comprobamos si hubo un toque o clic en este frame.
        // Si no lo hubo, salimos del Update.
        if (!PressedThisFrame(out Vector2 screenPos))
            return;

        // Convertimos la posición del toque/clic desde coordenadas de pantalla
        // a coordenadas del mundo 2D.
        Vector2 worldPos = cam.ScreenToWorldPoint(screenPos);

        // Buscamos si hay algún Collider2D justo en esa posición del mundo.
        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        // Si hemos tocado un collider y pertenece a este mismo GameObject,
        // entonces consideramos que este sprite fue pulsado.
        if (hit != null && hit.gameObject == gameObject)
        {
            OnSpritePressed();
        }
    }

    private bool PressedThisFrame(out Vector2 screenPos)
    {
        // Primero comprobamos entrada táctil.
        // TouchPhase.Began significa que el dedo acaba de tocar la pantalla.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            screenPos = Input.GetTouch(0).position;
            return true;
        }

        // También comprobamos clic de ratón.
        // En WebGL móvil, algunos navegadores pueden traducir el toque a clic.
        if (Input.GetMouseButtonDown(0))
        {
            screenPos = Input.mousePosition;
            return true;
        }

        // Si no hubo toque ni clic, devolvemos false.
        screenPos = default;
        return false;
    }

    void DisableDeadMode()
    {
        
    }
    private void OnSpritePressed()
    {
        // Aquí pones la acción que quieres ejecutar al tocar/clicar el sprite.
        Debug.Log("Sprite tocado/clicado");
        DebugConsole.instance.Log("Sprite tocado/clicado");
        txt.text = "Sprite tocado/clicado";
        sli.value = sli.value + .1f;
        if (sli.value >= sli.maxValue)//completado
        {
            sli.value = 1;
            canvasComp.canvasGame.GetComponent<CanvasGroup>().DOFade(1, .5f);
            canvasComp.canvasDead.GetComponent<CanvasGroup>().DOFade(0, .5f);
            canvasComp.canvasDead.SetActive(false);

            print("minijuego completado");
            StatsManager.nivelesCriticos = false;
        }
    }
}
