using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Candy candyType;
    public GameManager gm;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            //Debug.Log("Kaching! You got +1 " + candyType + " candy.");
            gm.AddCandy(candyType, +1);
            
            this.gameObject.SetActive(false);
        }
    }
}