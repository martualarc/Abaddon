using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luciernagas : MonoBehaviour
{
    public ParticleSystem luciernagas;
    public sonidos script;
    public float vel;
    
    void Start()
    {
        //Audio audioScript = audioObject.GetComponent<sonidos>();
    }


    void Update()
    {
       vel = script.miedo;
        
       var mainModule = luciernagas.main;
       mainModule.startSpeed = 5f * vel;
       var noise = luciernagas.noise;
       noise.strength = 5f + 10 * vel;
    }
}
