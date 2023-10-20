using UnityEngine;

public class SpawnNivel8 : MonoBehaviour
{
    public GameObject demonio;

    void Start()
    {
        demonio.SetActive(false);
        Invoke("Spawnear", 20f);
    }

    void Spawnear()
    {
        demonio.transform.position = new Vector3(9.39f, 0.54f, 4.831296f);
        demonio.SetActive(true);
    }
}
