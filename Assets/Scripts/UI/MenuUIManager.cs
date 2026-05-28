using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.InteropServices;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pantallaDeCarga;
    [SerializeField] private Slider barraDeCarga;
    [SerializeField] private TextMeshProUGUI textoPorcentaje; // Cambiar a 'Text' si usas el UI antiguo
    public GameObject exitPanel;
    public void IniciarCarga(int indiceEscena)
    {
        StartCoroutine(CargarAsincronamente(indiceEscena));
    }

    IEnumerator CargarAsincronamente(int indiceEscena)
    {
        // 1. Inicia la operación en segundo plano
        AsyncOperation operacion = SceneManager.LoadSceneAsync(indiceEscena);

        // 2. Activa visualmente el panel de carga
        pantallaDeCarga.SetActive(true);

        // 3. Actualiza la barra mientras no termine de cargar
        while (!operacion.isDone)
        {
            // Unity va de 0 a 0.9 en la carga. Normalizamos el valor de 0 a 1 usando Mathf.Clamp01.
            float progreso = Mathf.Clamp01(operacion.progress / 0.9f);

            // Asigna el valor al slider
            barraDeCarga.value = progreso;

            // Actualiza el texto si está asignado
            if (textoPorcentaje != null)
            {
                textoPorcentaje.text = (progreso * 100f).ToString("F0") + "%";
            }

            yield return null;
        }
    }

    public void Exit()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        exitPanel.SetActive(true); // "Puedes cerrar esta pestaña"
        exitPanel.GetComponent<CanvasGroup>().DOFade(1, .5f);


#else
        Application.Quit();
#endif
    }


    public void Crdits(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
            panel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
