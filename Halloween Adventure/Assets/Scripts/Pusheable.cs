using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusheable : MonoBehaviour
{
    public float moveSpeed = 5;
    bool pushed = false;
    bool pusheable = false;
    int xAxe = 0;
    int zAxe = 1;
    int axe = 0;
    float direction = 0;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            if(other.gameObject.GetComponent<MovementController>().isLookingToZ){
                axe = zAxe;
            }else{
                axe = xAxe;
            }

            pushed = true;
            Debug.Log("Pusheable");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            pushed = false;
        }
    }

    public void UpdatePusheable(bool enabled){
        pusheable = enabled;
        Debug.Log("Pusheable enabled: " + enabled);
    }

    public void UpdateDirection(float dir){
        direction = dir;
        Debug.Log("New direction = " + dir);
    }

    private void Update() {
        if(pushed && pusheable){
            Debug.Log("Pushing");
            Vector3 newPosition = this.transform.position;
            if(axe == xAxe){
                newPosition.x += direction * moveSpeed * Time.deltaTime;
            }
            else{
                newPosition.z += direction * moveSpeed * Time.deltaTime;
            }

            this.transform.position = newPosition;
        }
    }
}
