using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Transform teleport;
    public MovementController player;
    
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            player.ActivateSwing(teleport);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            player.DeactivateSwing();
        }
    }
}
