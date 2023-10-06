using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public int num;
    public bool isOpenable = true;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        GetComponent<sceneExit>().enabled = false;
    }
    
    void Update() {
     
    }

    public bool interact(bool keyIsKey, int keyNum) {
        if(isOpenable && keyIsKey && keyNum == num ) {
            isOpenable = false;
            return true;
        }
        else {
            return false;
            //agregar logica para que te avise que te falta la llave o que te diga que ya no se puede entrar
        }
    }
    //void openDoor funcion que realiza la animacion de abrirla
}
