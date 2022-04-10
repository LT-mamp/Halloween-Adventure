using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelIndex = -1;
    public Animator transition;
    public float transitionTime = 1f;
    
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

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
