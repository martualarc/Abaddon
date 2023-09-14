using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FalseFlash: MonoBehaviour {
    public GameObject flashObj;
    public Image flashUI;
    Flashlight scriptFlash; //guarda el objeto para su posterior uso (TryFlash)
    Renderer flashRender;

    void Start(){
        flashRender = flashObj.GetComponent<Renderer>();
        flashRender.enabled = false;
        flashUI.gameObject.SetActive(false);
    }

    Flashlight interact(){
        
        flashUI.gameObject.SetActive(true);
        flashRender.enabled = true; //encender visualizacion del modelado de la linterna in-game
        return scriptFlash;
    }

}

