using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent; // storing the text object in the game + holding all the lines in the dialogue
    private List<string> lines; // just holding all the lines in a list that are going to be displayed in the dialogue
    public float textSpeed; // the speed with which each letter appears 
    public GameObject Dialoguee; // just a reference which holds all the text and ui elements for the dialogues 
    private int index;// keeps track of what line is currently being shown

    [SerializeField] private bool inDialogue; // checks if the player is currently in the dialogue and the serialized field allows me to edit the private variable even tho its private 
    public UnityEvent startDialogue;
    public UnityEvent endDialogue;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty; // sets the dialogue text to an empty string so it doesnt show up at first and string.empty is the same as using "" 
        //StartDialogue();

    }

    // Update is called once per frame
    void Update()
    {
        if (inDialogue) // if the player is in the dialogue 
        {
            if (Input.GetMouseButtonDown(0)) // checks if the LMB is being pressed 
            {
                if (textComponent.text == lines[index]) // checks if the current text on the screen is accurate to the limne in the dialogue list and if thats so it shows the next line that should show up
                {
                    NextLine(); // which is this
                }
                else  //otherwise if it doesnt match that means that the dialogue hasn't finished displaying yet
                {
                    inDialogue = false; //ends the dialogue action
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                    Dialoguee.SetActive(false); //this hides the dialogue ui and sets it to innactive 
                }
            }
        }

    }

    public void StartDialogue(List<string> DialogueText) 
    {
        lines = DialogueText;
        startDialogue.Invoke(); // making it do a unity event 
        
        inDialogue = true;  
        Dialoguee.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Type things one by one
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            endDialogue.Invoke();// making it do a unity event
            Dialoguee.SetActive(false);
            Time.timeScale = 1f;
        }
    }

   


}