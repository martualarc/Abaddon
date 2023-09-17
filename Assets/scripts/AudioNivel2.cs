using UnityEngine;
using System.Collections;

public class AudioNivel2 : MonoBehaviour
{
    public AudioClip sonidoAgudo;
    public AudioClip sonidoSerpiente;
    public AudioClip sonidoExplosivo;

    void Start()
    {
        StartCoroutine(Sonido(sonidoExplosivo, 4f));
        StartCoroutine(Sonido(sonidoExplosivo, 19f));
        StartCoroutine(SonidoConDuracion(sonidoSerpiente, 5f, 14f));
        StartCoroutine(Sonido(sonidoAgudo, 9f));
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

        yield return new WaitForSeconds(duracion);

        audioSource.Stop();
        Destroy(sonidoObject);
    }
}
