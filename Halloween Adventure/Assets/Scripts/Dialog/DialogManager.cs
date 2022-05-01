using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgoundBox;
    public Animator animator;
    public float textSpeed = 0.05f;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    bool allTyped = false;

    public void OpenDialog(Message[] messages, Actor[] actors){
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        Debug.Log("Inicio de conversación. Mesages por mostrar: " + messages.Length);
        DisplayMessage();
        animator.SetBool("isStarted", true);
    }

    public void NextMessage(){
        if(allTyped){
            activeMessage++;
            allTyped = false;
            if(activeMessage < currentMessages.Length){
                DisplayMessage();
            }else{
                Debug.Log("Fin de conver");
                animator.SetBool("isStarted", false);
            }
        }else{
            StopCoroutine("TypeMessage");
            messageText.text = currentMessages[activeMessage].message;
            allTyped = true;
        }
        
    }

    void DisplayMessage(){
        Message messageToDisplay = currentMessages[activeMessage];
        //messageText.text = messageToDisplay.message;
        StartCoroutine(TypeMessage(messageToDisplay.message));

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    IEnumerator TypeMessage(string message){
        messageText.text = "";
        foreach(char letter in message.ToCharArray()){
            messageText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        allTyped = true;
    }
}
