using UnityEngine;
using System.Collections;

public class TangibleKey: MonoBehaviour
{
    [SerializeField] public bool renderEnable = false;
    Renderer keyRender;
    void Awake()
    {
        keyRender = GetComponent<MeshRenderer>();
        keyRender.enabled = renderEnable;
        //if(SceneManager.GetActiveScene().name != "hall")..
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