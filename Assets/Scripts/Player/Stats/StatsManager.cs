using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public CanvasComponent canvasComp;
    
    public Stat hambreState;
    public Stat sleepState;
    public Stat jugarState;

    [Header("UI Views")]
    public StatsView hungerView;
    public StatsView sleepView;
    public StatsView playView;


    //public float pseudoNivelH,pseudoNivelS, pseudoNivelJ;
    public void Start()
    {
        hambreState = new Stat(100, 5);
        sleepState = new Stat(100, 1);
        jugarState = new Stat(100, 2);
        //pseudoNivelS = sleepState.nl;
        //pseudoNivelH = hambreState.nl;
        //pseudoNivelJ = jugarState.nl;
        // Conectar UI
        if (hungerView != null) hungerView.SetStat(hambreState);
        if (sleepView != null) sleepView.SetStat(sleepState);
        if (playView != null) playView.SetStat(jugarState);

    }

    public void Update()
    {
        // Actualizar decay
        UpdateDecay(hambreState);
        UpdateDecay(sleepState);
        UpdateDecay(jugarState);

        //pseudoNivelS = sleepState.nl;
        //pseudoNivelH = hambreState.nl;
        //pseudoNivelJ = jugarState.nl;

        //BajarNivelBase(hambreState, pseudoNivelH);
        //BajarNivelBase(sleepState,pseudoNivelS);
        //BajarNivelBase(jugarState,pseudoNivelJ);

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
    void UpdateDecay(Stat stat)
    {
        stat.Modify(-Time.deltaTime);
    }

    //void BajarNivelBase(Stat state, float pseudoLevel)
    //{
    //    state.sli.fillAmount = state.nl / 100;
    //    if (state.nl > 0 && state.nl <= 100)
    //    {
    //        state.SetNivel(pseudoLevel -= state.multipl * Time.deltaTime);
    //    }
    //    if (state.nl <= 25)
    //    {
    //        state.sli.color = Color.red;

    //    }
    //    else
    //        state.sli.color = Color.green;
    //}
}
