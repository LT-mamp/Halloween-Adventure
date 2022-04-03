using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] string fileName;

    public static DataPersistanceManager instance  { get; private set;  }

    GameData gameData;
    List<IDataPersistance> dataPersistanceObjects;
    
    FileDataHandler dataHandler;

    private void Awake(){
        if (instance != null){
            Debug.LogError("Found more than one Data Persistance Manager in the scene.");
        }
        instance = this;
    }

    private void Start() {
    this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        //load any saved data
        this.gameData = dataHandler.Load();

        //if no data can be loaded initialize to a new game
        if(this.gameData == null){
            Debug.Log("No data found. Initializing data to defaults.");
            NewGame();
        }

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects){
            dataPersistanceObj.LoadData(gameData);
        }
        Debug.Log("Loaded mars points: " + gameData.marsPoints);
    }

    public void SaveGame(){
        //pass the data to other scripts so they can update it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects){
            dataPersistanceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved mars points: " + gameData.marsPoints);

        // save the data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    List<IDataPersistance> FindAllDataPersistanceObjects(){
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();
        
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
