using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Flashlight: MonoBehaviour {
    //inicializar acceso a scripts de demonios
    //inicializar fisicas del raycast y las variables necesarias:
    
    //creacion de un layer de demonios
    public bool isFlashing;
    public bool flashOn;
    public float timeFlashing;
    public float timeNotFlashing;
    private Light spot;
    public bool demonAlive;
    
    void Start () {
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
           spot.enabled = true;
            //renderLuzLinterna = True : la linterna esta encendida
        }
        else
        {
            isFlashing = false;
            spot.enabled = false;
        }
        
        if(isFlashing || SceneManager.GetActiveScene().name == "hall")
        {
            timeNotFlashing = 0;
            timeFlashing += Time.deltaTime;
        }
        else
        {
            timeFlashing = 0;
            if(demonAlive && SceneManager.GetActiveScene().name != "hall"){
                timeNotFlashing += Time.deltaTime;
            }
        }
    }
    

}
