using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableCanvas : MonoBehaviour
{
    public CanvasComponent canvasComp;

    private void OnEnable()
    {
        StartCoroutine(PopupPanelDisabled(canvasComp.canvasDeadPanelInicio, 5));

    }

    //Popup panels solo desactivar, le pasamos el panel y el tiempo de activacion
    public static IEnumerator PopupPanelDisabled(GameObject canvasPanel, float t)
    {

        //yield return new WaitForSeconds(t);
        //canvasPanel.SetActive(false);

        yield return new WaitForSeconds(t);
        canvasPanel.GetComponent<CanvasGroup>().DOFade(0, .5f);

    }
}
