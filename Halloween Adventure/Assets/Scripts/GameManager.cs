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

public class GameManager : MonoBehaviour
{
    [Header("LevelLoader")]
    public LevelLoader levelLoader;

    [Header("Player")]
    public bool[] isMechanicActive = new bool[5];

    [Header("World elements")]
    [SerializeField] bool isPlatformLevel = true;
    public GameObject world;
    //public bool isLookingToZ = true;

    [Header("User Interface")]
    [SerializeField] TextMeshProUGUI[] candyCount = new TextMeshProUGUI[5];
    [SerializeField] Image[] candyImage;
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

    public void ActivateMechanik(int mechanik, bool activate){
        if(mechanik >= isMechanicActive.Length){
            Debug.LogWarning("El índice para activar/desactivar mecánica no es válido");
            return;
        }
        isMechanicActive[mechanik] = activate;
    }
}
