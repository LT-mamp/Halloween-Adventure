using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.SceneManagement;
>>>>>>> Stashed changes

public class GameTrigger : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] int nextLevel;
    //temporal
<<<<<<< Updated upstream
    [SerializeField] int levelToReload;
=======
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Heya");
        if(other.gameObject.tag == "Player"){
            if(this.tag == "Finish"){
                gm.FinishLevel(nextLevel);
            }
            else{
                Debug.Log("You died");
                //other.gameObject.transform.position = startAgain.position;
<<<<<<< Updated upstream
                gm.SetNextLevelIndex(levelToReload);
=======
                gm.SetNextLevelIndex(SceneManager.GetActiveScene().buildIndex);
>>>>>>> Stashed changes
                gm.levelLoader.LoadNextLevel();
            }
        }
    }
}
