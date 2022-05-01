using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] string fileName;

<<<<<<< Updated upstream
=======
    [Header("Confirmation Box")]
    [SerializeField] GameObject confirmationBox;

>>>>>>> Stashed changes
    public static DataPersistanceManager instance  { get; private set;  }

    GameData gameData;
    List<IDataPersistance> dataPersistanceObjects;
    
    FileDataHandler dataHandler;

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    private void Awake(){
        if (instance != null){
            Debug.LogError("Found more than one Data Persistance Manager in the scene.");
        }
        instance = this;
    }

    private void Start() {
<<<<<<< Updated upstream
    this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame(){
=======
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        if(confirmationBox != null) confirmationBox.SetActive(false);
        else Debug.Log("No confirmation box assigned to the DataPersistanceManager");
        LoadGame();
    }

    public void NewGame(bool confirmation){
        if(this.gameData != null && !confirmation){
            //are you sure?
            confirmationBox.SetActive(true);
        }
>>>>>>> Stashed changes
        this.gameData = new GameData();
    }

    public void LoadGame(){
        //load any saved data
        this.gameData = dataHandler.Load();

        //if no data can be loaded initialize to a new game
        if(this.gameData == null){
            Debug.Log("No data found. Initializing data to defaults.");
<<<<<<< Updated upstream
            NewGame();
=======
            NewGame(true);
>>>>>>> Stashed changes
        }

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects){
            dataPersistanceObj.LoadData(gameData);
        }
        //Debug.Log("Loaded mars points: " + gameData.marsPoints);
    }

    public void SaveGame(){
        //pass the data to other scripts so they can update it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects){
            dataPersistanceObj.SaveData(ref gameData);
        }
<<<<<<< Updated upstream
        Debug.Log("Saved mars points: " + gameData.marsPoints);
=======
        //Debug.Log("Saved mars points: " + gameData.chekpoint);
>>>>>>> Stashed changes

        // save the data to a file using the data handler
        dataHandler.Save(gameData);
    }

<<<<<<< Updated upstream
=======
    public void SaveSpecificData(Data[] dataName, float[] newValue){
        for (int i = 0; i < dataName.Length; i++)
        {
            SaveSpecificData(dataName[i], newValue[i]);
        }
    }

    public void SaveSpecificData(Data dataName, float newValue){
        
        switch(dataName){
            case Data.IDIOMA:
                if(newValue == 0){
                    gameData.idioma = "EN";
                    Debug.Log(gameData.idioma);
                }else if(newValue == 1){
                    gameData.idioma = "ES";
                }
                else Debug.LogError("Trying to set new language configuration but new config is unvalid\nNew Selected config: " + newValue + ". Expected: 1 or 2");
                Debug.Log(gameData.idioma);
                break;
            case Data.BG_VOL:
                gameData.volumeBG = newValue;
                break;
            case Data.FX_VOL:
                gameData.volumeFX = newValue;
                break;
            case Data.VOICE_VOL:
                gameData.volumeVoice = newValue;
                break;
            case Data.TEXT_SPEED:
                gameData.textSpeed = newValue;
                //hace falta cargar esta info en el dialog manager
                break;
            case Data.ACTUAL_SCENE:
                break;
            case Data.CHECKPOINT:
                break;
            case Data.A_POINTS:
                break;
            case Data.B_POINTS:
                break;
            case Data.C_POINTS:
                break;
            default:
                break;
        }
    }

>>>>>>> Stashed changes
    private void OnApplicationQuit() {
        SaveGame();
    }

    List<IDataPersistance> FindAllDataPersistanceObjects(){
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();
        
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
