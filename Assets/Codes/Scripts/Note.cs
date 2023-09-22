using UnityEngine;
using System.Collections;

public class Note: MonoBehaviour 
{
    GameObject nota;

    void Start(){

        nota = GameObject.FindWithTag("Nota");
    }
    void Update(){
        if(Input.GetKeyUp(KeyCode.Escape)){
            nota.GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
    }
    public void interact(){
       nota.GetComponent<CanvasRenderer>().SetAlpha(1f);
    }
}
