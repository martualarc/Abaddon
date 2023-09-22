using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptBarraMiedo : MonoBehaviour
{
    public Slider barraMiedo;
    public BarraDeMiedo playerMiedo;
    private void Start()
    {
        playerMiedo = GameObject.FindGameObjectWithTag("Player").GetComponent<BarraDeMiedo>();
        barraMiedo = GetComponent<Slider>();
        barraMiedo.maxValue = playerMiedo.maximoMiedo;
        barraMiedo.value = playerMiedo.miedoActual;
    }
    public void SetMiedo(int fear)
    {
        barraMiedo.value = fear;
    }
}