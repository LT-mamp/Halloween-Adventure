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

    [Header("Game Manager")]
    [SerializeField] GameManager gm;

    //[Header("Story")]
    Story currentStory;
    //bool isPlaying;
    bool allTyped;
    string messageToDisplay;
    Coroutine typeMessage;

    private const string Actor_Name = "Name";
    private const string Actor_Image = "Image";
    private const string Sound_To_Play = "Sound";


    private void Awake() {
        if (instance != null){
            Debug.LogError("Found more than one Dialog Manager in the scene.");
        }
        instance = this;
    }
    
    private void Start() {
        //isPlaying = false;
        allTyped = true;
    }

    private void Update() {
        /*if(!isPlaying){
            return;
        }*/
        
        //continue to next line if continue is pressed
        // that means call nextMessage()
    }

    public void OpenDialog(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        //isPlaying = true;


        Debug.Log("Inicio de conversación.");
        if(currentStory.canContinue){
            DisplayMessage();
            animator.SetBool("isStarted", true);
        }
        else{
            CloseDialog();
            Debug.LogWarning("Intentando iniciar un diálgo con una historia vacía");
        }
        
    }

    void DisplayMessage(){
        if(!allTyped){
            StopCoroutine(typeMessage);
            messageText.text = messageToDisplay;
            allTyped = true;
        }else{
            messageText.text = "";
            allTyped = false;

            messageToDisplay = currentStory.Continue();
        
            typeMessage = StartCoroutine(TypeMessage(messageToDisplay));

            //tags
            HandleTags(currentStory.currentTags);
        }
    }

    IEnumerator TypeMessage(string message){
        foreach(char letter in message.ToCharArray()){
            if(allTyped){
                Debug.LogWarning("Still typing but shouldn't");
            }
            messageText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        allTyped = true;
    }

    void HandleTags(List<string> currentTags){
        foreach (string tag in currentTags)
        {
            //parse the tag
            string[] splitTag = tag.Split(':');

            if(splitTag.Length != 2){
                Debug.LogError("La tag no se ha podido leer correctamente. Tag: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case Actor_Name:
                    //Debug.Log("name=" + tagValue);
                    if(tagValue == "None"){
                        actorName.enabled = false;
                    }else{
                        actorName.enabled = true;
                        actorName.text = tagValue;
                    }
                    break;
                case Actor_Image:
                    //Debug.Log("image=" + tagValue);
                    if(tagValue == "None"){
                        actorImage.enabled = false;
                    }else{
                        //actorImage.sprite = tagValue;
                    }
                    break;
                case Sound_To_Play:
                    Debug.Log("name=" + tagValue);
                    /*if(tagValue == "None"){
                        actorName.enabled = false;
                    }else{
                        actorName.text = tagValue;
                    }*/
                    break;
                default:
                    Debug.LogWarning("Tag no válidad: " + tag);
                    break;
            }
        }
    }

    public void NextMessage(){
        if(currentStory.canContinue){
            DisplayMessage();
        }
        else{
            CloseDialog();
        }
    }

    void CloseDialog(){
        Debug.Log("End of story");

        animator.SetBool("isStarted", false);
        //isPlaying = false;
        messageText.text = "";

        //gm.SetNextLevelIndex(-1);

        gm.levelLoader.LoadNextLevel();
    }

    //si el texto se corresponde con un comando, hacer un switch y llamar a la función correspondiente.
    //arreglar el bug de hacer click muy rápido y se bugea el texto

}
