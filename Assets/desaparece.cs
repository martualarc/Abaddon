using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparece : MonoBehaviour
{
    public float tiempoParaDesaparecer = 3.0f; // Tiempo en segundos antes de que el objeto desaparezca
    public float tiempoParaReaparecer = 5.0f; // Tiempo en segundos antes de que el objeto reaparezca

    private bool desaparecido = false;

    private void Start()
    {
        StartCoroutine(desapareceCoroutine());  // Controla el ciclo de desaparecer y reaparecer
    }

    IEnumerator desapareceCoroutine()
    {
        while (true)
        {
            if (desaparecido)
            {
                // Espera el tiempo especificado antes de reaparecer
                yield return new WaitForSeconds(tiempoParaReaparecer);

                // Activa el objeto para que reaparezca
                gameObject.SetActive(true);
                desaparecido = false;
            }
            else
            {
                // Espera el tiempo especificado antes de desaparecer
                yield return new WaitForSeconds(tiempoParaDesaparecer);

                // Desactiva el objeto para que desaparezca
                gameObject.SetActive(false);
                desaparecido = true;
            }
        }
    }
}
