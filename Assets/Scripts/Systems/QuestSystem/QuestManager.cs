using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool BabyToTeen;

    [SerializeField] private GrowthController growthController;
    public Player pj;

    private Dictionary<string, Quest> questMap;

    public int level = 0;

    private void Awake()
    {
        questMap = CreateQuestMap();

        //Quest quest = GetQuestById("FeedQuestStep");
        //Debug.Log(quest.info.displayName);
        //Debug.Log(quest.info.levelRequirement);
        //Debug.Log(quest.state);
        //Debug.Log(quest.CurrentStepExists());
    }

    private void StartQuest(string id)
    {
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestStatte(quest.info.id, QuestState.IN_PROGRESS);
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
            print("hay mas pasos");
        }
        //si no hay mas, finaliazmos quest
        else
        {
            ChangeQuestStatte(quest.info.id, QuestState.CAN_FINISH);
            print("no hay mas pasos");
        }
    }
    private void FinishQuest(string id)
    {
        Quest quest= GetQuestById(id);
        ClaimRewards(quest); 
        ChangeQuestStatte(quest.info.id, QuestState.FINISHED);

    }

    private void ClaimRewards(Quest quest)
    {

    }

    //nos suscribimos a los eventos de la quest
    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;
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
            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
    }

    //Metodo para actualizar el estado de la quest, se puede utilizar desde donde queramos para actualizarlo, como en la fase
    private void ChangeQuestStatte(string id, QuestState state)
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
        // start true and prove to be false
        bool meetsRequirements = true;

        // check player level requirements
        if (level < quest.info.levelRequirement)
        {
            meetsRequirements = false;
        }

        // check quest prerequisites for completion
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
        {
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
                // add this break statement here so that we don't continue on to the next quest, since we've proven meetsRequirements to be false at this point.
                break;
            }
        }
        return meetsRequirements;
    }


    void Update()
    {
        //if (BabyToTeen)
        //{
        //    growthController.AdvanceToStage(GrowthStage.Teen);//cambiar al estapa de creciemiento dependiendo de las misiones
        //}

        foreach (Quest quest in questMap.Values)
        {
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestStatte(quest.info.id, QuestState.CAN_START);
            }
        }
    }
}
