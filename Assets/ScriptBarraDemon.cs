using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptBarraDemon : MonoBehaviour
{
    public Slider barraDemon;
    public Demonio demonLife;
    public Doubulia1 doubuliaLife;
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>() != null) {
            demonLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>();
            barraDemon = GetComponent<Slider>();
            barraDemon.maxValue = demonLife.maxlifeBar;
            barraDemon.value = demonLife.lifeBar;
        }
        
        else {
            doubuliaLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Doubulia1>();
            barraDemon = GetComponent<Slider>();
            barraDemon.maxValue = doubuliaLife.maxlifeBar;
            barraDemon.value = doubuliaLife.lifeBar;
        }
    }
    private void Update()
    {
        if (GetComponent<Demonio>() != null) {
            demonLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>();
            SetLife(demonLife.lifeBar);
        }
        
        else {
            doubuliaLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Doubulia1>();
                SetLife(doubuliaLife.lifeBar);
    }
    }
    public void SetLife(float life)
    {
        barraDemon.value = life;
    }
}
