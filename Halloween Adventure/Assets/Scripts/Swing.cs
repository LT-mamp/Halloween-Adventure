using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Transform teleport;
    public MovementController player;
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hey " + other.gameObject);
        if(other.gameObject.tag == "Player"){
            player.ActivateSwing(teleport);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            player.DeactivateSwing();
        }
    }
}
