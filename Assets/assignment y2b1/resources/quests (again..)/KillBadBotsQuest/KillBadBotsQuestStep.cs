using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class KillBadBotsQuestStep : QuestStep
{
   private int enemyKilled = 0;

    private int enemiesToKill = 2;

    private void OnEnable()
    {
        //EventManager.instance.onEnemiesToKill += enemiesKilled; 
    }

    private void OnDisable() 
    { 

    }    


    private void EnemiesKilled ()
    {
        if ( enemyKilled < enemiesToKill  ) // keeps adding if its not meeting the final requirement
        {
            enemyKilled++;
        }

        if (enemyKilled >= enemiesToKill )  // ends the quest if the player has killed more or just enough bots to continue
        { 
            FinishQuestStep();
        }
    }
}
