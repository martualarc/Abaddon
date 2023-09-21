using UnityEngine;
using System.Collections;

public class Demonio: MonoBehaviour {
    [SerializeField] public float lifeBar;
    public bool isNear;
    //[SerializeField] public int nearDistance;
    [SerializeField] public int disappearTime = 3;

    [SerializeField] public float persecutionVelocity = 2.0f;
    public float tempVelocity;
    [SerializeField] public float minDistance = 1.5f;
    Vector3 playerDirection;
    
    public GameObject PIntObj; //settear en unity
    public PlayerInteract scriptPInteract;
    public Flashlight scriptFlash;
    Key scriptKey;
    //acceso a script BarraDeMiedo

    void Start()
    {   
        scriptPInteract = PIntObj.GetComponent<PlayerInteract>();
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
            //followPlayer();
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
   /* void followPlayer()
    {
        playerDirection = scriptPInteract.transform - transform.position;
        playerDirection.y = 0; // Ignora la componente vertical
        if (playerDirection.magnitude < minDistance)
        {
            tempVelocity = tempVelocity * 0.8f;
        }
        else
        {
            tempVelocity = persecutionVelocity;
        }
        transform.Translate(playerDirection * tempVelocity * Time.deltaTime, Space.World);
        // La velocidad se multiplica por Time.deltaTime para hacerlo frame rate independiente (que en 30 fps no sea mas facil)
        if (direccionAlJugador != Vector3.zero) //Ver si funciona: mirar hacia la dirección del jugador
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection), 0.1f);
        }
    }*/
    void reduceLifeBar()
    {
        float tF = scriptFlash.timeFlashing;
        if(tF > 0)
        {
            scriptFlash.timeFlashing = 0.0f;
            lifeBar -= tF; //posible error x no definir valor de lifeBar
        }
    }
    void killDemon()
    {
        scriptKey.getKey();
        Debug.Log("El demonio ha desaparecido.");
        //animacion
        //create/render note/key
        //destruir objeto
    }
}
