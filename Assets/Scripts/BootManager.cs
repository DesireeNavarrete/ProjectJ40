using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    [SerializeField] private string sceneName = "Main";

    IEnumerator Start()
    {
        // Espera 1 frame (deja que Unity termine de inicializar cosas básicas)
        yield return null;

        // Empieza carga asíncrona
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Opcional: evita que cambie de escena automáticamente al 90%
        asyncLoad.allowSceneActivation = false;

        // Espera a que cargue casi todo
        while (asyncLoad.progress < 0.9f)
        {
            // aquí podrías actualizar una barra de carga si quieres
            yield return null;
        }

        // Pequeña pausa opcional (mejora percepción)
        yield return new WaitForSeconds(0.1f);

        // Activa la escena
        asyncLoad.allowSceneActivation = true;
    }
}
