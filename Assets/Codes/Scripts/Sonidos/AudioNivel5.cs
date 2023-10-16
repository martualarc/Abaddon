using UnityEngine;
using System.Collections;

public class AudioNivel5 : MonoBehaviour
{
    public AudioClip gritosMujer;
    public AudioClip gritosMujerFuertes;
    public AudioClip Zumbido;

    private bool audioReproducido = false;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(gritosMujer, 0f, 12f));
    }

    void Update()
    {
        if (!audioReproducido)
        {
            GameObject disturbiaObj = GameObject.Find("disturbia");
            if (disturbiaObj != null)
            {
                StartCoroutine(Audio.Sonido(gritosMujerFuertes, 0f));
                audioReproducido = true;
            }
        }

        if (audioReproducido)
        {
            GameObject disturbiaObj = GameObject.Find("disturbia");
            if (disturbiaObj == null)
            {
                StartCoroutine(Audio.Sonido(Zumbido, 0f));
                audioReproducido = false;
            }
        }
    }
}
