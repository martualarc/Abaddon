using UnityEngine;
using System.Collections;

public class AudioNivel4 : MonoBehaviour
{
    public AudioClip sonidoAlacranes;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(sonidoAlacranes, 7f, 60f));
    }
}
