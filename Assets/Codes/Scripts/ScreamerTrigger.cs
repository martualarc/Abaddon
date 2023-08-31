using UnityEngine;


public class ScreamerTrigger : MonoBehaviour
{
    public GameObject screamerObject; // Asigna el objeto del Screamer en el Inspector.
    public float delay = 1.0f; // Tiempo de retraso antes de activar el Screamer.


    private bool hasActivated = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("Player"))
        {
            hasActivated = true;
            Invoke("ActivateScreamer", delay);
        }
    }


    private void ActivateScreamer()
    {
        screamerObject.SetActive(true); // Activa el objeto del Screamer.
    }
}
