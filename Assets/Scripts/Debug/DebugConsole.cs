using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
    public static DebugConsole instance;

    [SerializeField] RectTransform displayRect;
    [SerializeField] Text displayText;

    float initHeight;


    void Awake()
    {
        if (DebugConsole.instance != null)
            DestroyImmediate(gameObject);
        else DebugConsole.instance = this;

        initHeight = displayRect.anchoredPosition.y;

    }
   

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void ChangeDisplayPosition(float newPos)
    {
        displayRect.anchoredPosition = new Vector2(displayRect.anchoredPosition.x, initHeight + newPos);
    }

    public void Log(string newLog)
    {
        displayText.text = newLog + "\n" + displayText.text;
    }


    public void LogWarning(string newLog)
    {
        displayText.text = "<color=orange>"+newLog + "</color>\n" + displayText.text;

    }


    public void LogError(string newLog)
    {
        displayText.text = "<color=red>" + newLog + "</color>\n" + displayText.text;

    }
}
