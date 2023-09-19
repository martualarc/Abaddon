using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FalseFlash: MonoBehaviour {
    public GameObject flashObj;
    public Image flashUI;
    Flashlight scriptFlash; //guarda el objeto para su posterior uso (TryFlash)


    //Renderer falseRender; //render linterna de juguete
    Renderer flashRender;

    void Start(){
        scriptFlash = flashObj.GetComponent<Flashlight>();

        //falseRender = gameObject.GetComponent<Renderer>();
        flashRender = flashObj.GetComponent<Renderer>();
        flashRender.enabled = false;
        flashUI.gameObject.SetActive(false);
    }

    Flashlight interact(){
        //falseRender.enabled = false;
        flashUI.gameObject.SetActive(true);
        flashRender.enabled = true; //encender visualizacion del modelado de la linterna in-game
        return scriptFlash;
    }

}