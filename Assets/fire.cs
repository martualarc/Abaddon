using UnityEngine;
using System.Collections.Generic;

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

    
    [SerializeField] public Transform parentObject;
    [SerializeField] public Transform targetObject;
    public bool quemando = false;

    void Start()
    {
        bateriaActual = 20f;
    }

    void Update()
    {
        // Encender o apagar la linterna al hacer clic derecho
        if (Input.GetKey(activarLinternaKey) && bateriaActual > 0 && tieneFuego)
        {
            bateriaActual -= consumoPorSegundo * Time.deltaTime;
            
            fuego.Play();
            linterna.Play();
            quemando = true;
        }
        else
        {
            quemando = false;
            fuego.Stop();
            linterna.Stop();
        }

        // Recoger una pila y recargar la carga
        foreach (Transform objetoTransform in pila)
        {
            float distancia = Vector3.Distance(transform.position, objetoTransform.position);

            if (distancia < distanciaUmbral && Input.GetKeyDown(KeyCode.E))
            {
                RecargarBateria();
                objetoTransform.position = new Vector3(Random.Range(-18f, 20f), 1.5f, Random.Range(-8f, 60f));
            }
        }

        if(tieneFuego){
            transform.parent = parentObject;
            transform.position = targetObject.position;
            transform.rotation = targetObject.rotation;    
        }
        // Asegurarse de que la carga no se agote más allá del mínimo
        bateriaActual = Mathf.Max(bateriaActual, 0);

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
