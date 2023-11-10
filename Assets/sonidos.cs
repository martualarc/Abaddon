using UnityEngine;

public class sonidos : MonoBehaviour
{
    public AudioSource audioPasos;
    public AudioSource audioRespiracion;
    public AudioSource audioLatidos;
    public AudioSource audioLinterna;
    public AudioSource audioScreamer;

    public bool demonioEnVista = false;
    private bool moviendose = false;
    public GameObject doubuliaObject;
    public float miedo = 0.0f;

    public float velocidadMiedo = 0.005f; // Velocidad a la que aumenta o disminuye el miedo
    public float maxMiedo = 1.0f; // Valor máximo de miedo

    

    private void Start()
    {
        // Obtén una referencia al script Demonio en Doubulia
        Doubulia1 demonioScript = doubuliaObject.GetComponent<Doubulia1>();

        if (demonioScript != null)
        {
            // Accede a la variable jugadorEnVista
            bool jugadorEnVista = demonioScript.jugadorEnVista;

            // Ahora puedes usar la variable jugadorEnVista en tu void
            VerificarDemonioEnVista(jugadorEnVista);
        }
    }
    void Update()
    {
        // Verificar si el demonio está en vista
        Doubulia1 demonioScript = doubuliaObject.GetComponent<Doubulia1>();

        bool jugadorEnVista = demonioScript.jugadorEnVista;
        demonioEnVista = VerificarDemonioEnVista(jugadorEnVista);

        // Actualizar la variable de miedo basada en la visión del demonio
        ActualizarMiedo();

        // Reproducir sonidos basados en el miedo
        ReproducirPasos();
        ReproducirRespiracionYLatiidos();
        ReproducirLinterna();
        ReproducirScreamer();

        
    }

    void ActualizarMiedo()
    {
        float dist = Vector3.Distance(transform.position, doubuliaObject.transform.position);

        if (demonioEnVista)
        {
            // Aumentar el miedo si el demonio está en vista
            miedo = Mathf.Min(miedo + velocidadMiedo * Time.deltaTime, maxMiedo);
        }
        else
        {
            // Disminuir el miedo si el demonio no está en vista y esta lejos
            if(dist < 20.0f){
                miedo = Mathf.Min(miedo + velocidadMiedo * Time.deltaTime, 0.3f);
            }
            else{
                miedo = Mathf.Max(miedo - velocidadMiedo * Time.deltaTime, 0.01f);
            }
        }

        
    }

    void ReproducirPasos()
    {
        moviendose = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (moviendose)
        {
            if (!audioPasos.isPlaying)
            {
                audioPasos.Play(); // Reproducir sonido de pasos si el personaje se está moviendo
            }
        }
        else
        {
            audioPasos.Stop(); // Detener sonido de pasos si el personaje no se mueve
        }
    }

    void ReproducirRespiracionYLatiidos()
    {
        float volumenRespiracion = miedo / 2.2f; // Volumen dependiente del miedo
        audioRespiracion.volume = volumenRespiracion;
        audioLatidos.volume = volumenRespiracion;

        if (miedo > 0.0f)
        {
            if (!audioRespiracion.isPlaying)
            {
                audioRespiracion.Play(); 
            }

            if (!audioLatidos.isPlaying)
            {
                audioLatidos.Play(); 
            }
        }
        else
        {
            audioRespiracion.Stop(); // Detener sonido de respiración y latidos si  no hay miedo
            audioLatidos.Stop(); 
        }

        
    }

    void ReproducirLinterna()
    {
        if (Input.GetMouseButtonDown(1))
        {
            audioLinterna.Play(); // Reproducir sonido de la linterna cuando se hace clic derecho
        }
         if (Input.GetMouseButtonUp(1))
        {
            audioLinterna.Play(); // Reproducir sonido de la linterna cuando se deja de hacer clic derecho
        }
    }

    void ReproducirScreamer()
    {
        
    }

    bool VerificarDemonioEnVista(bool jugadorEnVista)
    {
        if (jugadorEnVista)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
