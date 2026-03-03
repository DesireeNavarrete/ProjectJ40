using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    //clase que tiene que heredar otra y no se usa directamente
    private bool isFinished = false;

    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
            
            //Avanzar la quest ahora que ya ha sido completado el step, antes de eliminar el prefab

            Destroy(this.gameObject);
        }
    }

}
