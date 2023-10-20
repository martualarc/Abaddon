using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNivel7 : MonoBehaviour
{
    public AudioClip sonidoPunzante;
    public AudioClip sonidoScreamer;
   // public AudioClip sonidoDeGoma;

    void Start()
    {
        StartCoroutine(Audio.Sonido(sonidoPunzante, 1f));
        StartCoroutine(Audio.Sonido(sonidoScreamer, 11f));
    }
}
