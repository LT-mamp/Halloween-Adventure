using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subtegral.DialogueSystem.DataContainers;
using System.Linq;

public class DialogTrigger : MonoBehaviour
{
    public Animator animator;

    [Header("Set Up")]
    [SerializeField] private DialogManager1 manager;
    [SerializeField] bool runOnStart = false;
    [SerializeField] bool waitBeforeOpening = false;
    [SerializeField] float timeToWait = 0f;

    [Header("Inky Story")]
    [SerializeField] private TextAsset dialogJSON;

    /*[Header("Test nodos")]
    [SerializeField] private DialogueContainer dialogue;
    [SerializeField] private DialogueParser dialogueParser;
    //public Actor[] actors;*/

    private void Start() {
        if(runOnStart){
            StartCoroutine(DialogueCall());
        }
    }

    public void StartDialog(){
        StartCoroutine(DialogueCall());
    }

    IEnumerator DialogueCall(){
        float s = 0f;
        if(waitBeforeOpening){
            s = timeToWait;
        }

        yield return new WaitForSeconds(s);

        manager.OpenDialog(dialogJSON);
    }

    /*public void StartDialog(Message[] messages, Actor[] actors){
        
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
    }*/
}


[System.Serializable]
public class Message {
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor {
    public string name;
    public Sprite sprite;
}