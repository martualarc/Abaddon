using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptBarraDemon : MonoBehaviour
{
    public Slider barraDemon;
    public Demonio demonLife;
    private void Start()
    {
        demonLife = GameObject.FindGameObjectWithTag("Demon").GetComponent<Demonio>();
        barraDemon = GetComponent<Slider>();
        barraDemon.maxValue = demonLife.maxlifeBar;
        barraDemon.value = demonLife.lifeBar;
    }
    private void Update()
    {
        SetLife(demonLife.lifeBar);
    }
    public void SetLife(float life)
    {
        barraDemon.value = life;
    }
}
