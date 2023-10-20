using System.Collections;
using UnityEngine;

public class ControlDeLuces : MonoBehaviour
{
    public Light[] luces;
    public float tiempoParaApagar = 5.0f; 
    public float tiempoParaParpadear = 2.0f;
    public float tiempoParaEncender = 5.0f; 

    private bool lucesApagadas = false;

    private void Start()
    {
        StartCoroutine(ControlDeLucesCoroutine());
    }

    IEnumerator ControlDeLucesCoroutine()
    {
        while (true)
        {
            if (!lucesApagadas)
            {
                yield return new WaitForSeconds(tiempoParaApagar);

                foreach (var luz in luces)
                {
                    luz.enabled = false;
                }
                lucesApagadas = true;
            }
            else
            {
                yield return new WaitForSeconds(tiempoParaParpadear);

                foreach (var luz in luces)
                {
                    luz.color = Color.red;
                    luz.enabled = !luz.enabled;
                }

                yield return new WaitForSeconds(tiempoParaEncender);

                foreach (var luz in luces)
                {
                    luz.color = Color.white;
                    luz.enabled = true;
                }
                lucesApagadas = false;
            }
        }
    }
}
