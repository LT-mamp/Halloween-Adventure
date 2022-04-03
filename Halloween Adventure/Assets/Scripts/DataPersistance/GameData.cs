using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //variables públicas de los datos que se quieran guardar
    /*
    camino en la narrativa:
    marspoints, leo points, ...
    current level
    si la parte de visual novel es muy larga: hacer checkpoints y entonces ver el último chekpoint donde se queda
    */
    //ejemplo:
    public int marsPoints;

    //default values
    public GameData(){
        this.marsPoints = 0;
    }
}
