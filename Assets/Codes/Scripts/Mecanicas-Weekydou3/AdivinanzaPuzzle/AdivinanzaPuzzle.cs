using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AdivinanzaPuzzle : MonoBehaviour
{
    public string respuestaCorrecta = "Abaddon"; // La respuesta correcta que el jugador debe adivinar
    public InputField inputText; // Referencia al campo de texto en el que el jugador ingresará su respuesta
    public Text mensajeResultado; // Referencia al Text que mostrará el mensaje de resultado
    public Button botonIntentarDeNuevo; // Referencia al botón para intentar de nuevo
    public int maximoIntentos = 3; // Número máximo de intentos permitidos
    private int intentosRestantes; // Número de intentos restantes
    public GameObject[] juego;
    public cameraMove cameraScript;
    public TangibleKey tangKey;

    

    private void Start()
    {
        inputText.interactable = true;
        intentosRestantes = maximoIntentos;
        ActualizarMensajeResultado("");
        botonIntentarDeNuevo.onClick.AddListener(IntentarDeNuevo);
        botonIntentarDeNuevo.gameObject.SetActive(false);
        
    }

    void Update(){

         if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Return key was released.");
            VerificarRespuesta();
        }

    }

    public void VerificarRespuesta()
    {
        string respuestaIngresada = inputText.text.Trim(); // Obtener la respuesta ingresada por el jugador y eliminar espacios en blanco
        if (respuestaIngresada.Equals(respuestaCorrecta, System.StringComparison.OrdinalIgnoreCase)) // Comparar la respuesta sin importar mayúsculas o minúsculas
        {
            ActualizarMensajeResultado("Respuesta correcta!");
            Invoke("DesactivarJuego", 3);
            
            tangKey = GameObject.FindWithTag("Key").GetComponent<TangibleKey>();
            tangKey.finishRoom();
        }
        else
        {
            intentosRestantes--;
            inputText.text = "";
            if (intentosRestantes <= 0)
            {
                ActualizarMensajeResultado("Intentos agotados!");
                DesactivarInputYBoton();
            }
            else
            {
                ActualizarMensajeResultado("Respuesta incorrecta. Intentos restantes: " + intentosRestantes);
            }
        }
    }

    private void ActualizarMensajeResultado(string mensaje)
    {
        mensajeResultado.text = mensaje;
    }

    private void DesactivarInputYBoton()
    {
        inputText.interactable = false;
        botonIntentarDeNuevo.gameObject.SetActive(true);
    }

    public void IntentarDeNuevo()
    {
        Debug.Log("Intentar de nuevo");
        intentosRestantes = maximoIntentos;
        inputText.text = "";
        inputText.interactable = true;
        mensajeResultado.text = "";
        botonIntentarDeNuevo.gameObject.SetActive(false);
    }

    public void DesactivarJuego(){
        foreach(GameObject obj in juego) {
            obj.SetActive(false);
            }
    }

}
