using UnityEngine;
using UnityEngine.UI;

public class BarraDeMiedo : MonoBehaviour
{
    public Image barraDeMiedo; // Referencia a la barra de miedo en la interfaz de usuario
    public float aumentoDeMiedoPorInteraccion = 10f; // Cuánto miedo se agrega por cada interacción con un demonio
    public float maximoMiedo = 100f; // El valor máximo de la barra de miedo antes de entrar en shock
    public float tiempoDeShock = 3f; // Cuánto tiempo dura el shock

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
            // Actualizar la barra de miedo en la interfaz de usuario
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
        // Realizar acciones de shock, como cambiar la animación del personaje o mostrar un efecto visual
    }

    private void SalirDelShock()
    {
        estaEnShock = false;
        miedoActual = 0f;
        // Realizar acciones para que el personaje se recupere del shock
        ActualizarBarraDeMiedo(); // Asegúrate de que la barra de miedo esté vacía al salir del shock
    }
}
