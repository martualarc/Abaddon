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

    public float daño = 0f;

    public float tgolpe = 2f;

    public Doubulia1 doubuliaObject;
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
        doubuliaObject = GameObject.FindGameObjectWithTag("Demon").GetComponent<Doubulia1>();
        if(demonAlive)
        {
            reaparecer();
            reduceLifeBar();  
        }
        else fearBar = 0f;
    }

    private void reaparecer()
    {
        if (fearBar >= maxFearBar)
        {
            fearBar = 0f;
            ExitLevel();
        }
    }

    private void reduceLifeBar()
    {
        if(doubuliaObject != null){
            float tF = scriptFlash.timeNotFlashing;
            if(doubuliaObject.jugadorEnVista && tF > 0){
                fearBar = Mathf.Min(fearBar + 2f * Time.deltaTime, 100f);
                if(doubuliaObject.dist < 4f){
                    tgolpe += Time.deltaTime;
                    if(tgolpe > Random.Range(0.5f, 2.5f)){
                        float rand = Random.Range(5f, 13f);
                        daño += rand;
                        fearBar = rand + fearBar;
                        tgolpe = 0f;
                    }
                }
            }
            else{
                fearBar = Mathf.Max(fearBar - 2f * Time.deltaTime, 0.01f + daño);
                daño = Mathf.Max(daño - 0.3f * Time.deltaTime, 0.01f);
            }
        }
        else{
            float tF = scriptFlash.timeNotFlashing;
            if (tF > 0)
            {
                scriptFlash.timeNotFlashing = 0.0f;
                fearBar += (3*tF);
            }
        }
    }

    private void ExitLevel(){
        PlayerPrefs.SetString("LastExitName",exitName);
        SceneManager.LoadScene(sceneToLoad);
        demonAlive = false;
    }

}
