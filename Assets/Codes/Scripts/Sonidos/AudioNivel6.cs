using UnityEngine;
using System.Collections;

public class AudioNivel6 : MonoBehaviour
{
    public AudioClip musicaParque;
    public AudioClip musicaParqueGrave;
    public AudioClip animatronicos;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(musicaParque, 0f, 5f));
        StartCoroutine(Audio.SonidoConDuracion(animatronicos, 2f, 15f));
        StartCoroutine(Audio.Sonido(musicaParqueGrave, 7f));
    }
}
