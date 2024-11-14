using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Game
{
    public class ObjectiveManager : MonoBehaviour
    {
       public static List<Objective> m_Objectives = new List<Objective>();// currently active quests
        bool m_ObjectivesCompleted = false;

        void Awake()
        {
            Objective.OnObjectiveCreated += RegisterObjective;
        }

        void RegisterObjective(Objective objective) => m_Objectives.Add(objective);

        void Update()
        {
            if (m_Objectives.Count == 0 || m_ObjectivesCompleted)
                return;

            for (int i = 0; i < m_Objectives.Count; i++)
            {
                // pass every objectives to check if they have been completed
                if (m_Objectives[i].IsBlocking())
                {
                    // break the loop as soon as we find one uncompleted objective
                    return;
                }
            }

            m_ObjectivesCompleted = true;
            //EventManager.Broadcast(Events.AllObjectivesCompletedEvent); - it doesnt auto end it when no more quests are active
        }

        void OnDestroy()
        {
            Objective.OnObjectiveCreated -= RegisterObjective;
        }
    }
}