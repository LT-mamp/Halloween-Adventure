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
    //public GameObject endTrigger;
    //public bool endEjeX = true;

    public bool gamePaused = false;

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
    int stage = 0;
    bool end = false;

    [Header("World elements")]
    public bool isPlatformLevel = true;
    public GameObject world;
    //public bool isLookingToZ = true;

    [Header("User Interface")]
    [SerializeField] TextMeshProUGUI[] candyCount = new TextMeshProUGUI[5];
    [SerializeField] Image[] candyImage; 
    [SerializeField] GameObject[] candyOnUse = new GameObject[5];
    //public TextMeshProUGUI[]  activeCandyPrototipo = new TextMeshProUGUI[5];
    //public List<Candy> activeCandy;
    [Header("Cursor")]
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    GameObject objetosEnPlanoX;
    GameObject objetosEnPlanoZ;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
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
            if(scene3 != "" && end){
                nextName = scene3;
            }
            else{
                stage++;
                if(stage==1){
                    //primer bifur
                    if(Apoints > Dpoints){
                        nextName = scene1;
                    }else{
                        nextName = scene2;
                        end = true;
                    }
                }else if(stage==2){
                    if(Apoints-Dpoints+Bpoints-Cpoints > Cpoints){
                        nextName = scene1;
                    }else{
                        nextName = scene2;
                    }
                }else if(stage==3){
                    if(Apoints > Bpoints){
                        nextName = scene1;
                    }else if(Bpoints > Cpoints){
                        nextName = scene2;
                    }else{
                        nextName = scene3;
                    }
                }else {
                    Debug.Log("Stage : " + stage);
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
        Debug.Log("THIS = " + SceneManager.GetActiveScene().buildIndex + "\nNEXT = " + levelLoader.levelIndex);
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
            Debug.LogWarning("El ??ndice del plano a des/activar no es correcto. PlanoX = 1, planoZ = 2.");
        }
        //endTrigger.SetActive(false);
    }

    private GameObject getChildWithName(string childName, GameObject parent){
        Transform child;
        child = parent.transform.Find(childName);
        if (child != null) return child.gameObject;
        Debug.LogWarning("No se ha encontrado el objeto con el nombre \"" + childName + "\".");
        return null;
    }

    //funci??n para actualizar la ui
    public void AddCandy(Candy candyType, int cantidad){
        int actual = int.Parse(candyCount[(int)candyType].text);
        actual += cantidad;
        candyCount[(int)candyType].text = actual.ToString("00");

        if(actual > 0 && !isMechanicActive[(int)candyType]){
            ActivateMechanik((int)candyType, true);

        }
    }

    public void SetCandyOnUse(Candy candyType, bool active){
        candyOnUse[(int)candyType].SetActive(active);
    }

    public void ActivateMechanik(int mechanik, bool activate){
        if(mechanik >= isMechanicActive.Length){
            Debug.LogWarning("El ??ndice para activar/desactivar mec??nica no es v??lido");
            return;
        }
        isMechanicActive[mechanik] = activate;
    }

    public void ResumeGame(bool pause){
        gamePaused = pause;
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
