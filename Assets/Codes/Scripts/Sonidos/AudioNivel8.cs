using UnityEngine;
using System.Collections;

public class AudioNivel8 : MonoBehaviour
{
    public AudioClip gritoDolor;
    public AudioClip golpes;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(golpes, 6f, 60f));
        StartCoroutine(Audio.Sonido(gritoDolor, 4f));
    }
}
