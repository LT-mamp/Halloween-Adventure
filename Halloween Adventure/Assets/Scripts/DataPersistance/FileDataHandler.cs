using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    string dataDirPath = "";
    string dataFileName = "SavedData";

    public FileDataHandler(string dataDirPath, string dataFileName){
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load(){
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if(File.Exists(fullPath)){
            try
            {
                //load the serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open)){
                    using(StreamReader reader = new StreamReader(stream)){
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //deserialize tha data from json into the c# object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Ha ocurrido un error al intentar recuperar los datos guardados en: " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData data){
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try{
            // crear el directorio si no existe
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the c# game data object into json
            string dataToStore = JsonUtility.ToJson(data, true);

            //write the serialized data to the file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using(StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Ha ocurrido un error al intentar guardar los datos en: " + fullPath + "\n" + e);
        }
        Debug.Log(fullPath);
    }
}
