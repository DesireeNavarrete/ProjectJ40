using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugCanvas : MonoBehaviour
{
    [Header("DebugCanvas")]
    public Button debugButton;
    public GameObject debugCanvas;
    public GameObject consoleDebug;

    [Header("Stats")]
    public Text statHambreVal;
    public Text statJugarVal;
    public Text statSleepVal;

    public Text statHambreMult;
    public Text statJugarMult;
    public Text statSleepMult;

    [Header("Managers")]
    public StatsManager statsManager;

    [Header("Buttons")]
    public Button hambreBtnVal;
    public Button sleepBtnVal;
    public Button playBtnVal;

    public Button hambreBtnMult;
    public Button sleepBtnMult;
    public Button playBtnMult;

    [Header("InputFields")]
    public InputField hambreInputVal;
    public InputField sleepInputVal;
    public InputField jugarInputVal;

    public InputField hambreInputMult;
    public InputField sleepInputMukt;
    public InputField jugarInputMult;

    void Start()
    {
        debugButton.onClick.AddListener(() => EnableDisableDebug(debugCanvas));
        debugButton.onClick.AddListener(() => EnableDisableDebug(consoleDebug));

        //cambio de valor
        hambreBtnVal.onClick.AddListener(() => ApplyValue(hambreInputVal, statsManager.hambreStat));
        sleepBtnVal.onClick.AddListener(() => ApplyValue(sleepInputVal, statsManager.sleepStat));
        playBtnVal.onClick.AddListener(() => ApplyValue(jugarInputVal, statsManager.jugarStat));
        //cambio de multiplicador
        hambreBtnMult.onClick.AddListener(() => ApplyMultiplier(hambreInputMult, statsManager.hambreStat));
        sleepBtnMult.onClick.AddListener(() => ApplyMultiplier(sleepInputMukt, statsManager.sleepStat));
        playBtnMult.onClick.AddListener(() => ApplyMultiplier(jugarInputMult, statsManager.jugarStat));
    }

    // Update is called once per frame
    void Update()
    {
        statHambreVal.text = Mathf.Round(statsManager.hambreStat.Value).ToString();
        statJugarVal.text = Mathf.Round(statsManager.jugarStat.Value).ToString();
        statSleepVal.text = Mathf.Round(statsManager.sleepStat.Value).ToString();

        statHambreMult.text = statsManager.hambreStat.Multiplier.ToString();
        statJugarMult.text = statsManager.jugarStat.Multiplier.ToString();
        statSleepMult.text = statsManager.sleepStat.Multiplier.ToString();
    }

    //cambio de valor para testeo
    public void ApplyValue(InputField input, Stat stat)
    {
        float valueF = float.Parse(input.text);
        stat.SetValue(valueF);
    }

    //cambio de multiplicador para testeo
    public void ApplyMultiplier(InputField input, Stat stat)
    {
        float valueF = float.Parse(input.text);
        stat.Multiplier = valueF;
    }
    public void EnableDisableDebug(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
            panel.SetActive(true);
    }
}
