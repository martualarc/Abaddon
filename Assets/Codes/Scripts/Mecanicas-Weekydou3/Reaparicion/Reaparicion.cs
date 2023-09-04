using UnityEngine;
using UnityEngine.UI;

public class Reaparicion : MonoBehaviour
{
    public Image barraDeMiedo;
    public float aumentoDeMiedoPorInteraccion = 10f;
    public float maximoMiedo = 100f;
    public float tiempoDeShock = 3f;
    public Transform puntoDeReaparicion; // Referencia al punto de reaparición
    public float tiempoDeReaparicion = 2f; // Tiempo de espera antes de reaparecer

    private float miedoActual = 0f;
    private bool estaEnShock = false;
    private float tiempoDeRecuperacion = 0f;

    private void Update()
    {
        if (!estaEnShock)
        {
            if (miedoActual >= maximoMiedo)
            {
                EntrarEnShock();
            }
            else
            {
                // Lógica para mover al personaje, interactuar con demonios, etc.
            }
        }
        else
        {
            tiempoDeRecuperacion += Time.deltaTime;
            if (tiempoDeRecuperacion >= tiempoDeShock)
            {
                SalirDelShock();
            }
        }
    }

    private void InteractuarConDemonio()
    {
        if (!estaEnShock)
        {
            miedoActual += aumentoDeMiedoPorInteraccion;
            ActualizarBarraDeMiedo();
        }
    }

    private void ActualizarBarraDeMiedo()
    {
        float porcentajeDeMiedo = miedoActual / maximoMiedo;
        barraDeMiedo.fillAmount = porcentajeDeMiedo;
    }

    private void EntrarEnShock()
    {
        estaEnShock = true;
        tiempoDeRecuperacion = 0f;

        // Coloca al personaje en el punto de reaparición
        transform.position = puntoDeReaparicion.position;

        // Realiza acciones de shock
    }

    private void SalirDelShock()
    {
        estaEnShock = false;
        miedoActual = 0f;
        ActualizarBarraDeMiedo();

        // Realiza acciones para que el personaje se recupere del shock
    }
}
