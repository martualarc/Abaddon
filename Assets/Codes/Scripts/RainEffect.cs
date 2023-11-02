using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEffect : MonoBehaviour
{
    public ParticleSystem sistemaDeParticulas;
    public AudioSource rainSound;
    public AudioSource outPutRainSound;

    void Start()
    {

    }

    void Update()
    {

    }

    public void StartRain()
    {
        sistemaDeParticulas.Play();
        rainSound.Play();
    }
    public void PauseRain()
    {
        sistemaDeParticulas.Pause();
        rainSound.Pause();
        outPutRainSound.Play();
    }
}
