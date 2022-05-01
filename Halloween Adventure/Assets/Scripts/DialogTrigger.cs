using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subtegral.DialogueSystem.DataContainers;
using System.Linq;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private DialogueContainer dialogue;
    [SerializeField] private DialogueParser dialogueParser;
    //public Actor[] actors;

    public void StartDialog(){
        //FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
        dialogueParser.ProceedToNarrative(dialogue.NodeLinks.First().TargetNodeGUID, dialogue);
    }
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