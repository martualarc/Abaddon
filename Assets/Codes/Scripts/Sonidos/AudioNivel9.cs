using UnityEngine;
using System.Collections;

public class AudioNivel9 : MonoBehaviour
{
    public AudioClip radio;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(radio, 0f, 60f));
    }
}
