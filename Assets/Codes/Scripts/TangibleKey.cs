using UnityEngine;
using System.Collections;

public class TangibleKey: MonoBehaviour
{
    [SerializeField] public bool renderEnable = false;
    Renderer keyRender;
    Light keyLight;
    void Awake()
    {
        keyRender = GetComponent<MeshRenderer>();
        keyRender.enabled = renderEnable;
        keyLight = GameObject.Find("luzLlave").GetComponent<Light>();
        keyLight.enabled = renderEnable;
        //if(SceneManager.GetActiveScene().name != "hall")..
    }

    public void destroy(){
        //reproducir un sonido de recogida
        //StartCoroutine(Audio.Sonido(keySound, 0f));
        keyRender.enabled = false;
        keyLight.enabled = false;
        GetComponent<Collider>().enabled = false;
    }
    public void finishRoom(){
        transform.position -= new Vector3(0, 5, 0);
        keyRender.enabled = true;
        keyLight.enabled = true;
    }
}