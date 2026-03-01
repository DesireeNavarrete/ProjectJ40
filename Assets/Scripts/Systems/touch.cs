using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    DebugConsole.instance.Log(Screen.currentResolution.ToString());

        //}

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {

                case TouchPhase.Began:
                    DebugConsole.instance.Log("Began");
                    Vector3 mousePos = touch.position; ;
                    mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                 
                    // Handle the start of the touch (e.g., record initial position).
                    break;

                case TouchPhase.Moved:
                    DebugConsole.instance.Log("Moved");
                    // Handle touch movement (e.g., drag an object, get dorection of drag).
                    break;

                case TouchPhase.Stationary:
                    // Handle a stationary touch (e.g., long-press actions).
                    DebugConsole.instance.Log("Stationary");
                    break;

                case TouchPhase.Ended:
                    DebugConsole.instance.Log("Ended");
                    // Handle the end of the touch (e.g., release a dragged object).
                    break;
            }
        }

    }

    public void Button()
    {
        DebugConsole.instance.Log("HOLAAAAAAAAAAA");
        DebugConsole.instance.LogWarning("CARACOLA");
        DebugConsole.instance.LogError("!!");
    }
}
