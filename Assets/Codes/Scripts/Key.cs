using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    int num;
    bool isKey;

    void Start () {
    //apuntar hacia el objeto del icono de la key en la interfaz
    }
    
    void Update () {
     
    }
    void changeNum(int nextDoor) {
        num = nextDoor + 1;
        isKey = False;
        //funcion que decolorea la key en la interfaz
    }
    void getKey() { //funcion llamada por realizar puzzles o vencer demonios
        isKey = True;
        //funcion que colorea la key en la interfaz
    }
}
