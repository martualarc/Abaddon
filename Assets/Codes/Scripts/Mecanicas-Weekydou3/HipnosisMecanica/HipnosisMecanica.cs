using UnityEngine;

public class HipnosisMecanica : MonoBehaviour
{
    public Transform pantallaDeHipnosis; // Referencia al objeto que representa la pantalla de hipnosis
    public float tiempoRequerido = 15f; // Tiempo requerido en segundos para completar la hipnosis
    private float tiempoActual; // Tiempo transcurrido
    private bool estaHipnotizado; // Indica si el jugador está hipnotizado

    private void Start()
    {
        tiempoActual = 0f;
        estaHipnotizado = false;
    }

    private void Update()
    {
        if (estaHipnotizado)
        {
            tiempoActual += Time.deltaTime;

            if (tiempoActual >= tiempoRequerido)
            {
                CompletarHipnosis();
            }
        }
        else
        {
            tiempoActual = 0f; // Reiniciar el tiempo si el jugador se distrae
        }
    }

    private void CompletarHipnosis()
    {
        Debug.Log("El jugador ha completado la hipnosis con éxito");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pantallaDeHipnosis.gameObject)
        {
            estaHipnotizado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pantallaDeHipnosis.gameObject)
        {
            estaHipnotizado = false;
        }
    }
}
    
