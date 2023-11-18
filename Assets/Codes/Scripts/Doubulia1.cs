using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
public class Doubulia1 : MonoBehaviour
{
    [SerializeField]public Animator MiAnimator;
    // Start is called before the first frame update
    public Transform Objetivo;
    public Transform key;
    public float Velocidad;
    public NavMeshAgent agent;

    public float dist;
    public ParticleSystem fuego;
    public ParticleSystem explosionp;
    public Transform explosion;
    public AudioSource audioSource;
    public AudioSource explosions;

    public AudioSource resp;
    public AudioSource puerta;

    public AudioClip pasos;
    public AudioSource grito;
    // Update is called once per frame

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
    private playerMovement mov;
    public List<Transform> objetivosAleatorios; // Lista de puntos de destino secundarios
    public int objetivoActual = 0;
    public string tagObjetivo = "Puerta";
    public bool cambiandoDeObjetivo = false;
    private float tiempoEspera = 20.0f; // Tiempo para esperar antes de volver al objetivo principal
    public float tiempoEsperaActual = 0.0f;
    public bool jugadorEnVista = false;
    public float distanciaDeVision = 300.0f;
    private bool checkIsNear;

    public float dificultad;

    public GameObject PIntObj; //settear en unity
    public PlayerInteract scriptPInteract;
    public Flashlight scriptFlash;
    public fire scriptfire;
    public float tF;
    public bool fire;
    private GameObject roomDoor;
    private Collider dCollider;


    private TangibleKey tangKey;
    private BarraDeMiedo bMiedo;
    private RainEffect rainEffect;
    public float emision = 0f;
    private GameObject flame;
    
    private bool tocandoFuego = false;
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        MiAnimator = transform.GetChild(0).GetComponent<Animator>();

        PIntObj = GameObject.FindWithTag("MainCamera");
        roomDoor = GameObject.FindWithTag("Door");
        player = PIntObj.GetComponent<Transform>();
        mov = GameObject.FindWithTag("Player").GetComponent<playerMovement>();
        Objetivo = GameObject.FindWithTag("Player").GetComponent<Transform>();
        scriptPInteract = PIntObj.GetComponent<PlayerInteract>();
        dCollider = roomDoor.GetComponent<Collider>();
        dCollider.isTrigger = false;

        bMiedo = GameObject.FindWithTag("Player").GetComponent<BarraDeMiedo>();
        tangKey = GameObject.FindWithTag("Key").GetComponent<TangibleKey>();

        scriptFlash = GameObject.FindWithTag("Linterna").GetComponent<Flashlight>();

        scriptfire = GameObject.FindWithTag("Flame").GetComponent<fire>();
        flame = GameObject.FindWithTag("Flame");

        isNear = false;
        interactLayers = (1 << layer);

        bMiedo.demonAlive = true;

        rainEffect = GameObject.FindObjectOfType<RainEffect>();
        CambiarDeObjetivoAleatorio();
        CambiarAlObjetivoPrincipal();
    }

    void Update()
    {
        agent.speed = Velocidad;
        mov.moveSpeed = 9.5f;
        flame.SetActive(true);
        if (cambiandoDeObjetivo)
        {
            // Verificar si llegamos al objetivo aleatorio
            
                tiempoEsperaActual += Time.deltaTime;
                if (tiempoEsperaActual >= tiempoEspera)
                {
                    CambiarAlObjetivoPrincipal();
                    tiempoEsperaActual = 0.0f;
                    resp.Play();
                }
            
        }
        else
        {
             // Verificar si estamos tocando un objeto con el tag "Puerta"
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.0f); // Ajusta el radio según tus necesidades
            CambiarAlObjetivoPrincipal();
            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag(tagObjetivo))
                {
                    tiempoEsperaActual += Time.deltaTime;
                    if (tiempoEsperaActual >= 8.0f)
                    {
                        Debug.Log("si");
                        tiempoEsperaActual = 0.0f; // Reiniciar el contador de tiempo de espera
                        CambiarDeObjetivoAleatorio();
                        break;
                    }
                    if (tiempoEsperaActual >= 6.0f && tiempoEsperaActual <= 6.1f)
                    {
                        resp.Play();
                    }
                    if (tiempoEsperaActual >= 1.0f && tiempoEsperaActual <= 1.1f)
                    {
                        puerta.Play();
                    }
                }
            }
        }

        

        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, distanciaDeVision))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // El jugador está en la vista
                jugadorEnVista = true;
                agent.SetDestination(player.position);
                Velocidad = 10;
                audioSource.pitch = 2.0f;
                audioSource.volume = 3.0f;
            }
            else
            {
                jugadorEnVista = false;
                
                Velocidad = Mathf.Lerp(Velocidad, 4, Time.deltaTime / 2);
                audioSource.pitch = Mathf.Lerp(audioSource.pitch, 1.0f, 0.5f * Time.deltaTime);
                audioSource.volume = Mathf.Lerp(audioSource.volume, 0.5f, 0.5f * Time.deltaTime);
            }
        }
        else
        {
            jugadorEnVista = false;
            
            Velocidad = Mathf.Lerp(Velocidad, 4, Time.deltaTime / 2);
            audioSource.pitch = Mathf.Lerp(audioSource.pitch, 1.0f, 0.5f * Time.deltaTime);
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0.5f, 0.5f * Time.deltaTime);
        }


        if (checkIsAlive())
        {
            //checkIsNear(); por ahora no
            reduceLifeBar();
            //showLifeBar();
        }
        else if (disappearTime <= 0)
        {
            killDemon();
        }
       
        dist = Vector3.Distance(transform.position, Objetivo.position);

        if (dist >= 4.0f)
        {
            MiAnimator.SetBool("attack",false);
            
            if(tocandoFuego){
                Scream();
            }
            else{
                Walk();
            }
        }
        if(dist < 4.0f){
            MiAnimator.SetBool("attack",true);
            
            if(tocandoFuego){
                Scream();
            }
            else{
                Walk();
            }
        }

        
        
    }
    
     void CambiarDeObjetivoAleatorio()
    {
        if (objetivosAleatorios.Count > 0)
        {
            objetivoActual = Random.Range(0, objetivosAleatorios.Count);
            agent.SetDestination(objetivosAleatorios[objetivoActual].position);
            cambiandoDeObjetivo = true;
        }
    }

    void CambiarAlObjetivoPrincipal()
    {
        agent.SetDestination(player.position);
        cambiandoDeObjetivo = false;
        objetivoActual = -1;
    }
    void Walk(){
        if(!audioSource.isPlaying){
            audioSource.clip = pasos;
            audioSource.Play();
        }
    }
    void Scream(){
        if(!grito.isPlaying){
            grito.Play();
            MiAnimator.SetBool("light",true);
        }
    }
    
    bool checkIsAlive()
    {
        if (lifeBar >= 100)
        {
            mov.moveSpeed = 6.5f;
            key.parent = null;
            
            jugadorEnVista = false;
            explosions.Play();
            disappear();
            explosionp.Play();
            
            explosion.parent = null;
            bMiedo.demonAlive = false;
            scriptFlash.demonAlive = false;
            return false;
        }
        return true;
    }
    void disappear()
    {
        disappearTime -= 1;
        //reducir visibilidad del render del demonio
    }
   
    void reduceLifeBar()
    {
        tF = scriptFlash.timeFlashing;
        fire = scriptfire.quemando;
        
        if ((tF > 0) && fire)
        {
            MiAnimator.SetBool("light",true);
            scriptFlash.timeFlashing = 0.0f;
            lifeBar += (dificultad * tF); //posible error x no definir valor de lifeBar
            tocandoFuego = true;
            //Debug.Log("se quema");
            if (!fuego.isPlaying)
            {
                fuego.Play();
            }
            if(!grito.isPlaying){
                grito.Play();
            }
            Velocidad = Mathf.Lerp(Velocidad, 3, Time.deltaTime * 10);
            emision = 0f;
        }
        else{
            MiAnimator.SetBool("light",false);
            tocandoFuego = false;
            //Debug.Log("no se quema" + emision);
            emision += Time.deltaTime;
            
            if(emision >= 3.5f){
                fuego.Stop();
                if(grito.isPlaying){
                    grito.Stop();
                }
            }
            else{
                Velocidad = Mathf.Lerp(Velocidad, 3, Time.deltaTime * 10);
                MiAnimator.SetBool("light",true);
                if(!grito.isPlaying){
                grito.Play();
                }
            }

        }
    }
    void killDemon()
    {
        //animacion/particulas
        tangKey.finishRoom();
        //posible render note
        dCollider.isTrigger = true;
        gameObject.SetActive(false);
        //destruir objeto

        rainEffect.PauseRain();
    }
}
