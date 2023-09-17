using UnityEngine;
using System.Collections;

public class AudioNivel5 : MonoBehaviour
{
    public AudioClip gritosMujer;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(gritosMujer, 0f, 12f));
    }
}
