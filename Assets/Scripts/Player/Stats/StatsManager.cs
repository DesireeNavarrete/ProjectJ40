using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public CanvasComponent canvasComp;
    
    public Stat hambreStat;
    public Stat sleepStat;
    public Stat jugarStat;

    [Header("UI Views")]
    public StatsView hungerView;
    public StatsView sleepView;
    public StatsView playView;


    //public float pseudoNivelH,pseudoNivelS, pseudoNivelJ;
    public void Start()
    {
        hambreStat = new Stat(100, 5);
        sleepStat = new Stat(100, 1);
        jugarStat = new Stat(100, 2);

        // Conectar UI
        if (hungerView != null) hungerView.SetStat(hambreStat);
        if (sleepView != null) sleepView.SetStat(sleepStat);
        if (playView != null) playView.SetStat(jugarStat);

        canvasComp.FoodBut.onClick.AddListener(() => hambreStat.SetValue(100));

    }

    public void Update()
    {
        // Actualizar decay
        UpdateDecay(hambreStat);
        UpdateDecay(sleepStat);
        UpdateDecay(jugarStat);

    }
    void UpdateDecay(Stat stat)
    {
        stat.Modify(-Time.deltaTime);
    }

}
