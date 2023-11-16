using UnityEngine;

public class SpawnNivel5 : MonoBehaviour
{
    public GameObject demonio;
    private BarraDeMiedo bMiedo;
    private Flashlight scriptFlash;
    public ScriptBarraDemon barraDemon;

    void Start()
    {
        bMiedo = GameObject.FindWithTag("Player").GetComponent<BarraDeMiedo>();
        bMiedo.enabled = true;

        barraDemon = GameObject.Find("barraDemon").GetComponent<ScriptBarraDemon>();

        scriptFlash = GameObject.FindWithTag("Linterna").GetComponent<Flashlight>();
        // Desactivar el demonio al inicio
        //demonio.SetActive(false);

        // Invocar la función Spawnear después de 12 segundos
        Invoke("Spawnear", 0f);
    }

    void Spawnear()
    {
        GameObject jugador = GameObject.Find("player");

        if (jugador != null)
        {
            //Vector3 posicionDemonio = new Vector3(9.39999962f, 0.497499943f, 0.959999979f);

            // Establecer la posición del demonio
            //demonio.transform.position = posicionDemonio;
        }

        // Activar el demonio
        //demonio.SetActive(true);
        bMiedo.demonAlive = true;
        scriptFlash.demonAlive = true;
        barraDemon.enabled = true;
    }
}
