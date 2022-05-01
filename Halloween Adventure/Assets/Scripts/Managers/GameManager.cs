using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum Candy {
    Soul,
    Mars,
    Leo,
    Lima,
    Tibo
}

public class GameManager : MonoBehaviour, IDataPersistance
{

    [Header("LevelLoader")]
    public LevelLoader levelLoader;

    [Header("Scenes")]
    public string scene1;
    public string scene2;
    public string scene3;

    [Header("Player")]
    public bool[] isMechanicActive = new bool[5];
    [HideInInspector] public int Apoints;
    [HideInInspector] public int Bpoints;
    [HideInInspector] public int Cpoints;
    [HideInInspector] public int Dpoints;

    [Header("World elements")]
    [SerializeField] bool isPlatformLevel = true;
    public GameObject world;
    //public bool isLookingToZ = true;

    [Header("User Interface")]
    [SerializeField] TextMeshProUGUI[] candyCount = new TextMeshProUGUI[5];
    [SerializeField] Image[] candyImage; 
    [SerializeField] TextMeshProUGUI[] candyOnUse = new TextMeshProUGUI[5];
    //public TextMeshProUGUI[]  activeCandyPrototipo = new TextMeshProUGUI[5];
    //public List<Candy> activeCandy;


    GameObject objetosEnPlanoX;
    GameObject objetosEnPlanoZ;

    // Start is called before the first frame update
    void Start()
    {
        if(isPlatformLevel){
            for (int i = 0; i < candyCount.Length; i++)
            {
                candyCount[i].text = "00";
            }
        }
    }

    public void FinishLevel(int nextLevel){
        if(nextLevel == -2){
            string nextName = "";
            if(scene3 != ""){
                nextName = scene3;
            }
            else{
                int totalPoints = Apoints+Bpoints+Cpoints+Dpoints;
                if(totalPoints <= 5){
                    //primer bifur
                    if(Apoints > Dpoints){
                        nextName = scene1;
                    }else{
                        nextName = scene2;
                    }
                }else if(totalPoints == 6){
                    if(Apoints-Dpoints > Cpoints){
                        nextName = scene1;
                    }else{
                        nextName = scene2;
                    }
                }else if(totalPoints == 7){
                    if(Apoints-Dpoints-Cpoints > Bpoints){
                        nextName = scene1;
                    }else{
                        nextLevel = -1;
                    }
                }
            }
            
            levelLoader.sceneName = nextName;
        }else{
            SetNextLevelIndex(nextLevel);
        }
        
        levelLoader.LoadNextLevel();
    }

    public void LoadMainScene(){
        SetNextLevelIndex(0);

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

    public void ActivarElementosEnPlano(int plano, bool activar){
        if(plano == 1){
            if(objetosEnPlanoX == null){
                //guardar el hijo de allPlatforms con el nombre "X"
                objetosEnPlanoX = getChildWithName("PlanoX", world);
            }
            objetosEnPlanoX.SetActive(activar);
        }else if(plano == 2){
            if(objetosEnPlanoZ == null){
                //guardar el hijo de allPlatforms con el nombre "X"
                objetosEnPlanoZ = getChildWithName("PlanoZ", world);
            }
            objetosEnPlanoZ.SetActive(activar);
        }else{
            Debug.LogWarning("El índice del plano a des/activar no es correcto. PlanoX = 1, planoZ = 2.");
        }
    }

    private GameObject getChildWithName(string childName, GameObject parent){
        Transform child;
        child = parent.transform.Find(childName);
        if (child != null) return child.gameObject;
        Debug.LogWarning("No se ha encontrado el objeto con el nombre \"" + childName + "\".");
        return null;
    }

    //función para actualizar la ui
    public void AddCandy(Candy candyType, int cantidad){
        int actual = int.Parse(candyCount[(int)candyType].text);
        actual += cantidad;
        candyCount[(int)candyType].text = actual.ToString("00");

        if(actual > 0 && !isMechanicActive[(int)candyType]){
            ActivateMechanik((int)candyType, true);

        }
    }

    public void SetCandyOnUse(Candy candyType, bool active){
        candyOnUse[(int)candyType].gameObject.SetActive(active);
    }

    public void ActivateMechanik(int mechanik, bool activate){
        if(mechanik >= isMechanicActive.Length){
            Debug.LogWarning("El índice para activar/desactivar mecánica no es válido");
            return;
        }
        isMechanicActive[mechanik] = activate;
    }

    public void printPoints(){
        Debug.Log("A" + Apoints + ", B" + Bpoints + ", C" + Cpoints + ", D" + Dpoints);
    }

    public void LoadData(GameData data){
        Apoints = data.Apoints;
        Bpoints = data.Bpoints;
        Cpoints = data.Cpoints;
        Dpoints = data.Dpoints;
        Debug.Log("Loading: ");
        printPoints();
    }

    public void SaveData(ref GameData data){
        data.Apoints = Apoints;
        data.Bpoints = Bpoints;
        data.Cpoints = Cpoints;
        data.Dpoints = Dpoints;

        //Debug.Log("Saving:");
        //printPoints();
    }
}
