using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;


    void Start() {

    }
    
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            PlayerPrefs.SetString("LastExitName",exitName);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
