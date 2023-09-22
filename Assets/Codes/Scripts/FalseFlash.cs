using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FalseFlash: MonoBehaviour {
    GameObject flashObj;
    GameObject flashUI;
    Flashlight scriptFlash; //guarda el objeto para su posterior uso (TryFlash)


    //Renderer falseRender; //render linterna de juguete
    Renderer flashRender;

    void Start(){

        flashObj = GameObject.FindWithTag("Linterna");
        flashUI = GameObject.FindWithTag("UILinterna");
        scriptFlash = flashObj.GetComponent<Flashlight>();

        //falseRender = gameObject.GetComponent<Renderer>();
        flashRender = flashObj.GetComponent<Renderer>();
        flashRender.enabled = false;
    }

    public Flashlight interact(){
        //falseRender.enabled = false;
        flashUI.GetComponent<CanvasRenderer>().SetAlpha(1f);
        flashRender.enabled = true; //encender visualizacion del modelado de la linterna in-game
        return scriptFlash;
    }

}