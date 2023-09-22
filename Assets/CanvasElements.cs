using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasElements : MonoBehaviour
{
    private string currentScene;
    public GameObject adivinanza;
    AdivinanzaPuzzle scriptAdivinanza;
    public GameObject[] UIElements;
    void Start()
    {
        scriptAdivinanza = adivinanza.GetComponent<AdivinanzaPuzzle>();
        adivinanza.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        switch(currentScene){
            case "bosque":
            adivinanza.SetActive(false);
            foreach(GameObject obj in UIElements) {
            obj.GetComponent<CanvasRenderer>().SetAlpha(0f);
            }
            break;

            case "hall":
            adivinanza.SetActive(false);
            break;

            case "nivel_uno":
            Invoke("ActivarAdivinanza", 3);
            break;

            default:
            Debug.Log("No pasa nada con la UI.");
            break;
        }
    }

    private void ActivarAdivinanza(){
        adivinanza.SetActive(true);
    }
}
