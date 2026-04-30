using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public GrowthController growthController;
    public Player pj;

    private Dictionary<string, Quest> questMap;

    public static int level = 0;

    public UIManager uiManager;

    public CanvasComponent canvasComp;
    public Notifications notis;
    private void Awake()
    {
        questMap = CreateQuestMap();
    }

    //nos suscribimos a los eventos de la quest, para poder empezarlas y completarlas
    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;
    }

    private void StartQuest(string id)
    {
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(quest.info.id, QuestState.IN_PROGRESS);
    }

    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);

        //pasamos al siguiente paso
        quest.MoveToNextStep();

        //Si hay mas pasos, instanciar el siguiente
        if (quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        //si no hay mas, finalizamos quest
        else
        {
            ChangeQuestState(quest.info.id, QuestState.CAN_FINISH);
        }
    }
    private void FinishQuest(string id)
    {
        Quest quest = GetQuestById(id);
        ClaimRewards(quest);
        ChangeQuestState(quest.info.id, QuestState.FINISHED);
    }

    private void ClaimRewards(Quest quest)
    {
        var i = canvasComp.questPanelIsntanciar.transform.childCount;
        canvasComp.sliExp.value += canvasComp.sliExp.maxValue / i;

        if (canvasComp.sliExp.value == canvasComp.sliExp.maxValue)
        {
            print("ETAPA COMPLETE");
            switch (GrowthController.GrowthFSM.CurrentState)
            {
                case BabyPhase:
                    uiManager.Cumple();
                    break;
                case TeenPhase:
                    uiManager.Cumple();
                    break;
                case AdultPhase:
                    //TODO: texto diferente Y CINEMATICA?¿?¿?¡ O TEXTO O COMO SE ACABA EL JUEGO?¿?¿
                    notis.AddNotificationUI("-¡Enhorabuena!\r\nJavi ya se vale por si solo... ya no te necesita..");
                    break;

            }
        }
    }


    //nos desuscribimos de los eventos
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;
    }

    private void Start()
    {
        //ponemos el estado inicial de todas las quests al arrancar
        foreach (Quest quest in questMap.Values)
        {
            // initialize any loaded quest steps
            //if (quest.state == QuestState.IN_PROGRESS)
            //{
            //    quest.InstantiateCurrentQuestStep(this.transform);
            //}
            // broadcast the initial state of all quests on startup
            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
    }

    //Metodo para actualizar el estado de la quest, se puede utilizar desde donde queramos para actualizarlo
    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventsManager.instance.questEvents.QuestStateChange(quest);
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {
        //Coge todos los scriptables de misiones creados en la carpeta
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        //Crea el mapa de misiones
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in allQuests)
        {
            if (idToQuestMap.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("Id duplicado cuando se crea el mapa: " + questInfo.id);
            }
            idToQuestMap.Add(questInfo.id, new Quest(questInfo));
        }
        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogError("ID no encontrado en el mapa de misiones: " + id);
        }
        return quest;
    }
    private bool CheckRequirementsMet(Quest quest)
    {
        // empieza en true y se cambia a false para entrar una vez
        bool meetsRequirements = true;

        //mira el nivel del jugador, y si el nivel es menor sale de aqui
        if (level < quest.info.levelRequirement)
        {
            meetsRequirements = false;
        }

        // revisa los prerequisitos
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
        {
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
                //añadimos el break para salirnos de aqui, porque ya esta finalizada
                break;
            }
        }
        return meetsRequirements;
    }

    void Update()
    {
        foreach (Quest quest in questMap.Values)
        {
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }
        }
    }
}
