using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("LevelLoader")]
    public LevelLoader levelLoader;

    [Header("World elements")]
    public GameObject world;
    //public bool isLookingToZ = true;

    GameObject objetosEnPlanoX;
    GameObject objetosEnPlanoZ;

    // Start is called before the first frame update
    void Start()
    {
        //objetosEnPlanoX = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishLevel(int nextLevel){
        SetNextLevelIndex(nextLevel);
        
        levelLoader.LoadNextLevel();
    }

    /// <summary>
    /// Set the buildIndex of the next scene to load. 
    /// index = -1 means that the index will be the active scene's + 1
    /// </summary>
    public void SetNextLevelIndex(int index){
        if (index == -1){
            levelLoader.levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }else{
            levelLoader.levelIndex = index;
        }
    }

    public void DesactivarElementosEnPlano(int plano){
        if(plano == 1){
            if(objetosEnPlanoX == null){
                //guardar el hijo de allPlatforms con el nombre "X"
                objetosEnPlanoX = getChildWithName("PlanoX", world);
            }
            objetosEnPlanoX.SetActive(false);
        }else if(plano == 2){
            if(objetosEnPlanoZ == null){
                //guardar el hijo de allPlatforms con el nombre "X"
                objetosEnPlanoZ = getChildWithName("PlanoZ", world);
            }
            objetosEnPlanoZ.SetActive(false);
        }else{
            Debug.LogWarning("El índice del plano a desactivar no es correcto. PlanoX = 1, planoZ = 2.");
        }
    }

    public void ActivarElementosEnPlano(int plano){
        if(plano == 1){
            if(objetosEnPlanoX == null){
                //guardar el hijo de allPlatforms con el nombre "X"
                objetosEnPlanoX = getChildWithName("PlanoX", world);
            }
            objetosEnPlanoX.SetActive(true);
        }else if(plano == 2){
            if(objetosEnPlanoZ == null){
                //guardar el hijo de allPlatforms con el nombre "X"
                objetosEnPlanoZ = getChildWithName("PlanoZ", world);
            }
            objetosEnPlanoZ.SetActive(true);
        }else{
            Debug.LogWarning("El índice del plano a activar no es correcto. PlanoX = 1, planoZ = 2.");
        }
    }

    GameObject getChildWithName(string childName, GameObject parent){
        Transform child;
        child = parent.transform.Find(childName);
        if (child != null) return child.gameObject;
        Debug.LogWarning("No se ha encontrado el objeto con el nombre \"" + childName + "\".");
        return null;
    }
}
