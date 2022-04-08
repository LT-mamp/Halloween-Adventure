using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogManager1 : MonoBehaviour
{
    private static DialogManager1 instance;

    [Header("Dialogue UI")]
    [SerializeField] Image actorImage;
    [SerializeField] TextMeshProUGUI actorName;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] RectTransform backgoundBox;

    [Header("Animation")]
    public Animator animator;
    public float textSpeed = 0.05f;

    //[Header("Story")]
    Story currentStory;
    bool isPlaying;
    bool allTyped;


    private void Awake() {
        if (instance != null){
            Debug.LogError("Found more than one Dialog Manager in the scene.");
        }
        instance = this;
    }
    
    private void Start() {
        isPlaying = false;
        //animator.SetBool("isStarted", true);
    }

    private void Update() {
        if(!isPlaying){
            return;
        }
        
        //continue to next line if continue is pressed
        // that means call nextMessage()
    }

    public void OpenDialog(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        isPlaying = true;


        Debug.Log("Inicio de conversación.");
        if(currentStory.canContinue){
            DisplayMessage();
            animator.SetBool("isStarted", true);
        }
        else{
            CloseDialog();
        }
        
    }

    void DisplayMessage(){
        //Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = "";
        allTyped = false;
        //messageText.text = messageToDisplay.message;
        StartCoroutine(TypeMessage(currentStory.Continue()));

        //Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        //actorName.text = actorToDisplay.name;
        //actorImage.sprite = actorToDisplay.sprite;

    }

    IEnumerator TypeMessage(string message){
        messageText.text = "";
        foreach(char letter in message.ToCharArray()){
            messageText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        allTyped = true;
    }

    public void NextMessage(){
        if(currentStory.canContinue){
            DisplayMessage();
            animator.SetBool("isStarted", true);
        }
        else{
            CloseDialog();
        }
    }

    void CloseDialog(){
        animator.SetBool("isStarted", false);
        isPlaying = false;
        messageText.text = "";
    }

}
