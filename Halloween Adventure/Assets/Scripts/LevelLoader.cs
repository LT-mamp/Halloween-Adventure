using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
<<<<<<< Updated upstream
    public int levelIndex = -1;
    public Animator transition;
    public float transitionTime = 1f;
    public AudioSource bg_music;
    
=======
<<<<<<< Updated upstream
    public int index = 0;
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
=======
    public DataPersistanceManager dpm;
    public int levelIndex = -1;
    public string sceneName = "";
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] AudioManager audioManager;
    
    
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    void Start()
    {
        if (levelIndex == -1){
            levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
        //load all data
    }

    public void RestartLevel(){
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        LoadNextLevel();
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");
        dpm.SaveGame();

<<<<<<< Updated upstream
        if(bg_music != null){
            //fadeoff
            yield return StartCoroutine(StartFade(bg_music, 2f, 0f));
        }

=======
<<<<<<< Updated upstream
=======
        if(audioManager != null && audioManager.bgMusicSource.Length > 0){
            //fadeoff
            yield return StartCoroutine(StartFade(audioManager.bgMusicSource[0], 2f, 0f));
        }
        //Data[] dataNames = getDataNamesForSaving();
        //float[] newValues = getNewDataValuesForSaving();

>>>>>>> Stashed changes
>>>>>>> Stashed changes
        yield return new WaitForSeconds(transitionTime);
        
        //dpm.SaveSpecificData(dataNames, newValues);

<<<<<<< Updated upstream
        SceneManager.LoadScene(levelIndex);
    }
=======
<<<<<<< Updated upstream
        SceneManager.LoadScene(index);
=======
        if(sceneName == "") SceneManager.LoadScene(levelIndex);
        else{
            SceneManager.LoadScene(sceneName);
            sceneName = "";
        }
        dpm.LoadGame();
    }
    

    /*Data[] getDataNamesForSaving(){
        Data[] names = new Data[5];
        //Data[] names = new Data[2];
        names[0] = Data.ACTUAL_SCENE;
        names[1] = Data.CHECKPOINT;
        names[2] = Data.A_POINTS;
        names[3] = Data.B_POINTS;
        names[4] = Data.C_POINTS;

        return names;
    }*/

    /*float[] getNewDataValuesForSaving(){
        float[] v = new float[5];
        //float[] v = new float[2];
        v[0] = levelIndex;
        v[1] = -1;
        v[2] = Apoints;
        v[3] = Bpoints;
        v[4] = Cpoints;
        
        return v;
    }*/
>>>>>>> Stashed changes

    static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
