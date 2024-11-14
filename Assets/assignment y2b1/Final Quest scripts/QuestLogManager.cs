using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.FPS.Game;
using UnityEditorInternal;
using UnityEngine;

public class QuestLogManager : MonoBehaviour
{
    public static QuestLogManager questLogManager; // its the only instance of a questlogmanager in the game which cancels out the possibilities of dataloss ; accessible from anywhere
    public List<string> questNames = new();
   
    private void Awake()
    {
        if (questLogManager != null)
        {
            Destroy(gameObject);
        }

        questLogManager = this; // this as in script
        DontDestroyOnLoad(gameObject); 
    }

    private void Update() //open quest function  i have to put it there; grabbing the names - this was 

    {
        // this updates the names but it shouldnt update it everyframe it should be only doing this when the quest log is opened :D
        /* 
         * List<string> objectivebreh = new List<string>(); //looks for how many objects are in the objmanager
 
  for (int i = 0; i < ObjectiveManager.m_Objectives.Count; i++)
  {
      if (!ObjectiveManager.m_Objectives[i].IsCompleted) // its getting cleared by being made again; its a list with multiple things in it - all the quests in the game including the completed ones
      {

          objectivebreh.Add(ObjectiveManager.m_Objectives[i].Title);
      }

  }
  questNames = objectivebreh;

*/

    }
}
