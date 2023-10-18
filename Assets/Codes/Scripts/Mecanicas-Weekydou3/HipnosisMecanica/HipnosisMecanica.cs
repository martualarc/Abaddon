using UnityEngine;

public class HipnosisMecanica : MonoBehaviour
{
    public float tiempoRequerido = 15f; // Tiempo requerido en segundos para completar la hipnosis
    private float tiempoActual; // Tiempo transcurrido

    public Camera viewCamera;

    private void Start()
    {
        tiempoActual = 0f;
    }

    private void Update()
    {
        if (EstaMirandoObjeto())
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

    private bool EstaMirandoObjeto()
    {
        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity))
        {
            VideoPlayer hipnoVid = hit.collider.GetComponent<VideoPlayer>();
            if (hipnoVid != null)
            {
                //esta mirando el video
                return true
            }
            else
            {
                //no esta mirando el video
                return false
            }
        }
        //no esta mirando el video
        return false;
    }

    private void CompletarHipnosis()
    {
        Debug.Log("El jugador ha completado la hipnosis con éxito");
        // Agrega aquí la lógica para completar la hipnosis según tus requerimientos
    }
}
