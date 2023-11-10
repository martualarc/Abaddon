using UnityEngine;

public class doubulia : MonoBehaviour
{
    public AudioSource audioSource; // Asigna el AudioSource de doubulia desde el Inspector

    private Doubulia1 doubulia1; // Variable para mantener una referencia al objeto padre

    private void Start()
    {
        // Obtiene una referencia al objeto padre (Demonio)
        doubulia1 = transform.parent.GetComponent<Doubulia1>();
    }

    private void Update()
    {
        // Accede a la variable jugadorEnVista desde el objeto padre (Demonio)
        bool jugadorEnVista = doubulia1.jugadorEnVista;

        // Actúa según el valor de la variable
        if (jugadorEnVista)
        {
            audioSource.pitch = 1.0f;
            audioSource.volume = 2f;
            //Debug.Log("te esta viendo");
        }
        else
        {
            // Si jugadorEnVista es false, detén el AudioSource de Foubulia
            audioSource.Play();
            audioSource.volume = 0.5f;
            //Debug.Log("no te esta viendo");
        }
    }

    void Sonido(){
        audioSource.Play();
    }
}
