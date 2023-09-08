
using UnityEngine;
using System.Collections;

public class Flashlight: MonoBehaviour {
    //inicializar acceso a scripts de demonios
    //inicializar fisicas del raycast y las variables necesarias
    //junto a la creacion de un layer de demonios

    void Start () {
        //rastrear posicion del jugador y actualizar la posicion de la linterna en funcion a ello
    }
    
    void Update () {
        //rastrear posicion del jugador y actualizar la posicion de la linterna en funcion a ello
    }
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayers)){
            Demonio scriptDem = hit.collider.GetComponent<Demonio>();
            DemonioNivelX scriptDemNivelX = hit.collider.GetComponent<DemonioNivelX>()
            
            if (scriptDem != null)
            {
                //desarrollar
            }
            else if(scriptDemNivelX != null){
                //demonio en especifico
            }
        }
        */
        
    //}
//}
