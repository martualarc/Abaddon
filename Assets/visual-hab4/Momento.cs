using UnityEngine;
using UnityEngine.Video;

public class Momento : MonoBehaviour{
    
    public ImageNegro imgScript;
    public Key playerScript;
    public bool first;
    private VideoPlayer video;
    GameObject[] objetosConTag;

    void Start()
    {
        imgScript = GameObject.FindGameObjectWithTag("select").GetComponent<ImageNegro>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Key>();      
        video = GameObject.FindGameObjectWithTag("playback").GetComponent<VideoPlayer>();  
        first = true;
        objetosConTag = GameObject.FindGameObjectsWithTag("scorpioTele");
    }

    void Update()
    {
        if(playerScript.isKey && first){
            Invoke("finalizarMomento", 0.3f);
            first = false;
        }
    }

    public void elMomento()
    {
        video.playbackSpeed = 0.1f;
        imgScript.Mostrar(2.5f);
        video.playbackSpeed = 2.6f;
        foreach (GameObject objeto in objetosConTag)
        {
            ScorpioTele scorpioTeleScript = objeto.GetComponent<ScorpioTele>();
                scorpioTeleScript.Mover();
        }
    }
    public void finalizarMomento()
    {
        video.playbackSpeed = 0.1f;
        imgScript.Mostrar(1f);
        video.playbackSpeed = 1f;
        foreach (GameObject objeto in objetosConTag)
        {
            ScorpioTele scorpioTeleScript = objeto.GetComponent<ScorpioTele>();
            scorpioTeleScript.Volver();
        }
    }
}