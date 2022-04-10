using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Heya");
        if(other.gameObject.tag == "Player"){
            if(this.tag == "Finish"){
                gm.FinishLevel(nextLevel);
            }
        }
    }
}
