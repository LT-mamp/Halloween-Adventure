using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

<<<<<<< Updated upstream
public class DialogManager1 : MonoBehaviour
{
    private static DialogManager1 instance;

    [Header("Dialogue UI")]
    [SerializeField] Image actorImage;
    [SerializeField] TextMeshProUGUI actorName;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] RectTransform backgoundBox;
=======
public enum DialogMode{
    NORMAL,
    AUTO,
    NO_TYPPING
}

public class DialogManager1 : MonoBehaviour
{
    private static DialogManager1 instance;
    
//bool test = false;

    [Header("Dialogue UI")]
    [SerializeField] Image actorImage;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] RectTransform backgoundBox;
    [SerializeField] GameObject holeScreenNextButton;
    [SerializeField] TextMeshProUGUI dialogModeText;

    [Header("Choices UI")]
    [SerializeField] GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
>>>>>>> Stashed changes

    [Header("Animation")]
    public Animator animator;
    public float textSpeed = 0.05f;

    [Header("Game Manager")]
    [SerializeField] GameManager gm;
<<<<<<< Updated upstream

    //[Header("Story")]
    Story currentStory;
=======
    [SerializeField] bool bifurcation = false;

    //[Header("Story")]
    Story currentStory;
    bool hasChoices;
>>>>>>> Stashed changes
    //bool isPlaying;
    bool allTyped;
    string messageToDisplay;
    Coroutine typeMessage;
    bool skiping = false;
<<<<<<< Updated upstream
=======
    bool paused = false;
    //bool isChoosing = false;
    DialogMode mode = DialogMode.NORMAL;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
    }

    private void Update() {
        /*if(!isPlaying){
            return;
        }*/
        
        //continue to next line if continue is pressed
        // that means call nextMessage()
    }
=======

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        hasChoices = false;
        hideChoices(0);
        holeScreenNextButton.SetActive(false);
    }
    

    /*public void ChangeDialogMode(DialogMode newMode){
        dialogMode = newMode;
    }*/
>>>>>>> Stashed changes

    public void OpenDialog(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        //isPlaying = true;


        Debug.Log("Inicio de conversación.");
        if(currentStory.canContinue){
            DisplayMessage();
            animator.SetBool("isStarted", true);
<<<<<<< Updated upstream
=======
            holeScreenNextButton.SetActive(true);
>>>>>>> Stashed changes
        }
        else{
            CloseDialog();
            Debug.LogWarning("Intentando iniciar un diálgo con una historia vacía");
        }
        
    }

    void DisplayMessage(){
<<<<<<< Updated upstream
        if(!allTyped){
=======
        if(!allTyped /*&& typeMessage != null*/){
>>>>>>> Stashed changes
            StopCoroutine(typeMessage);
            messageText.text = messageToDisplay;
            allTyped = true;
        }else{
            messageText.text = "";
<<<<<<< Updated upstream
            allTyped = false;

            messageToDisplay = currentStory.Continue();
        
            typeMessage = StartCoroutine(TypeMessage(messageToDisplay));
=======

            messageToDisplay = currentStory.Continue();

            hasChoices = (currentStory.currentChoices.Count > 0);

            if(mode == DialogMode.NO_TYPPING){
                messageText.text = messageToDisplay;
                allTyped = true;
            }
            else{
                allTyped = false;
                if(messageToDisplay == "" || messageToDisplay == "\n"){
                    messageToDisplay =currentStory.Continue();
                    hasChoices = (currentStory.currentChoices.Count > 0);
                }
                typeMessage = StartCoroutine(TypeMessage(messageToDisplay));
                //if(test) Debug.Log("display \"" + messageToDisplay + "\" that.");

            }
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
    }

    void HandleTags(List<string> currentTags){
=======
        if(mode == DialogMode.AUTO){
            StartCoroutine(AutoNextMessage());
        }
    }

    IEnumerator AutoNextMessage(){
        yield return new WaitForSeconds(1f);
        NextMessage();
    }

    void HandleTags(List<string> currentTags){ 
>>>>>>> Stashed changes
        foreach (string tag in currentTags)
        {
            //parse the tag
            string[] splitTag = tag.Split(':');

            if(splitTag.Length != 2){
                Debug.LogError("La tag no se ha podido leer correctamente. Tag: " + tag);
            }
<<<<<<< Updated upstream
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
=======
            else{
                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();

                switch (tagKey)
                {
                    case Actor_Name:
                        //Debug.Log("name=" + tagValue);
                        /*if(tagValue == "None"){
                            actorName.enabled = false;
                        }else{
                            actorName.enabled = true;
                            actorName.text = tagValue;
                        }*/
                        break;
                    case Actor_Image:
                        //Debug.Log("image=" + tagValue);
                        if(tagValue == "None"){
                            actorImage.enabled = false;
                        }else{
                            actorImage.enabled = true;
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
                    case "path":
                        Debug.Log("Path=" + tagValue);
                        switch(tagValue){
                            case "A":
                                gm.Apoints += 1;
                                break;
                            case "B":
                                gm.Bpoints += 1;
                                break;
                            case "C":
                                gm.Cpoints += 1;
                                break;
                            case "D":
                                gm.Dpoints += 1;
                                break;
                            default:
                                Debug.LogWarning("El camino seleccionado tiene algún problema. Camino: " + tagValue);
                                break;
                        }
                        break;
                    default:
                        Debug.LogWarning("Tag no válidad: " + tag);
                        break;
                }
            }
            
>>>>>>> Stashed changes
        }
    }

    public void NextMessage(){
<<<<<<< Updated upstream
        if(currentStory.canContinue){
            DisplayMessage();
        }
        else{
            skiping = false;
            CloseDialog();
        }
    }

    public void SkipDialog(){
        skiping = true;
        while(skiping){
            NextMessage();
        }
    }
=======
        if(!paused){
            if(hasChoices){
                skiping = false;
                displayChoices();
                holeScreenNextButton.SetActive(false);
            }
            else if(currentStory.canContinue){
                if(mode == DialogMode.AUTO && !allTyped){
                    ChangeAuto();
                }
                DisplayMessage();
                if(!holeScreenNextButton.activeInHierarchy && !skiping && mode != DialogMode.AUTO) holeScreenNextButton.SetActive(true);
            }
            else{
                skiping = false;
                //gm.printPoints();
                CloseDialog();
            }
        }
        else if(!allTyped){
            DisplayMessage();
        }
        //Debug.Log("Next");
    }

    void displayChoices(){
        //isChoosing = true;
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length){
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        messageText.text = "";

        int i = 0;
        foreach(Choice choice in currentChoices){
            choices[i].gameObject.SetActive(true);
            choicesText[i].text = choice.text;
            i++;
        }
        hideChoices(i);
    }

    public void MakeChoice(int choiceIndex){
        currentStory.ChooseChoiceIndex(choiceIndex);
        hasChoices = false;
        hideChoices(0);
        
        addPoint(choiceIndex);

        NextMessage();
        Debug.Log("Choice made");
    }

    void hideChoices(int start){
        for (int i = start; i < choices.Length; i++){
            choices[i].gameObject.SetActive(false);
        }
    }

    void addPoint(int path){
        switch(path){
            case 0:
                gm.Apoints += 1;
            break;
            case 1:
                gm.Bpoints += 1;
            break;
            case 2:
                gm.Cpoints += 1;
            break;
            case 3:
                gm.Dpoints += 1;
            break;
            default:
                Debug.LogWarning("The path chosen does not have a corresponding game story line");
            break;
        }
        gm.printPoints();
    }

    public void SkipDialog(){
        if(!paused){
            skiping = true;
            if(hasChoices){
                MakeChoice(0);
            }
            holeScreenNextButton.SetActive(false);
            while(skiping){
                NextMessage();
            }
        }
        else Debug.LogWarning("Skip not valid. Game is paused.");
        
    }

    public void PauseDialog(bool pause){
        paused = pause;
        if(!pause && mode == DialogMode.AUTO){
            NextMessage();
        }
    }
    
    public void ChangeAuto(){
        if(mode == DialogMode.NORMAL){
            mode = DialogMode.AUTO;
            dialogModeText.text = "Manual";
            holeScreenNextButton.SetActive(false);
            if(allTyped) NextMessage();
        }else if (mode == DialogMode.AUTO){
            mode = DialogMode.NORMAL;
            dialogModeText.text = "Auto";
        }
        Debug.Log(mode);
    }
>>>>>>> Stashed changes

    void CloseDialog(){
        Debug.Log("End of story");

<<<<<<< Updated upstream
=======
        holeScreenNextButton.SetActive(false);

>>>>>>> Stashed changes
        animator.SetBool("isStarted", false);
        //isPlaying = false;
        messageText.text = "";

        //gm.SetNextLevelIndex(-1);
<<<<<<< Updated upstream
=======
        if(bifurcation) gm.SetNextLevelIndex(-2);
>>>>>>> Stashed changes

        gm.levelLoader.LoadNextLevel();
    }

    //si el texto se corresponde con un comando, hacer un switch y llamar a la función correspondiente.
    //arreglar el bug de hacer click muy rápido y se bugea el texto

}
