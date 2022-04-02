using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int index = 0;
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Start()
    {
        if (index == 0){
            index = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
