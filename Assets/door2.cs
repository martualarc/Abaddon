using UnityEngine;

public class door2 : MonoBehaviour
{
    public float velocidadRotacion = 90.0f; // Velocidad de rotación en grados por segundo
    private bool estaAbierta = false;

    private void OnMouseDown()
    {
        // Cambia el estado de la puerta (abierta o cerrada)
        estaAbierta = !estaAbierta;
    }

    private void Update()
    {
        float anguloDestino = estaAbierta ? 90.0f : 0.0f; // Ángulo de rotación deseado
        float anguloActual = transform.rotation.eulerAngles.y; // Ángulo actual de la puerta

        // Rota la puerta gradualmente hacia el ángulo de destino
        if (Mathf.Abs(anguloActual - anguloDestino) > 0.01f)
        {
            float pasoRotacion = velocidadRotacion * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, anguloDestino, 0), pasoRotacion);
        }
    }
}
