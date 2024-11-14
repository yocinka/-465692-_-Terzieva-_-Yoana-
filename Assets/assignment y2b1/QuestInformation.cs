using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "QuestInfo" , menuName = "ScriptableObjects", order =1)]
public class QuestInformation : ScriptableObject 
{
    [SerializeField ] public string id { get; private set;} //its going to be used to reference any quest across the entire system

    [Header ("General") ]
    public string displayName;
    
    public QuestInformation[] questInformation;

    [Header("Steps")]
    public GameObject[] questStepPrefabs; 
    // the id name for everything has to be the same as the SO
    private void OnValidate()
    {

#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
# endif 

    }
}
