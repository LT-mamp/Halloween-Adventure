using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public DataPersistanceManager dpm;
    public int levelIndex = -1;
    public string sceneName = "";
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] AudioManager audioManager;

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

        if(audioManager != null && audioManager.bgMusicSource.Length > 0){
            //fadeoff
            yield return StartCoroutine(StartFade(audioManager.bgMusicSource[0], 2f, 0f));
        }
        //Data[] dataNames = getDataNamesForSaving();
        //float[] newValues = getNewDataValuesForSaving();

        yield return new WaitForSeconds(transitionTime);
        
        //dpm.SaveSpecificData(dataNames, newValues);

        if(sceneName == "") SceneManager.LoadScene(levelIndex);
        else{
            SceneManager.LoadScene(sceneName);
            sceneName = "";
        }
        dpm.LoadGame();
    }

    static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        if(audioSource != null){
            float start = audioSource.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
        }
        
        yield break;
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
