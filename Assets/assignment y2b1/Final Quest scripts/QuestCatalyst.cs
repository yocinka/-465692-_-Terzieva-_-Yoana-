using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class QuestCatalyst : MonoBehaviour
{
    [SerializeField] private string objective; // making sure that the quest can be typen in from the inside of the game engine instead of here (vis studio)
    [SerializeField] private GameObject notification; // reference to the notif so it can be selected inside the engine 
    private bool objectiveAdded = false;    // keeping track whether the quest is there or not so it doesnt copy itself multiple times

    // writing the methods for adding the quest
    public void CreateQuest ()
    {
        if(objective != null && !objectiveAdded) //if theres a quest to add which hasnt been added yet => it gets added to the manager list, also since it's being added it needs to somehow tell the player whats happening

        {
            objectiveAdded = !objectiveAdded; 
            QuestLogManager.questLogManager.questNames.Add(objective);
        }

        if (notification != null && !objectiveAdded)
        {
            notification.SetActive(true);
        }
    }

    public void CompleteObjective () // will remove the objective from the list once it's done 
    { 
        if (objective != null && QuestLogManager.questLogManager.questNames.Contains(objective))
        {
            QuestLogManager.questLogManager.questNames.Remove(objective);
        }
    }

}
