using UnityEngine;
using System.Collections;

public class AudioNivel1 : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sonidoArana;
    public AudioClip sonidoPunzante;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("SonidoPunzante", 9f);
        StartCoroutine(SonidoArana());
    }

    void SonidoPunzante()
    {
        audioSource.clip = sonidoPunzante;
        audioSource.Play();
        StartCoroutine(PararSonido(3f));
    }

    IEnumerator PararSonido(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        audioSource.Stop();
    }

    IEnumerator SonidoArana()
    {
        yield return new WaitForSeconds(19f);

        audioSource.loop = true;
        audioSource.clip = sonidoArana;
        audioSource.Play();
    }
}
