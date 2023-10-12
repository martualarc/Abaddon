using UnityEngine;
using System.Collections;

public class Flashlight: MonoBehaviour {
    //inicializar acceso a scripts de demonios
    //inicializar fisicas del raycast y las variables necesarias:
    [SerializeField] private float interactDistance = 8f;
    [SerializeField] private int layer = 6;
    private int demonLayers;
    //creacion de un layer de demonios
    public bool isFlashing;
    public bool flashOn;
    public float timeFlashing;
    public float timeNotFlashing;
    private Light spot;
    
    void Start () {
        demonLayers = (1 << layer);
        demonLayers = ~demonLayers;

        isFlashing = false;
        timeFlashing = 0;
        timeNotFlashing = 0;
        flashOn = false;
        spot = GameObject.FindWithTag("Light").GetComponent<Light>();
        //rastrear posicion del jugador y actualizar la posicion de la linterna en funcion a ello
    }
    
    void Update () {
        
        if(flashOn)
        {

           flash();
           spot.enabled = true;
            //renderLuzLinterna = True : la linterna esta encendida
        }
        else
        {
            isFlashing = false;
            spot.enabled = false;
        }
        
        if(isFlashing)
        {
            timeNotFlashing = 0;
            timeFlashing += Time.deltaTime;
        }
        else
        {
            timeFlashing = 0;
            timeNotFlashing += Time.deltaTime;
        }
    }
    
  void flash(){ //logica de apuntar al demonio
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, demonLayers))
        {
            Demonio scriptDem = hit.collider.GetComponent<Demonio>(); //guarda cualquier objeto con clase heredada de demonio
            if (scriptDem != null)
            {
                isFlashing = true;
                Debug.Log("Flasheando demonio");
            }
        }
        else
        {
            isFlashing = false;
            Debug.Log("Flasheando nada");
        }
    }
}
