using UnityEngine;

public class DevelopmentBuildCanvasActivator : MonoBehaviour
{
    [SerializeField] private GameObject targetCanvas;

    private void Awake()
    {
#if DEVELOPMENT_BUILD && !UNITY_EDITOR
        if (targetCanvas != null)
            targetCanvas.SetActive(true);
#else
        if (targetCanvas != null)
            targetCanvas.SetActive(false);
#endif
    }
}