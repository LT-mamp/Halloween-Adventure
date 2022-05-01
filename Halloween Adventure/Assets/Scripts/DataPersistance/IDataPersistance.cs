using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance 
{
    void LoadData(GameData data);

    void SaveData(ref GameData data);

    //to use this in other clases ponerlo destrás de monobehaviour, IDataPersistance
    //luego añadir los dos métodos de arriba PUBLICAS
    //con el ejemplo de marspoints:
    /*
<<<<<<< Updated upstream
    en la funcion de load pones: this.marsPoints = data.marsPoints
    en la funcion de save: data.marsPoints = this.marsPoints
    */
=======
        en la funcion de load pones: this.marsPoints = data.marsPoints
        en la funcion de save: data.marsPoints = this.marsPoints
    */
    //esto lo que hace es que cambia los datos en el archivo de guardado
>>>>>>> Stashed changes
}
