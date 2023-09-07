using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sceneEntrance : MonoBehaviour
{
    public string lastExit;
    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExit){
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
