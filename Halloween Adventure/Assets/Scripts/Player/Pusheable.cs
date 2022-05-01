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

    Rigidbody2D rb;
    [SerializeField] Rigidbody2D rbConstrained;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        //rbConstrained = new Rigidbody2D();
        //rbConstrained.constraints = fr
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Hello?");
        if(other.gameObject.tag == "Player"){
            if(other.gameObject.GetComponent<MovementController>().isLookingToZ){
                axe = zAxe;
            }else{
                axe = xAxe;
            }

            pushed = true;
            //Debug.Log("Pusheable");
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
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
        //Vector3 newPosition = this.transform.position;

        if(pushed && pusheable){
            if(rb.constraints != RigidbodyConstraints2D.FreezeRotation) rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            //Debug.Log("Pushing");
            if(axe == xAxe){
                //newPosition.x += direction * moveSpeed * Time.deltaTime;
            }
            else{
                //newPosition.z += direction * moveSpeed * Time.deltaTime;
            }
        }
        else {
            if(rb.constraints == RigidbodyConstraints2D.FreezeRotation) {
                //rb.constraints &= RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = rbConstrained.constraints;
                Debug.Log("CHAN");
            }
        }
        
        //this.transform.position = newPosition;
    }
}
