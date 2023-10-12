using UnityEngine;
using System.Collections;

public class Demonio: MonoBehaviour {
    [SerializeField] public float lifeBar = 100f;
    public bool isNear;
    //[SerializeField] public int nearDistance;
    [SerializeField] public int disappearTime = 3;

    [SerializeField] public float persecutionVelocity = 0.5f;
    [SerializeField] public float range = 3.0f;

    public LayerMask playerMask;
    private Transform player;
    private bool checkIsNear;

    public GameObject PIntObj; //settear en unity
    public PlayerInteract scriptPInteract;
    public Flashlight scriptFlash;
    private GameObject roomDoor;
    private Collider dCollider;
    private BarraDeMiedo scriptExitScene;
    Key scriptKey;
    //acceso a script BarraDeMiedo

    void Start()
    {   
        PIntObj = GameObject.FindWithTag("MainCamera");
        roomDoor = GameObject.FindWithTag("Door");
        player = PIntObj.GetComponent<Transform>();
        scriptPInteract = PIntObj.GetComponent<PlayerInteract>();
        scriptExitScene = PIntObj.GetComponent<BarraDeMiedo>();
        dCollider = roomDoor.GetComponent<Collider>();
        dCollider.isTrigger = false;

        scriptFlash = GameObject.FindWithTag("Linterna").GetComponent<Flashlight>();
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
            //showLifeBar();
        }
        else if(disappearTime <= 0)
        {
            killDemon();
        }
    }
    
    bool checkIsAlive()
    {
       if(lifeBar <= 0)
       {
            disappear();
            return false;
       }
       return true;
    }
    void disappear()
    {
        disappearTime -= 1;
        //reducir visibilidad del render del demonio
    }
    void followPlayer()
    {
        checkIsNear = Physics.CheckSphere(transform.position,range,playerMask);
        Vector3 playerPos = new Vector3(player.position.x,transform.position.y,player.position.z);
        transform.LookAt(playerPos);

        if(checkIsNear == false)
        {
        transform.position = Vector3.MoveTowards(transform.position,playerPos,persecutionVelocity * Time.deltaTime);
        }
    }
    void reduceLifeBar()
    {
        float tF = scriptFlash.timeFlashing;
        if(tF > 0)
        {
            scriptFlash.timeFlashing = 0.0f;
            lifeBar -= (2*tF); //posible error x no definir valor de lifeBar
        }
    }
    void killDemon()
    {
        //scriptKey.getKey();
        Debug.Log("El demonio ha desaparecido.");
        //animacion
        //create/render note/key
        dCollider.isTrigger = true;
        scriptExitScene.demonAlive = dCollider;
        //destruir objeto
    }
}
