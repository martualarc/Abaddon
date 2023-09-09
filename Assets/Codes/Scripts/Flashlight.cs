using UnityEngine;
using System.Collections;

public class Flashlight: MonoBehaviour {
    //inicializar acceso a scripts de demonios
    //inicializar fisicas del raycast y las variables necesarias:
    [SerializeField] private float interactDistance = 4f;
    [SerializeField] private int layer = 5;
    private int demonLayers;
    //creacion de un layer de demonios
    public bool isFlashing;
    public bool flashOn;
    public float timeFlashing;
    public float timeNotFlashing;
    
    void Start () {
        demonLayers = (1 << layer);
        demonLayers = ~demonLayers;

        isFlashing = false;
        timeFlashing = 0;
        timeNotFlashing = 0;
        flashOn = false;
        //rastrear posicion del jugador y actualizar la posicion de la linterna en funcion a ello
    }
    
    void Update () {
        
        if(flashOn)
        {
            flash();
            //renderLuzLinterna = True : la linterna esta encendida
        }
        else
        {
            isFlashing = false;
        }
        
        if(isFlashing)
        {
            timeNotFlashing = 0;
            timeFlashing += time.deltaTime;
        }
        else
        {
            timeFlashing = 0;
            timeNotFlashing += time.deltaTime;
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
            }
        }
        else
        {
            isFlashing = false;
        }
    }
}
