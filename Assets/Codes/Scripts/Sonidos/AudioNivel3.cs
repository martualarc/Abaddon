using UnityEngine;
using System.Collections;

public class AudioNivel3 : MonoBehaviour
{
    public AudioClip vozTurbia;
    public AudioClip sonidoEstatica;
    public AudioClip sonidoMecanico;
    public AudioClip gritosRoboticos;
    public AudioClip gritosAhogo;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(vozTurbia, 0f, 10f));
        StartCoroutine(Audio.Sonido(sonidoEstatica, 14f));
        StartCoroutine(Audio.SonidoConDuracion(sonidoMecanico, 19f, 5f));
        StartCoroutine(Audio.SonidoConDuracion(gritosRoboticos, 24f, 60f));
        StartCoroutine(Audio.SonidoConDuracion(gritosAhogo, 24f, 60f));
    }
}
