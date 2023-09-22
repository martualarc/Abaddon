using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManage : MonoBehaviour
{
    public static CanvasManage instance;
    private string currentScene;
    void Start()
    {
        if(instance != null){
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
