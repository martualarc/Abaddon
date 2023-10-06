using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{

    public int num;
    public bool isKey;

    private GameObject keyIcon; // referencia al objeto del icono de la llave en la interfaz

    void Start()
    {
        // buscar el objeto del icono de la llave en la interfaz por su nombre
        keyIcon = GameObject.Find("KeyIcon"); // asegurarse de que el nombre coincida con el objeto en tu escena

        if (keyIcon == null)
        {
            Debug.LogError("No se pudo encontrar el objeto del icono de la llave en la interfaz.");
        }
        else
        {
            // el objeto del icono de la llave fue encontrado
            Debug.Log("¡Objeto del icono de la llave encontrado!");
        }

        //apuntar hacia el objeto del icono de la key en la interfaz
    }

    void Update()
    {

    }


    public void collectKey()
    {
        // reproducir un sonido de recogida
        AudioManager.Instance.PlayCollectKeySound();
        // mostrar un mensaje en la consola
        Debug.Log("¡Has recogido la llave #" + num);

        // función para recoger la llave
    }
    public void changeNum(int nextDoor)
    {
        num = nextDoor + 1;
        isKey = false;

        //funcion que decolorea la key en la interfaz
    }
    public void getKey()
    {
        isKey = true;

        //funcion llamada por realizar puzzles o vencer demonios
        //funcion que colorea la key en la interfaz
    }

    public void keyRespawn()
    {
        num -= 1;
        getKey();
    }
}
