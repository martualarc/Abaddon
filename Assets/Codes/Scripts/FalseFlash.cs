/*
using UnityEngine;
using System.Collections;

public class FalseFlash: MonoBehaviour {
    public GameObject flashObj;
    Flashlight scriptFlash; //guarda el objeto para su posterior uso (TryFlash)

*/
/*
flashObj tiene que ser el nombre utilizado en el editor de Unity? No.
Nombre en el Inspector: En el Inspector de Unity, cuando agregas el 
script a un GameObject, verás la variable flashObj en el Inspector. 
Puedes arrastrar y soltar el GameObject que tiene el script
 "Flashlight" adjunto en esa variable.
*/
/*
    Renderer falseRender; //render linterna de juguete
    Renderer flashRender;

    void Start(){
        falseRender = gameObject.GetComponent<Renderer>();
        flashRender = flashObj.GetComponent<Renderer>();

        flashRender.enabled = false;
    }

    Flashlight interact(){
        falseRender.enabled = false;
        //agregar codigo sobre UI de icono de la linterna
        flashRender.enabled = true; //encender visualizacion del modelado de la linterna in-game
        return scriptFlash;
    }

}
*/
