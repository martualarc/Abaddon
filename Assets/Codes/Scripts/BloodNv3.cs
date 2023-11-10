using UnityEngine;

public class BloodNv3 : MonoBehaviour
{
    private ParticleSystem particles;

    void Start()
    {
        // Obtener el sistema de partículas adjunto al mismo objeto
        particles = GetComponent<ParticleSystem>();

        // Asegurarse de que el sistema de partículas se detenga al inicio
        if (particles != null)
        {
            particles.Stop();

            // Invocar el método MostrarParticulas después de 15 segundos
            Invoke("MostrarParticulas", 12.5f);
        }
    }

    void MostrarParticulas()
    {
        // Comenzar a reproducir las partículas después de 15 segundos
        if (particles != null)
        {
            particles.Play();
        }
    }
}
