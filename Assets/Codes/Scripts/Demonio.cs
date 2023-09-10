using UnityEngine;
using System.Collections;

public class Demonio: MonoBehaviour {
    [SerializeField] public float lifeBar;
    public bool isNear;

    //[SerializeField] public int nearDistance;
    [SerializeField] public int disappearTime;

    public GameObject PIntObj; //settear en unity
    PlayerInteract scriptPInteract;
    Flashlight scriptFlash;
    Key scriptKey;
    //acceso a script BarraDeMiedo

    void Start()
    {   
        scriptPInteract = PIntObj.GetComponent<PlayerInteract>()
        scriptPInteract.doorCollider.isTrigger = false; //hacer lo mismo con los puzzles

        scriptFlash = scriptPInteract.scriptFlash;
        scriptKey = scriptPInteract.scriptKey;

        isNear = false;
    }

    void Update()
    {
        if(checkIsAlive())
        {
            //checkIsNear(); por ahora no
            reduceLifeBar();
            followPlayer();
            showLifeBar();
        }
        else if(disappearTime <= 0)
        {
            killDemon();
        }
    }
    
    void reduceLifeBar()
    {
        float tF = scriptFlash.timeFlashing;
        if(tF > 0)
        {
            scriptFlash.timeFlashing = 0.0f;
            lifeBar -= tF; //posible error x no definir valor de lifeBar
        }
    }

    bool checkIsAlive()
    {
       if(lifeBar <= 0)
       {
            disappearTime -= 1;
            return false;
       }
       return true;
    }

    void killDemon()
    {
        scriptKey.getKey();
        Debug.Log("El demonio ha desaparecido.");
        //reaparecer afuera
        //destruir objeto
    }
}