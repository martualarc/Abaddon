using UnityEngine;
using System.Collections;

public class AudioNivel1 : MonoBehaviour
{
    public AudioClip sonidoArana;
    public AudioClip sonidoPunzante;

    void Start()
    {
        StartCoroutine(Audio.Sonido(sonidoPunzante, 9f));
        StartCoroutine(Audio.Sonido(sonidoArana, 19f));
    }
}
