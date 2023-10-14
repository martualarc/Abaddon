using UnityEngine;
using System.Collections;

public class TangibleKey: MonoBehaviour
{
    [SerializeField] public bool renderEnable = false;
    Renderer keyRender;
    Key scriptKey;
    void Awake()
    {
        scriptKey = GameObject.FindWithTag("Player").GetComponent<Key>();
        keyRender = GetComponent<MeshRenderer>();
        keyRender.enabled = renderEnable;
        //if(SceneManager.GetActiveScene().name != "hall")..
    }
    void Start()
    {
        if (scriptKey.isKey) destroy();
        //cuando vuelve al hall no aparecera la llave de nuevo
    }
    public void destroy(){
        //reproducir un sonido de recogida
        //StartCoroutine(Audio.Sonido(keySound, 0f));
        keyRender.enabled = false;
        GetComponent<Collider>().enabled = false;
    }
    public void finishRoom(){
        keyRender.enabled = true;
    }
}