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
        GameObject d = GameObject.FindGameObjectWithTag("Demon");
        if(d != null){
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
        }else{
            Debug.Log("no hay demonio");
        }

    }
    private void Update()
    {
        GameObject d = GameObject.FindGameObjectWithTag("Demon") ;
        barraDemon = GetComponent<Slider>();
        if(d != null){
        if (GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>() != null) {
            demonLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>();
            barraDemon.maxValue = demonLife.maxlifeBar;
            SetLife(demonLife.lifeBar);
        }
        else {
            doubuliaLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Doubulia1>();
            barraDemon.maxValue = doubuliaLife.maxlifeBar;
            SetLife(doubuliaLife.lifeBar);
        }
        }else{
            //Debug.Log("no hay demonio");
        }

    }
    public void SetLife(float life)
    {
        barraDemon.value = life;
    }
}
