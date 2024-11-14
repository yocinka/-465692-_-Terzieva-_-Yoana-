using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using Unity.FPS.Game;

public class QuestButtonVro : MonoBehaviour
{
    [SerializeField] private GameObject objectPage;
   [SerializeField] private Text objectiveTextBox; //had to be modified cuz the textmextprougui is the one being used in the fps microgame
    [SerializeField] private GameObject notification;
    [SerializeField] private string[] noObjectivesText;

    private bool openObjectives;

    public void QuestButtonVrov() // toggling the bool basically whether the objectives menu is opened or closed 
    {
        List<string> objectivebreh = new List<string>(); //looks for how many objects are in the objmanager

        for (int i = 0; i < ObjectiveManager.m_Objectives.Count; i++)
        {
            if (!ObjectiveManager.m_Objectives[i].IsCompleted) // its getting cleared by being made again; its a list with multiple things in it - all the quests in the game including the completed ones
            {

                objectivebreh.Add(ObjectiveManager.m_Objectives[i].Title);
            }

        }
        QuestLogManager.questLogManager.questNames= objectivebreh;

        openObjectives = !openObjectives; // from the preffered height we come back to this
        CreateObjective();
        WriteObjectives();
        if (openObjectives)
        {
          Cursor.lockState = CursorLockMode.None; //so that i can move the cursor
        }
        else
        {
         Cursor.lockState= CursorLockMode.Locked; // and if the menu is closed the cursor snaps back again 
        }
            Cursor.visible = openObjectives;// if the objective bool is true the cursor is visible and if not its invisible
    }

    private void CreateObjective ()
    {
        if (objectPage != null && notification != null)
        {
            if (openObjectives) //checking if i have a page and notification to work with and if there is the book should be opened amd the page becomes active a
            {
                objectPage.SetActive(true);
                notification.SetActive(true);
            }
            else 
            {
             objectPage.SetActive(false);
                
            }

        }   


        
    }

    private void WriteObjectives()
    {
        if (objectiveTextBox !=null)
        {
            if (QuestLogManager.questLogManager.questNames.Count == 0)
            {
                if (noObjectivesText != null) 
                { 
                    int randomNumber = (Random.Range(0, noObjectivesText.Length));
                    objectiveTextBox.text = noObjectivesText[randomNumber]; 
                }

               
            }
            else
            {
                StringBuilder stringBuilder = new(); // adding all the quests together into a huge string kinda dividing each quest into a new line 
                foreach (string quest in QuestLogManager.questLogManager.questNames)
                {
                    stringBuilder.Append(quest);
                }
                objectiveTextBox.text = stringBuilder.ToString();
            }
         // preferred height is the height at which all the text characters that fit in the box
            objectiveTextBox.rectTransform.localPosition = new Vector2(objectiveTextBox.rectTransform.sizeDelta.x , objectiveTextBox.preferredHeight); // resizing the text box by keeping its initial width and thats why the textbox is the same width as the text mask
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            QuestButtonVrov();
        }

    }
}
