using UnityEngine;
using System.Collections;

public class AudioNivel2 : MonoBehaviour
{
    public AudioClip sonidoAgudo;
    public AudioClip sonidoSerpiente;
    public AudioClip sonidoExplosivo;

    void Start()
    {
        StartCoroutine(Audio.Sonido(sonidoExplosivo, 4f));
        StartCoroutine(Audio.Sonido(sonidoExplosivo, 19f));
        StartCoroutine(Audio.SonidoConDuracion(sonidoSerpiente, 5f, 14f));
        StartCoroutine(Audio.Sonido(sonidoAgudo, 9f));
    }
}
