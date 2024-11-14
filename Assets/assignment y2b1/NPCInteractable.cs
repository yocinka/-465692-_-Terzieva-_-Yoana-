using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public List<string> dialogueList;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Interact () 
    {
        Debug.Log("Interact :3 ");

        animator.SetTrigger("talk");
        // animator.SetBool("greeting", true);  thas for later 
    } 
}
