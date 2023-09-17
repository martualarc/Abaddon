using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static IEnumerator SonidoConDuracion(AudioClip clip, float delay, float duracion)
    {
        yield return new WaitForSeconds(delay);

        GameObject sonidoObject = new GameObject("Sonido");
        AudioSource audioSource = sonidoObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.loop = true;

        yield return new WaitForSeconds(duracion);

        audioSource.Stop();
        Destroy(sonidoObject);
    }

    public static IEnumerator Sonido(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject sonidoObject = new GameObject("Sonido");
        AudioSource audioSource = sonidoObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        yield return new WaitForSeconds(clip.length);

        audioSource.Stop();
        Destroy(sonidoObject);
    }
}
