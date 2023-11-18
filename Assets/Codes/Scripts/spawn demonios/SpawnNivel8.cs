using UnityEngine;

public class SpawnNivel8 : MonoBehaviour
{
    public GameObject demonio;
    private BarraDeMiedo bMiedo;
    private Flashlight scriptFlash;
    public ScriptBarraDemon barraDemon;

    void Start()
    {
        bMiedo = GameObject.FindWithTag("Player").GetComponent<BarraDeMiedo>();
        bMiedo.enabled = false;

        barraDemon = GameObject.Find("barraDemon").GetComponent<ScriptBarraDemon>();

        scriptFlash = GameObject.FindWithTag("Linterna").GetComponent<Flashlight>();
        demonio.SetActive(false);
        Invoke("Spawnear", 20f);
    }

    void Spawnear()
    {
        GameObject jugador = GameObject.Find("player");

        if (jugador != null){
        demonio.transform.position = new Vector3(9.39f, 0.54f, 4.831296f);
        demonio.SetActive(true);
        }

        demonio.SetActive(true);
        bMiedo.demonAlive = true;
        scriptFlash.demonAlive = true;
        barraDemon.enabled = true;
        bMiedo.enabled = true;
    }
}
