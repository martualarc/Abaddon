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
        barraMiedo.maxValue = playerMiedo.maxFearBar;
        barraMiedo.value = playerMiedo.fearBar;
    }
    private void Update()
    {
        SetMiedo(playerMiedo.fearBar);
    }
    public void SetMiedo(float fear)
    {
        barraMiedo.value = fear;
    }
}
