using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelIndex = -1;
    public Animator transition;
    public float transitionTime = 1f;
    public AudioSource bg_music;
    
    void Start()
    {
        if (levelIndex == -1){
            levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");

        if(bg_music != null){
            //fadeoff
            yield return StartCoroutine(StartFade(bg_music, 2f, 0f));
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

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
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
