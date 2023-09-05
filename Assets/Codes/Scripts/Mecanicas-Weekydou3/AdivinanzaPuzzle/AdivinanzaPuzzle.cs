using UnityEngine;
using UnityEngine.UI;

public class AdivinanzaPuzzle : MonoBehaviour
{
    public string respuestaCorrecta = "RespuestaCorrecta"; // La respuesta correcta que el jugador debe adivinar
    public InputField inputText; // Referencia al campo de texto en el que el jugador ingresará su respuesta
    public Text mensajeResultado; // Referencia al Text que mostrará el mensaje de resultado
    public Button botonIntentarDeNuevo; // Referencia al botón para intentar de nuevo
    public int maximoIntentos = 3; // Número máximo de intentos permitidos
    private int intentosRestantes; // Número de intentos restantes

    private void Start()
    {
        intentosRestantes = maximoIntentos;
        ActualizarMensajeResultado("");
        botonIntentarDeNuevo.gameObject.SetActive(false);
    }

    public void VerificarRespuesta()
    {
        string respuestaIngresada = inputText.text.Trim(); // Obtener la respuesta ingresada por el jugador y eliminar espacios en blanco
        if (respuestaIngresada.Equals(respuestaCorrecta, System.StringComparison.OrdinalIgnoreCase)) // Comparar la respuesta sin importar mayúsculas o minúsculas
        {
            ActualizarMensajeResultado("¡Respuesta correcta!");
            DesactivarInputYBoton();
        }
        else
        {
            intentosRestantes--;
            if (intentosRestantes <= 0)
            {
                ActualizarMensajeResultado("¡Intentos agotados! La respuesta correcta era: " + respuestaCorrecta);
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
        intentosRestantes = maximoIntentos;
        inputText.text = "";
        inputText.interactable = true;
        mensajeResultado.text = "";
        botonIntentarDeNuevo.gameObject.SetActive(false);
    }
}
