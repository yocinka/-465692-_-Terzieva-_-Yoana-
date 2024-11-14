using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // define quiries based on a condition

public class Quest : MonoBehaviour
{
  public List<Goal>Goals {  get; set; } = new List<Goal>();
    public string QuestName {  get; set; }  
    public string QuestDescription { get; set; }
    public bool Completed { get; set; } 


    public void CheckGoals ()
    {
        Completed = Goals.All (g => g.Completed);
        if (Goals.All (g => g.Completed))
        {
            Complete(); 
        }
    }
    
    void Complete()
    {
        Completed = true; 
    }
}
