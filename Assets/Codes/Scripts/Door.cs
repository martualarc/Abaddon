using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    int num;
    bool isOpenable = True;

    void Start() {
    
    }
    
    void Update() {
     
    }

    bool interact(bool keyIsKey, int keyNum) {
        if(isOpenable && keyIsKey && keyNum == num ) {
            isOpenable = False;
            return True;
        }
        else {
            return False;
            //agregar logica para que te avise que te falta la llave o que te diga que ya no se puede entrar
        }
    }
    //void openDoor funcion que realiza la animacion de abrirla
}
