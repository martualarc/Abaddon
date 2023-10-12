using UnityEngine;

public class SpawnNivel5 : MonoBehaviour
{
    public GameObject demonio;

    void Start()
    {
        demonio.SetActive(false);
        Invoke("Spawnear", 12f);
    }

    void Spawnear()
    {
        demonio.transform.position = new Vector3(8.79f, 2.21f, 4.77f);
        demonio.SetActive(true);
    }
}
