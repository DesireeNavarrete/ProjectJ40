using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public CanvasComponent canvasComp;

    [Header("Stats")]
    public Stat hambreStat;
    public Stat sleepStat;
    public Stat jugarStat;

    [Header("UI Views")]
    public StatsView hungerView;
    public StatsView sleepView;
    public StatsView playView;

    public static bool nivelesCriticos;
    public void Start()
    {
        //Creamos los stats default, con sus multiplicadores correspondientes
        hambreStat = new Stat(100, 2);
        sleepStat = new Stat(100, .5f);
        jugarStat = new Stat(100, 1);

        // Conectar UI
        if (hungerView != null) hungerView.SetStat(hambreStat);
        if (sleepView != null) sleepView.SetStat(sleepStat);
        if (playView != null) playView.SetStat(jugarStat);

        //Boton comer
        canvasComp.foodBut.onClick.AddListener(() =>
        {
            hambreStat.SetValue(100);
            canvasComp.foodBut.GetComponent<ButtonControl>().Cooldown();
        });

        //Boton pc
        canvasComp.computerBut.onClick.AddListener(() =>
        {
            jugarStat.SetValue(100);
            canvasComp.computerBut.GetComponent<ButtonControl>().Cooldown();
        });

        //Boton soldar
        canvasComp.weldBut.onClick.AddListener(() =>
        {
            jugarStat.SetValue(100);
            canvasComp.weldBut.GetComponent<ButtonControl>().Cooldown();
        });


        //Boton vater----------
        canvasComp.toiletBut.onClick.AddListener(() =>
        {
            canvasComp.toiletBut.GetComponent<ButtonControl>().Cooldown();
        });
        //Boton ducha--------------------
        canvasComp.showerBut.onClick.AddListener(() =>
        {
            canvasComp.showerBut.GetComponent<ButtonControl>().Cooldown();
        });
        //Boton dormir
        canvasComp.dormirBut.onClick.AddListener(() =>
        {
            sleepStat.SetValue(100);
            canvasComp.dormirBut.GetComponent<ButtonControl>().Cooldown();

        });
        //Boton protes
        canvasComp.proteinBut.onClick.AddListener(() =>
        {
            hambreStat.SetValue(100);
            canvasComp.proteinBut.GetComponent<ButtonControl>().Cooldown();

        });
        //Boton cafe
        canvasComp.coffeBut.onClick.AddListener(() =>
        {
            hambreStat.SetValue(100);
            canvasComp.coffeBut.GetComponent<ButtonControl>().Cooldown();

        });
        //Boton bricolaje
        canvasComp.bricolajeBut.onClick.AddListener(() =>
        {
            jugarStat.SetValue(100);
            canvasComp.bricolajeBut.GetComponent<ButtonControl>().Cooldown();

        });
        //Boton salir
        canvasComp.quedarBut.onClick.AddListener(() =>
        {
            jugarStat.SetValue(100);
            canvasComp.quedarBut.GetComponent<ButtonControl>().Cooldown();

        });
        //Boton crossfit
        canvasComp.crossfitBut.onClick.AddListener(() =>
        {
            jugarStat.SetValue(100);
            canvasComp.crossfitBut.GetComponent<ButtonControl>().Cooldown();

        });
        //Boton baloncesto
        canvasComp.baloncestoBut.onClick.AddListener(() =>
        {
            jugarStat.SetValue(100);
            canvasComp.baloncestoBut.GetComponent<ButtonControl>().Cooldown();

        });
        //Boton bio
        canvasComp.bioBut.onClick.AddListener(() =>
        {
            jugarStat.SetValue(100);
            canvasComp.bioBut.GetComponent<ButtonControl>().Cooldown();
        });

        //CUMPLE
        canvasComp.cumpleBut.onClick.AddListener(() =>
        {
            canvasComp.cumpleBut.GetComponent<ButtonControl>().Cooldown();
        });
    }

    public void Update()
    {
        // Actualizar decay
        UpdateDecay(hambreStat);
        UpdateDecay(sleepStat);
        UpdateDecay(jugarStat);

        //Cooldown
        StatsView.SliderCooldownStats(canvasComp.sliCooldown);

        if (hambreStat.Value <= 10 && sleepStat.Value <= 10 && jugarStat.Value <= 10)
        {
            print("Niveles críticos");
            nivelesCriticos = true;
            StartCoroutine(NivelesCriticos());
        }else
            nivelesCriticos = false;

        //if (!nivelesCriticos)
        //{
        //    canvasComp.canvasDeadPanel.GetComponent<CanvasGroup>().DOFade(0, .5f);
        //    canvasComp.canvasGame.GetComponent<CanvasGroup>().DOFade(1, .5f);
        //}
    }

    void UpdateDecay(Stat stat)
    {
        stat.Modify(-Time.deltaTime);
    }

    IEnumerator NivelesCriticos()
    {
        canvasComp.canvasDeadPanelInicioInfo.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        canvasComp.canvasDeadPanelInicio.SetActive(true);
        canvasComp.canvasGame.GetComponent<CanvasGroup>().DOFade(0, .5f);
        canvasComp.canvasDead.GetComponent<CanvasGroup>().DOFade(1, .5f);
        hambreStat.SetValue(50);
        sleepStat.SetValue(50);
        jugarStat.SetValue(50);
    }
}
