using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraDeMiedo : MonoBehaviour
{
    public float fearBar = 0.0f;
    [SerializeField] public float maxFearBar = 100f;
    PlayerInteract pInteract;
    public Flashlight scriptFlash;

    private sceneExit getStrings;
    public string sceneToLoad;
    public string exitName;

    public bool demonAlive = false;

    void Start()
    {
        pInteract = GameObject.FindWithTag("MainCamera").GetComponent<PlayerInteract>();
        scriptFlash = pInteract.scriptFlash;
        getStrings = GameObject.FindWithTag("Door").GetComponent<sceneExit>();
    }
    private void Update()
    {
        sceneToLoad = getStrings.sceneToLoad;
        exitName = getStrings.exitName;
        if(demonAlive)
        {
            reaparecer();
            reduceLifeBar();  
        }
    }

    private void reaparecer()
    {
        if (fearBar >= maxFearBar)
        {
            ExitLevel();
        }
    }

    private void reduceLifeBar()
    {
        float tF = scriptFlash.timeNotFlashing;
        if (tF > 0)
        {
            scriptFlash.timeNotFlashing = 0.0f;
            fearBar += (3*tF);
        }
    }

    private void ExitLevel(){
        PlayerPrefs.SetString("LastExitName",exitName);
        SceneManager.LoadScene(sceneToLoad);
        demonAlive = false;
    }

}
