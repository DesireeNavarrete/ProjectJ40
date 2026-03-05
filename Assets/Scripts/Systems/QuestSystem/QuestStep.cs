using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    //clase que tiene que heredar otra y no se usa directamente
    private bool isFinished = false;

    private string questId;//saber de que quest esta siendo parte

    public void InitializeQuestStep(string questiId)
    {
        this.questId=questiId;
    }

    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
            //Avanzar la quest ahora que ya ha sido completado el step, antes de eliminar el prefab
            GameEventsManager.instance.questEvents.AdvanceQuest(questId);
            Destroy(this.gameObject);
        }
    }
}
