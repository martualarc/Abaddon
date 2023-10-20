using UnityEngine;

public class spawnLlave : MonoBehaviour
{
    public GameObject objetoParaSpawnear;
    public float tiempoParaSpawnear = 26.0f;

    private void Start()
    {
        objetoParaSpawnear.SetActive(false);
        Invoke("SpawnearObjeto", tiempoParaSpawnear);
    }

    private void SpawnearObjeto()
    {
        objetoParaSpawnear.SetActive(true);
    }
}
