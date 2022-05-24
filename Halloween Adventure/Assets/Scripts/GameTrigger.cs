using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTrigger : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] int nextLevel;

    bool inside = false;

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Heya");
        if(other.gameObject.tag == "Player"){
            if(this.tag == "Finish"){
                inside = true;
                StartCoroutine(endLevel());
            }
            else if(this.tag == "mechanicAtivator"){
                gm.isMechanicActive[0] = true;
            }
            else{
                Debug.Log("You died");
                //other.gameObject.transform.position = startAgain.position;
                gm.SetNextLevelIndex(SceneManager.GetActiveScene().buildIndex);
                gm.levelLoader.LoadNextLevel();
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(this.tag == "Finish"){
                Debug.Log("Exit of ending trigger");
                inside = false;
            }
            else if(this.tag == "mechanicAtivator"){
                gm.isMechanicActive[0] = false;
            }
        }
    }

    IEnumerator endLevel(){
        yield return new WaitForSeconds(0.5f);
        if(inside){
            gm.FinishLevel(nextLevel);
        }
    }
}
