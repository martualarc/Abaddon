using UnityEngine;
using System.Collections;

public class AudioHall : MonoBehaviour
{
    public AudioClip pasos;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(pasos, 0f, 120f));
    }
}
