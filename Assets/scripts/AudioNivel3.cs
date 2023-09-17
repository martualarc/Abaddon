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
        StartCoroutine(SonidoConDuracion(vozTurbia, 0f, 10f));
        StartCoroutine(Sonido(sonidoEstatica, 14f));
        StartCoroutine(SonidoConDuracion(sonidoMecanico, 19f, 5f));
        StartCoroutine(SonidoConDuracion(gritosRoboticos, 24f, 60f));
        StartCoroutine(SonidoConDuracion(gritosAhogo, 24f, 60f));
    }

    IEnumerator Sonido(AudioClip clip, float delay)
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

    IEnumerator SonidoConDuracion(AudioClip clip, float delay, float duracion)
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
}
