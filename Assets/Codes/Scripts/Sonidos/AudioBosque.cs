using UnityEngine;
using System.Collections;

public class AudioBosque : MonoBehaviour
{
    public AudioClip viento;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(viento, 0f, 120f));
    }
}
