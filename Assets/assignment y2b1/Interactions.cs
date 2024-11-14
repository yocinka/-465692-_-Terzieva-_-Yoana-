using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactions : MonoBehaviour

{
    [SerializeField] private bool oneTimeInteraction;
    private bool hasInteracted;
    public UnityEvent<List<string>> npcInteract; 
   
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {


            float interactRange = 2f;// basically the interaction triggers once the player is in a certain distance from the kitty 
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
               if (collider.TryGetComponent(out NPCInteractable npcInteractable))  
                {
                    if (!hasInteracted)
                    {
                        npcInteractable.Interact();
                        npcInteract.Invoke(npcInteractable.dialogueList);
                    }
                    if (oneTimeInteraction)
                    {
                        hasInteracted = true;
                    } else
                    {
                        hasInteracted = false;
                    }
                    
                    


                }
            }
        }
    }
}
