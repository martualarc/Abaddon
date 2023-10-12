using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public int num;
    public bool isKey;

    private Image keyIcon; // referencia al objeto del icono de la llave en la interfaz
    public AudioClip keySound;

    void Start()
    {
        // buscar el objeto del icono de la llave en la interfaz por su nombre
        keyIcon = GameObject.FindWithTag("UIKey").GetComponent<Image>(); // asegurarse de que el nombre coincida con el objeto en tu escena

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
        StartCoroutine(Audio.Sonido(keySound, 0f));
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
        keyIcon.GetComponent<CanvasRenderer>().SetAlpha(1f);

        //funcion llamada por realizar puzzles o vencer demonios
        //funcion que colorea la key en la interfaz
    }

    public void keyRespawn()
    {
        num -= 1;
        getKey();
    }
}
