using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal 
{
   public string Description { get; set; }  // its going to describe what the player has to do
    public bool Completed { get; set; } // whether its true or false
    public int CurrentAmmount { get; set; } // how many of the set amount has already been completed
    public int RequiredAmount { get; set; } // how many kitties needed for the player to go into the boss fight


    public virtual void Init () // a method that can be overwritten by other classes
    {

    } 
    public void Evaluate () // its going to check if the amount is the same or greater than
    { 
        if (CurrentAmmount >= RequiredAmount)
        {
            Complete ();    
        }

    } 

    public void Complete () 
    { 
        Completed = true;
    }
}

