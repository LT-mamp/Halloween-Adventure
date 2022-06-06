using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActors : MonoBehaviour
{
    public List<string> codes;
    public Sprite[] images;

    public Sprite GetActorImage(string code){
        Sprite image = null;
        int index = codes.IndexOf(code);
        if(index >= 0){
            image = images[index];
        }
        else{
            Debug.LogWarning("DialogActors no ha podido devolver el sprite correspondiete a: " + code);
            image = images[2];
        }

        return image;
    }
}
