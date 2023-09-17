using UnityEngine;
using System.Collections;

public class AudioNivel10 : MonoBehaviour
{
    public AudioClip ruidosTurbios;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(ruidosTurbios, 0f, 60f));
    }
}
