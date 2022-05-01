using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //variables públicas de los datos que se quieran guardar
<<<<<<< Updated upstream
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
=======
    [Header("Game Settings")]
    public string idioma;
    public float volumeBG;
    public float volumeFX;
    public float volumeVoice;
    public float textSpeed;

    [Header("Game Progress")]
    public int actualScene;
    public int chekpoint;
    public int Apoints;
    public int Bpoints;
    public int Cpoints;
    public int Dpoints;

    [Header("Player Achivements")]
    public List<string> achivementsNames;

    //default values
    public GameData(){
        this.idioma = "EN";
        this.volumeBG = .8f;
        this.volumeFX = .8f;
        this.volumeVoice = 1f;
        this.textSpeed = 0.05f;

        this.actualScene = 1;
        this.chekpoint = -1;
        this.Apoints = 0;
        this.Bpoints = 0;
        this.Cpoints = 0;
        this.Dpoints = 0;

        achivementsNames = new List<string>();
    }
}

public enum Data {
    IDIOMA ,
    BG_VOL,
    FX_VOL,
    VOICE_VOL,
    TEXT_SPEED,
    ACTUAL_SCENE,
    CHECKPOINT,
    A_POINTS,
    B_POINTS,
    C_POINTS,
    D_POINTS,
    ACHIVEMENTS
}
>>>>>>> Stashed changes
