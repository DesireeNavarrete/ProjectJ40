using UnityEngine;
using UnityEngine.UI;

public class StatesManager : MonoBehaviour
{
    public States hambreState;
    public States sleepState;
    public States jugarState;
    public CanvasComponent canvasComp;
    public float pseudoNivelH,pseudoNivelS, pseudoNivelJ;
    public void Start()
    {
        hambreState = new States(100, 5, canvasComp.nivelSliderHambre);
        sleepState = new States(100, 1, canvasComp.nivelSliderSueño);
        jugarState = new States(100, 2, canvasComp.nivelSliderJugar);
        pseudoNivelS = sleepState.nl;
        pseudoNivelH = hambreState.nl;
        pseudoNivelJ = jugarState.nl;

    }

    public void Update()
    {
        pseudoNivelS = sleepState.nl;
        pseudoNivelH = hambreState.nl;
        pseudoNivelJ = jugarState.nl;

        BajarNivelBase(hambreState, pseudoNivelH);
        BajarNivelBase(sleepState,pseudoNivelS);
        BajarNivelBase(jugarState,pseudoNivelJ);

        //hambre
        //hambreState.sli.fillAmount = hambreState.nl / 100;
        //if (hambreState.nl > 0 && hambreState.nl <= 100)
        //{
        //    hambreState.SetNivel(pseudoNivelH -= hambreState.multipl * Time.deltaTime);
        //}
        //if (hambreState.nl <= 25)
        //{
        //    hambreState.sli.color = Color.red;

        //}
        //else
        //    hambreState.sli.color = Color.green;

        //sueño
        //sleepState.sli.fillAmount = sleepState.nl / 100;
        //if (sleepState.nl > 0 && sleepState.nl <= 100)
        //{
        //    sleepState.SetNivel(pseudoNivelS -= sleepState.multipl * Time.deltaTime);
        //}
        //if (sleepState.nl <= 25)
        //{
        //    sleepState.sli.color = Color.red;

        //}
        //else
        //    sleepState.sli.color = Color.green;
    }

    void BajarNivelBase(States state, float pseudoLevel)
    {
        state.sli.fillAmount = state.nl / 100;
        if (state.nl > 0 && state.nl <= 100)
        {
            state.SetNivel(pseudoLevel -= state.multipl * Time.deltaTime);
        }
        if (state.nl <= 25)
        {
            state.sli.color = Color.red;

        }
        else
            state.sli.color = Color.green;
    }
}
