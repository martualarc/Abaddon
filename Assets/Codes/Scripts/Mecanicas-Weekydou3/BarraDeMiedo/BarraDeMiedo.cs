using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraDeMiedo : MonoBehaviour
{
    public float fearBar = 0.0f;
    [SerializeField] public float maxFearBar = 10.0f;
    public Flashlight scriptFlash;
    public Door scriptDoor;
    public GameObject keyObj;
    public Key scriptKey;

    public GameObject PIntObj;
    public PlayerInteract scriptPInt;

    public string sceneToLoad;
    public string exitName;

    void Start()
    {
        scriptKey = keyObj.GetComponent<Key>();
        scriptPInt = PIntObj.GetComponent<PlayerInteract>();
        scriptFlash = scriptPInt.scriptFlash;
    }
    private void Update()
    {
        reaparecer();
        reduceLifeBar();
    }

    private void reaparecer()
    {
        if (fearBar >= maxFearBar)
        {
            scriptDoor = scriptPInt.doorAccess;
            scriptDoor.isOpenable = true;
            scriptKey.keyRespawn();
            ExitLevel();
        }
    }

    private void reduceLifeBar()
    {
        float tF = scriptFlash.timeNotFlashing;
        if (tF > 0)
        {
            scriptFlash.timeNotFlashing = 0.0f;
            fearBar += tF; //posible error x no definir valor de fearBar
        }
    }

    private void ExitLevel(){
        PlayerPrefs.SetString("LastExitName",exitName);
        SceneManager.LoadScene(sceneToLoad);
    }
}
