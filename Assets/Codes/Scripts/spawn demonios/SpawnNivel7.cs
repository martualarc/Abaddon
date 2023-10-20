using UnityEngine;

public class SpawnNivel7 : MonoBehaviour
{
    public static SpawnNivel7 spawn7;
    public GameObject demonio;

    void Start()
    {
        demonio.SetActive(false);
        Invoke("Spawnear", 12f);
    }
    
    public void Spawnear()
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
    }
}
