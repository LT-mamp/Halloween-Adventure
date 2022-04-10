using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("LevelLoader")]
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishLevel(int nextLevel){
        SetNextLevelIndex(nextLevel);
        
        levelLoader.LoadNextLevel();
    }

    /// <summary>
    /// Set the buildIndex of the next scene to load. 
    /// index = -1 means that the index will be the active scene's + 1
    /// </summary>
    public void SetNextLevelIndex(int index){
        if (index == -1){
            levelLoader.levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }else{
            levelLoader.levelIndex = index;
        }
    }
}
