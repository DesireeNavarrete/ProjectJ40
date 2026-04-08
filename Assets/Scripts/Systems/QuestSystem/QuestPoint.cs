using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPoint : MonoBehaviour
{
    [Header("Dialogue (optional)")]
    [SerializeField] private string dialogueKnotName;

    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private string questId;
    private QuestState currentQuestState;
    public CanvasComponent canvasComp;
    Text textQuest;

    private void Awake()
    {
        questId = questInfoForPoint.id;
    }

    //suscribimos al evento onQuestStateChange
    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        //solo actualiza el estado si tiene la quest correspondiente
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log("Quest con id: " + questId + " actualizado estado " + currentQuestState);
            DebugConsole.instance.Log("Quest con id: " + questId + " actualizado estado " + currentQuestState);
        }
    }

    private void Update()
    {
        // start or finish a quest
        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.instance.questEvents.StartQuest(questId);
            //TODO: poner titulo de quest?
            textQuest = Instantiate(canvasComp.textPrefabQuest, canvasComp.questPanelIsntanciar);
            textQuest.text=questId.ToString();
        }
        else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventsManager.instance.questEvents.FinishQuest(questId);
            textQuest.color = Color.green;
            StartCoroutine(QuestComplete());
        }

    }
    protected IEnumerator QuestComplete()
    {
        //yield return new WaitUntil(() => isFinished = true);
        canvasComp.questCompletePanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvasComp.questCompletePanel.SetActive(false);

    }
}