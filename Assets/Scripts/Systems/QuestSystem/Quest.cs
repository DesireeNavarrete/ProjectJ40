using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    //static info
    public QuestInfoSO info;

    //state info
    public QuestState state;
    private int currentQuestStepIndex;

    public Quest(QuestInfoSO questInfoSo)
    {
        this.info = questInfoSo;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
    }

    public void MoveToNextStep()
    {
        currentQuestStepIndex++;
    }

    public bool CurrentStepExists()
    {
        return (currentQuestStepIndex < info.questStepPrefabs.Length);//devuelve true si el index es menor que el tamaño de los steps
    }

    //instancia el prefab del step que toca
    //TODO: instanciar tambien el Text en el panel de quests
    public void InstantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = GetCurrentQuestStepPrefab();
        if (questStepPrefab != null)
        {
           QuestStep questStep= Object.Instantiate<GameObject>(questStepPrefab, parentTransform).GetComponent<QuestStep>();
            questStep.InitializeQuestStep(info.id);
        }
    }

    //sacamos el prefab del step que toca
    public GameObject GetCurrentQuestStepPrefab()
    {
        GameObject questStepPrefab = null;
        if (CurrentStepExists())
        {
            questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        }
        else
        {
            Debug.LogWarning("Tried to get quest step prefab, but stepIndex was out of range indicating that "
                + "there's no current step: QuestId=" + info.id + ", stepIndex=" + currentQuestStepIndex);
        }
        return questStepPrefab;
    }
}
