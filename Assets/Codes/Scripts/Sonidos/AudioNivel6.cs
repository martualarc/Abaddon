using UnityEngine;
using System.Collections;

public class AudioNivel6 : MonoBehaviour
{
    public AudioClip musicaParque;
    public AudioClip musicaParqueGrave;
    public AudioClip animatronicos;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(musicaParque, 0f, 7f));
        StartCoroutine(Audio.SonidoConDuracion(animatronicos, 7f, 18f));
        StartCoroutine(Audio.Sonido(musicaParqueGrave, 25f));
    }
}
