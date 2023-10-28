using UnityEngine;

public class SpawnNivel2 : MonoBehaviour
{
    public GameObject demonio;
    private BarraDeMiedo bMiedo;
    private Flashlight scriptFlash;
    public ScriptBarraDemon barraDemon;
    private RainEffect rainEffect;

    void Start()
    {
        bMiedo = GameObject.FindWithTag("Player").GetComponent<BarraDeMiedo>();
        bMiedo.enabled = true;

        barraDemon = GameObject.Find("barraDemon").GetComponent<ScriptBarraDemon>();

        scriptFlash = GameObject.FindWithTag("Linterna").GetComponent<Flashlight>();

        demonio.SetActive(false);
        Invoke("Spawnear", 7f);

        rainEffect = GameObject.FindObjectOfType<RainEffect>();
    }

    void Spawnear()
    {
        GameObject jugador = GameObject.Find("player");

        if (jugador != null)
        {
            Vector3 posicionJugador = jugador.transform.position;
            Vector3 offset = jugador.transform.forward * 2.0f;

            float altura = 1f;

            Vector3 posicionDemonio = posicionJugador + new Vector3(offset.x, altura, offset.z);

            demonio.transform.position = posicionDemonio;
        }

        demonio.SetActive(true);
        bMiedo.demonAlive = true;
        scriptFlash.demonAlive = true;
        barraDemon.enabled = true;

        rainEffect.StartRain();
    }
}
