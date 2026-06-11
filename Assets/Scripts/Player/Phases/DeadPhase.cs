using DG.Tweening;
using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadPhase : IState
{
    public GrowthStage Stage => GrowthStage.Dead;

    private readonly Player pj;
    private readonly StateMachine fsm;

    CanvasComponent canvasComp;
    StatsManager statsManager;

    public DeadPhase(Player p, StateMachine fsm)
    {
        this.pj = p;
        this.fsm = fsm;
    }
    public void Enter()
    {
        Debug.Log("Enter Dead");
        canvasComp = GameObject.Find("CanvasPrincipal").GetComponent<CanvasComponent>();
        statsManager = GameObject.Find("--StatsManager--").GetComponent<StatsManager>();

        canvasComp.canvasDeadPanelInicioInfo.SetActive(true);//panel de oh no
        canvasComp.canvasDeadPanelInicio.SetActive(true);//panel de clica en javi
        //canvasComp.canvasGame.GetComponent<CanvasGroup>().DOFade(0, .5f).OnComplete(() =>
        //{
        canvasComp.canvasGame.GetComponent<CanvasGroup>().DOFade(0, .5f);
        canvasComp.canvasGame.SetActive(false);
        canvasComp.canvasDead.SetActive(true);
        canvasComp.canvasDead.GetComponent<CanvasGroup>().DOFade(1, .5f);//canvas entero

    }

    public void Execute()
    {
        Debug.Log("Dying");
    }

    public void Exit()
    {
        Debug.Log("Ya no esta dead");

        statsManager.hambreStat.SetValue(50);
        statsManager.sleepStat.SetValue(50);
        statsManager.jugarStat.SetValue(50);

        canvasComp.canvasDead.SetActive(false);//canvas del minijuego
        canvasComp.canvasGame.SetActive(true);//canvas principal
        //todo: cambiar de fase a stateBeforeDie

        canvasComp.canvasDeadPanelInicioInfo.SetActive(false);
    }

}
