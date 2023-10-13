using UnityEngine;
using System.Collections;

public class Demonio: MonoBehaviour {
    [SerializeField] public float lifeBar = 0f;
    public float maxlifeBar = 100f;
    public bool isNear;
    //[SerializeField] public int nearDistance;
    [SerializeField] public int disappearTime = 10;

    [SerializeField] public float persecutionVelocity = 0.5f;
    [SerializeField] public float range = 4f;
    private int layer = 8;
    private int interactLayers;
    private Transform player;
    private bool checkIsNear;

    public GameObject PIntObj; //settear en unity
    public PlayerInteract scriptPInteract;
    public Flashlight scriptFlash;
    private GameObject roomDoor;
    private Collider dCollider;
    //acceso a script BarraDeMiedo

    private BarraDeMiedo bMiedo;


    void Start()
    {   
        PIntObj = GameObject.FindWithTag("MainCamera");
        roomDoor = GameObject.FindWithTag("Door");
        player = PIntObj.GetComponent<Transform>();
        scriptPInteract = PIntObj.GetComponent<PlayerInteract>();
        dCollider = roomDoor.GetComponent<Collider>();
        dCollider.isTrigger = false;
    
        bMiedo = GameObject.FindWithTag("Player").GetComponent<BarraDeMiedo>();

        scriptFlash = GameObject.FindWithTag("Linterna").GetComponent<Flashlight>();

        isNear = false;
        interactLayers = (1 << layer);
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
            bMiedo.demonAlive = true;
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
        checkIsNear = Physics.CheckSphere(transform.position, range, interactLayers);
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
            lifeBar += (3*tF); //posible error x no definir valor de lifeBar
        }
    }
    void killDemon()
    {
        //scriptKey.getKey();
        //animacion
        //create/render note/key
        dCollider.isTrigger = true;
        gameObject.SetActive(false);
        //destruir objeto
    }
}
