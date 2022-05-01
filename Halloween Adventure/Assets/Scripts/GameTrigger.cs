using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTrigger : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] int nextLevel;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Heya");
        if(other.gameObject.tag == "Player"){
            if(this.tag == "Finish"){
                gm.FinishLevel(nextLevel);
            }
            else{
                Debug.Log("You died");
                //other.gameObject.transform.position = startAgain.position;
                gm.SetNextLevelIndex(SceneManager.GetActiveScene().buildIndex);
                gm.levelLoader.LoadNextLevel();
            }
        }
    }
}
