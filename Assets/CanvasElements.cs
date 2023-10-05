using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasElements : MonoBehaviour
{
    private string currentScene;
    public GameObject adivinanza;
    public GameObject nota;
    public GameObject selecImg;
    AdivinanzaPuzzle scriptAdivinanza;
    MecanicaSeleccionImagen scriptSeleccion;

    public GameObject[] UIElements;
    
    void Start()
    {
        scriptAdivinanza = adivinanza.GetComponent<AdivinanzaPuzzle>();
        scriptSeleccion = selecImg.GetComponent<MecanicaSeleccionImagen>();
        adivinanza.SetActive(false);
        selecImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        switch(currentScene){
            case "bosque":
            foreach(GameObject obj in UIElements) {
            obj.GetComponent<CanvasRenderer>().SetAlpha(0f);
            }
            nota.GetComponent<CanvasRenderer>().SetAlpha(0f); 
            break;

            case "hall":
            adivinanza.SetActive(false);
            break;

            case "nivel_uno":
            Invoke("ActivarAdivinanza", 3);
            break;

            case "nivel_dos":
            foreach(GameObject obj in UIElements) {
            obj.GetComponent<CanvasRenderer>().SetAlpha(1f);
            }
            break;

            case "nivel_cuatro":
            Invoke("ActivarSelect", 3);
            break;

            default:
            Debug.Log("No pasa nada con la UI.");
            break;
        }
    }

    private void ActivarAdivinanza(){
        adivinanza.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void ActivarSelect(){
        selecImg.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
