using ProjectJ40.Growth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool BabyToTeen;

    [SerializeField] private GrowthController growthController;
    public Player pj;

    private Dictionary<string, Quest> questMap;

    private void Awake()
    {
        questMap = CreateQuestMap();

        Quest quest = GetQuestById("FeedQuestStep");
        Debug.Log(quest.info.displayName);
        Debug.Log(quest.info.levelRequirement);
        Debug.Log(quest.state);
        Debug.Log(quest.CurrentStepExists());
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
    void Start()
    {

    }


    void Update()
    {
        if (BabyToTeen)
        {
            growthController.AdvanceToStage(GrowthStage.Teen);//cambiar al estapa de creciemiento dependiendo de las misiones
        }
    }
}
