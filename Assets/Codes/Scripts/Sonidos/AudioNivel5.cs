using UnityEngine;

public class AudioNivel5 : MonoBehaviour
{
    public AudioClip gritosMujer;
    public AudioClip gritosMujerFuertes;
    public AudioClip Zumbido;

    private bool audioReproducido = false;
    private AudioSource audioSource;

    void Start()
    {
        StartCoroutine(Audio.SonidoConDuracion(gritosMujer, 0f, 12f));
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioReproducido)
        {
            GameObject demonioObj = GameObject.Find("doubulia");
            if (demonioObj != null)
            {
                audioSource.clip = gritosMujerFuertes;
                audioSource.loop = true;
                audioSource.Play();
                audioReproducido = true;
            }
        }

        if (audioReproducido)
        {
            GameObject demonioObj = GameObject.Find("doubulia");
            if (demonioObj == null)
            {
                audioSource.Stop();
                audioSource.clip = Zumbido;
                audioSource.Play();
                audioSource.loop = true;
            }
        }
    }
}
