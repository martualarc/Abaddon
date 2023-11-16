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
        demonLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>();
        barraDemon = GetComponent<Slider>();
        barraDemon.maxValue = demonLife.maxlifeBar;
        barraDemon.value = demonLife.lifeBar;
        
        doubuliaLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Doubulia1>();
        if(doubuliaLife != null){
            barraDemon.maxValue = doubuliaLife.maxlifeBar;
            barraDemon.value = doubuliaLife.lifeBar;
        }
    }
    private void Update()
    {
        doubuliaLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Doubulia1>();
        demonLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>();
        if(doubuliaLife != null){
            SetLife(doubuliaLife.lifeBar);
        }
        else{
            SetLife(demonLife.lifeBar);
        }
    }
    public void SetLife(float life)
    {
        barraDemon.value = life;
    }
}
