using UnityEngine;

public class SpawnNivel2 : MonoBehaviour
{
    public GameObject demonio;
    private BarraDeMiedo bMiedo;
    private Flashlight scriptFlash;

    void Start()
    {
        bMiedo = GameObject.FindWithTag("Player").GetComponent<BarraDeMiedo>();
        bMiedo.enabled = true;

        scriptFlash = GameObject.FindWithTag("Linterna").GetComponent<Flashlight>();

        demonio.SetActive(false);
        Invoke("Spawnear", 10f);
    }

    void Spawnear()
    {
        GameObject jugador = GameObject.Find("player");

        if (jugador != null)
        {
            Vector3 posicionJugador = jugador.transform.position;
            Vector3 offset = jugador.transform.forward * 2.0f;

            float altura = -3;

            Vector3 posicionDemonio = posicionJugador + new Vector3(offset.x, altura, offset.z);

            demonio.transform.position = posicionDemonio;
        }

        demonio.SetActive(true);
        bMiedo.demonAlive = true;
        scriptFlash.demonAlive = true;
    }
}
