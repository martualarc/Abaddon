using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class fire : MonoBehaviour
{
    public ParticleSystem linterna; // El componente de luz de la linterna
    public ParticleSystem fuego;
    public float bateriaMaxima = 100.0f; // Capacidad máxima de la carga
    public float consumoPorSegundo = 5.0f; // Consumo de carga por segundo
    public float recargaPorPila = 50.0f; // Cantidad de carga que se recarga al recoger una pila
    public KeyCode activarLinternaKey = KeyCode.Mouse1; // Tecla para activar  (clic derecho)
 
    public List<Transform> pila; // Objetos de pila a recoger
    public float distanciaUmbral = 4f;
    private float bateriaActual;
    public bool tieneFuego = false;

    private BarraDeMiedo bMiedo;
    [SerializeField] public Transform parentObject;
    [SerializeField] public Transform targetObject;
    public bool quemando;

    void Start()
    {
        bateriaActual = 20f;
    }

    void Update()
    {
        bMiedo = GameObject.FindWithTag("Player").GetComponent<BarraDeMiedo>();
        parentObject = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        targetObject = GameObject.FindGameObjectWithTag("Linterna").GetComponent<Transform>();
        // Encender o apagar la linterna al hacer clic derecho
        if (Input.GetKey(activarLinternaKey) && bateriaActual > 0 && tieneFuego)
        {
            bateriaActual -= consumoPorSegundo * Time.deltaTime;
            linterna.Play();            
            fuego.Play();
            quemando = true;
        }
        else
        {
            quemando = false;
            linterna.Stop();
            fuego.Stop();
        }

        // Recoger una pila y recargar la carga
        if(pila[1] != null){
        foreach (Transform objetoTransform in pila)
        {
            float distancia = Vector3.Distance(transform.position, objetoTransform.position);

            if (distancia < distanciaUmbral && Input.GetKeyDown(KeyCode.E))
            {
                RecargarBateria();
                objetoTransform.position = new Vector3(Random.Range(-18f, 20f), 1.5f, Random.Range(-8f, 60f));
            }
        }
        }
        else{
            //
        }

        if(tieneFuego){
            transform.parent = parentObject;
            transform.position = targetObject.position;
            transform.rotation = targetObject.rotation;    
        }
        // Asegurarse de que la carga no se agote más allá del mínimo
        bateriaActual = Mathf.Max(bateriaActual, 0);

        if(SceneManager.GetActiveScene().name == "nivel_cinco"){
            gameObject.SetActive(true);
        }
        else{
            gameObject.SetActive(false);
        }
        if(bMiedo.demonAlive == false){
            gameObject.SetActive(false);
        }
    }

    void RecargarBateria()
    {
        bateriaActual += recargaPorPila;
        bateriaActual = Mathf.Min(bateriaActual, bateriaMaxima);
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            tieneFuego = true;
            Collider miCollider = GetComponent<Collider>();
            miCollider.enabled = false;
        }
    }

}
