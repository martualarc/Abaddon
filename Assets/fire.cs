using UnityEngine;

public class fire : MonoBehaviour
{
    public ParticleSystem linterna; // El componente de luz de la linterna
    public float bateriaMaxima = 100.0f; // Capacidad máxima de la carga
    public float consumoPorSegundo = 5.0f; // Consumo de carga por segundo
    public float recargaPorPila = 50.0f; // Cantidad de carga que se recarga al recoger una pila
    public KeyCode activarLinternaKey = KeyCode.Mouse1; // Tecla para activar  (clic derecho)
    public GameObject pila; // Objeto de pila a recoger

    private float bateriaActual;

    public ParticleSystem sistemaDeParticulas;
    [SerializeField] public Transform parentObject;
    [SerializeField] public Transform targetObject;
    public bool quemando = false;

    void Start()
    {
        bateriaActual = bateriaMaxima;
    }

    void Update()
    {
        // Encender o apagar la linterna al hacer clic derecho
        if (Input.GetKey(activarLinternaKey) && bateriaActual > 0)
        {
            bateriaActual -= consumoPorSegundo * Time.deltaTime;
            sistemaDeParticulas.Play();
            linterna.Play();
            quemando = true;
        }
        else
        {
            sistemaDeParticulas.Stop();
            linterna.Stop();
            quemando = false;
        }

        // Recoger una pila y recargar la carga
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(pila.transform.position, transform.position) < 2.0f)
        {
            RecargarBateria();
        }

        // Asegurarse de que la carga no se agote más allá del mínimo
        bateriaActual = Mathf.Max(bateriaActual, 0);

        // Actualizar el estado de la carga
        ActualizarEstadoBateria();
    }

    void RecargarBateria()
    {
        bateriaActual += recargaPorPila;
        bateriaActual = Mathf.Min(bateriaActual, bateriaMaxima);
        Destroy(pila); // Elimina el objeto de la pila
    }

    void ActualizarEstadoBateria()
    {
        // Aquí puedes agregar lógica para mostrar el estado de la carga en el juego, como una barra de energía en la interfaz de usuario.
        // Puedes utilizar bateriaActual / bateriaMaxima para calcular el porcentaje de carga restante.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Convierte este objeto en hijo del objeto padre
            transform.parent = parentObject;
            transform.position = targetObject.position;
            transform.rotation = targetObject.rotation;
        }
    }

}
