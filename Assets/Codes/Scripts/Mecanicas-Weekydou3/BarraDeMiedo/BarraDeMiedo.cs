using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraDeMiedo : MonoBehaviour
{
    public float fearBar = 0.0f;
    [SerializeField] public float maxFearBar = 10.0f;
    GameObject thisObj;
    public Flashlight scriptFlash;
    public PlayerInteract scriptPInt;

    public string sceneToLoad;
    public string exitName;

    public Collider demonAlive;

    void Start()
    {
        thisObj = this.gameObject;
        scriptPInt = thisObj.GetComponent<PlayerInteract>();
        scriptFlash = scriptPInt.scriptFlash;
    }
    private void Update()
    {
        if(demonAlive==null)
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
            fearBar += tF;
        }
    }

    private void ExitLevel(){
        PlayerPrefs.SetString("LastExitName",exitName);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col==demonAlive)
        {
            scriptPInt.doorCollider.isTrigger = false;
            ExitLevel();
        }
    }
}
