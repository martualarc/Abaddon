using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMove : MonoBehaviour
{
    public int sceneIndex;

    bool load;
    void OnTriggerEnter(){
        if(!load){
            load = true;
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene(){
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
        Scene nextScene = SceneManager.GetSceneAt(1);
        SceneManager.MoveGameObjectToScene(gameObject, nextScene);
        yield return null;
        SceneManager.UnloadScene(sceneIndex - 1);
    }
}
