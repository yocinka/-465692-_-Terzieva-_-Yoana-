using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class QuestStep : MonoBehaviour // abstract - it can be inherited from another class without it being used directly
{
    private bool isFinished = false;

    protected void FinishQuestStep ()
    {
        if (!isFinished)
        {
            isFinished = true;  
            // add more ig
            Destroy(this.gameObject);
        }
    }
}
