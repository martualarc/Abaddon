using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public int num;
    public bool isKey;

    void Start () {
    //apuntar hacia el objeto del icono de la key en la interfaz
    }
    
    void Update () {
     
    }
    public void changeNum(int nextDoor) {
        num = nextDoor + 1;
        isKey = false;
        //funcion que decolorea la key en la interfaz
    }
    void getKey() { //funcion llamada por realizar puzzles o vencer demonios
        isKey = true;
        //funcion que colorea la key en la interfaz
    }
}
