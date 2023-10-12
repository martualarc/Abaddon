using UnityEngine;

public class SpawnNivel8 : MonoBehaviour
{
    public GameObject demonio;

    void Start()
    {
        demonio.SetActive(false);
        Invoke("Spawnear", 16f);
    }

    void Spawnear()
    {
        demonio.transform.position = new Vector3(7.326992f, 2.82f, 5.672342f);
        demonio.SetActive(true);
    }
}
