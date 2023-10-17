using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public int num = 1;
    public bool isKey;

    private Image keyIcon; // referencia al objeto del icono de la llave en la interfaz 
    public AudioClip keySound;

    void Start()
    {
        keyIcon = GameObject.FindWithTag("UIKey").GetComponent<Image>();
        //apuntar hacia el objeto del icono de la key en la interfaz

    }

    public void changeNum(int nextDoor)
    {
        num = nextDoor + 1;
        isKey = false;
        keyIcon.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }
    public void getKey()
    {
        Debug.Log("¡Has recogido la llave #" + num);
        isKey = true;
        keyIcon.GetComponent<CanvasRenderer>().SetAlpha(1f);
        // reproducir un sonido de recogida
        StartCoroutine(Audio.Sonido(keySound, 0f));

        //funcion llamada por realizar puzzles o vencer demonios
        //funcion que colorea la key en la interfaz
    }

    public void keyRespawn()
    {
        num -= 1;
        getKey();
        //funcion llamada al reaparecer
    }
}
