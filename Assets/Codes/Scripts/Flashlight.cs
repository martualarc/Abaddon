using UnityEngine;
using System.Collections;

public class Flashlight: MonoBehaviour {
    //inicializar acceso a scripts de demonios
    //inicializar fisicas del raycast y las variables necesarias
    //junto a la creacion de un layer de demonios
    public bool isFlashing;
    public bool flashOn;
    public float timeFlashing;
    public float timeNotFlashing;
    
    void Start () {

        isFlashing = false;
        timeFlashing = 0;
        timeNotFlashing = 0;
        flashOn = false;
        //rastrear posicion del jugador y actualizar la posicion de la linterna en funcion a ello
    }
    
    void Update () {
        
        //rastrear posicion del jugador y actualizar la posicion de la linterna en funcion a ello
        
        if (flashOn == true)
        {
            flash();
            //la linterna esta encendida
        }
        
        if (isFlashing)
        {
            timeNotFlashing = 0;
            timeFlashing += time.deltaTime;
        }
        else
        {
            timeFlashing = 0;
            timeNotFlashing += time.deltaTime;
        }


    /*
    funciones que pueden usarse en flash():
    Componente <Demonio>:
        Demonio.infligirDaño(int)
    */
    /*
    ideas:
    1) collider solo en la parte vulnerable del demonio
    2) if( distancia-de-la-colision < demonio5.longWarning && 1 )
        then demonio5.segundosAntesDeMorir --; 
    2 alternativo) medir angulo del vector flash con respecto al piso
    3) personalizar para cada demonio
    4) acceso hacia y desde a scripts Demonio
    */
    //void flash(){
        /*logica de apuntar al demonio
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, demonLayers)){
            Demonio scriptDem = hit.collider.GetComponent<Demonio>(); //guarda cualquier objeto con clase heredada de demonio
            if (scriptDem != null)
            {
                isFlashing = true;
            }
            else
            {
                isFlashing = false;
            }
        */
        
    //}
//}
