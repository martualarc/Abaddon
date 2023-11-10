using UnityEngine;

public class spawnLlave : MonoBehaviour
{
    public float tiempoParaSpawnear = 26.0f;
    private TangibleKey tangKey;

    private void Start()
    {
        tangKey = GameObject.FindWithTag("Key").GetComponent<TangibleKey>();
        Invoke("SpawnearObjeto", tiempoParaSpawnear);
    }

    private void SpawnearObjeto()
    {
        tangKey.finishRoom();
    }
}
