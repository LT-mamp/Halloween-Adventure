using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public enum DialogMode{
    NORMAL,
    AUTO,
    NO_TYPPING
}

public class DialogManager1 : MonoBehaviour
{
    private static DialogManager1 instance;

    public DataPersistanceManager dpm;

    [Header("Dialogue UI")]
    [SerializeField] Image actorImage;
    [SerializeField] Animator imageAnim;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] RectTransform backgoundBox;
    [SerializeField] GameObject holeScreenNextButton;
    [SerializeField] TextMeshProUGUI dialogModeText;
    [SerializeField] DialogActors actorsImages;

    [Header("Choices UI")]
    [SerializeField] GameObject[] choices;
    [SerializeField] GameObject choicesBox;
    private TextMeshProUGUI[] choicesText;

    [Header("Backgrounds")]
    [SerializeField] GameObject[] bgs;
    int actualBg = 0;
    

    [Header("Animation")]
    public Animator animator;
    public float textSpeed = 0.05f;

    [Header("Game Manager")]
    [SerializeField] GameManager gm;
    [SerializeField] bool bifurcation = false;
    public string nextSceenName = "";

    //[Header("Story")]
    Story currentStory;
    bool hasChoices;
    //bool isPlaying;
    bool allTyped;
    string messageToDisplay;
    Coroutine typeMessage;
    bool skiping = false;
    bool paused = false;
    //bool isChoosing = false;
    DialogMode mode = DialogMode.NORMAL;

    private const string Actor_Name = "Name";
    private const string Actor_Image = "Image";
    private const string Sound_To_Play = "Sound";
    private const string Background = "bg";


    private void Awake() {
        if (instance != null){
            Debug.LogError("Found more than one Dialog Manager in the scene.");
        }
        instance = this;
    }
    
    private void Start() {
        //isPlaying = false;
        allTyped = true;

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
        //float speed = dpm.loadVNData(1);
        //setSpeed(speed);
        Debug.Log("START dialog");
    }

    private void setSpeed(float speed){
        mode = DialogMode.NORMAL;

        if(speed < 30){
            textSpeed = 0.25f;
        }else if(speed < 60){
            textSpeed = 0.05f;
        }else if(speed < 90){
            textSpeed = 0.001f;
        }else{
            mode = DialogMode.NO_TYPPING;
            //Debug.Log("NO tiping");
        }
        //Debug.Log("m " + mode);
    }
    

    /*public void ChangeDialogMode(DialogMode newMode){
        dialogMode = newMode;
    }*/

    public void OpenDialog(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        //isPlaying = true;


        Debug.Log("Inicio de conversación.");
        if(currentStory.canContinue){
            DisplayMessage();
            animator.SetBool("isStarted", true);
            holeScreenNextButton.SetActive(true);
        }
        else{
            CloseDialog();
            Debug.LogWarning("Intentando iniciar un diálgo con una historia vacía");
        }
        
    }

    void DisplayMessage(){
        if(!allTyped /*&& typeMessage != null*/){
            StopCoroutine(typeMessage);
            messageText.text = messageToDisplay;
            allTyped = true;
        }else{
            messageText.text = "";

            messageToDisplay = currentStory.Continue();

            hasChoices = (currentStory.currentChoices.Count > 0);

            if(mode == DialogMode.NO_TYPPING){
                messageText.text = messageToDisplay;
                allTyped = true;
                //Debug.Log("Mode = " + mode);
            }
            else{
                //Debug.Log("Mode = " + mode);
                allTyped = false;
                if(messageToDisplay == "" || messageToDisplay == "\n"){
                    messageToDisplay =currentStory.Continue();
                    hasChoices = (currentStory.currentChoices.Count > 0);
                }
                typeMessage = StartCoroutine(TypeMessage(messageToDisplay));
                //if(test) Debug.Log("display \"" + messageToDisplay + "\" that.");

            }

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
        if(mode == DialogMode.AUTO){
            StartCoroutine(AutoNextMessage());
        }
    }

    
    IEnumerator AutoNextMessage(){
        yield return new WaitForSeconds(1f);
        NextMessage();
    }

    void HandleTags(List<string> currentTags){ 
        foreach (string tag in currentTags)
        {
            //parse the tag
            string[] splitTag = tag.Split(':');

            if(splitTag.Length != 2){
                Debug.LogError("La tag no se ha podido leer correctamente. Tag: " + tag);
            }
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
                            actorImage.sprite = actorsImages.GetActorImage(tagValue);
                            imageAnim.SetTrigger("imageIn");
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
                    case Background:
                        //display next background
                        //init animation
                        actualBg++;
                        bgs[actualBg].SetActive(true);
                        break;
                    case "choice":
                        Debug.Log("Choice=" + tagValue);
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
            
        }
        //actorImage.enabled = false;
    }

    public void NextMessage(){
        if(!paused){
            if(hasChoices){
                if(allTyped){
                    skiping = false;
                    choicesBox.SetActive(true);
                    displayChoices();
                    holeScreenNextButton.SetActive(false);
                }
                else{
                    DisplayMessage();
                }
            }
            else if(currentStory.canContinue){
                if(mode == DialogMode.AUTO && !allTyped){
                    ChangeAuto();
                }
                choicesBox.SetActive(false);
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

    public void ChangeTextSpeed(int speed){
        setSpeed(speed);
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

    void CloseDialog(){
        Debug.Log("End of story");

        holeScreenNextButton.SetActive(false);

        animator.SetBool("isStarted", false);
        //isPlaying = false;
        messageText.text = "";

        if(!gm.isPlatformLevel){
            //gm.SetNextLevelIndex(-1);
            if(bifurcation) gm.SetNextLevelIndex(-2);

            if(nextSceenName != "") gm.levelLoader.sceneName = nextSceenName;

            gm.levelLoader.LoadNextLevel();
        }
        
    }

    //si el texto se corresponde con un comando, hacer un switch y llamar a la función correspondiente.
    //arreglar el bug de hacer click muy rápido y se bugea el texto

}
