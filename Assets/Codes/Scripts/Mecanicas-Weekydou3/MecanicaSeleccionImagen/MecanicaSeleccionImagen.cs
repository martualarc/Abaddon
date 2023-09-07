using UnityEngine;
using UnityEngine.UI;

public class MecanicaSeleccionImagen : MonoBehaviour
{
    public Image imagenMostrada; // Referencia a la imagen que se mostrará al jugador
    public Button botonCaraReal; // Botón para seleccionar "Cara Real"
    public Button botonMascara; // Botón para seleccionar "Máscara"
    public Text mensajeResultado; // Mensaje para mostrar el resultado
    public Sprite[] imagenes; // Array de imágenes que se mostrarán al jugador
    private int indiceImagenActual = 0; // Índice de la imagen actual
    private bool seleccionCorrecta = false; // Indica si la selección fue correcta

    private void Start()
    {
        botonCaraReal.onClick.AddListener(SeleccionCaraReal);
        botonMascara.onClick.AddListener(SeleccionMascara);
        ActualizarImagen();
    }

    private void ActualizarImagen()
    {
        imagenMostrada.sprite = imagenes[indiceImagenActual];
        mensajeResultado.text = "";
        seleccionCorrecta = false;
    }

    private void SeleccionCaraReal()
    {
        if (!seleccionCorrecta)
        {
            mensajeResultado.text = "¡Selección incorrecta! Inténtalo de nuevo.";
        }
        else
        {
            SiguienteImagen();
        }
    }

    private void SeleccionMascara()
    {
        if (!seleccionCorrecta)
        {
            mensajeResultado.text = "¡Selección incorrecta! Inténtalo de nuevo.";
        }
        else
        {
            SiguienteImagen();
        }
    }

    private void SiguienteImagen()
    {
        indiceImagenActual++;
        if (indiceImagenActual < imagenes.Length)
        {
            ActualizarImagen();
        }
        else
        {
            mensajeResultado.text = "¡Has completado la serie de imágenes!";
            botonCaraReal.interactable = false;
            botonMascara.interactable = false;
        }
    }

    // Esta función se puede llamar desde otros scripts para reiniciar el juego
    public void ReiniciarJuego()
    {
        indiceImagenActual = 0;
        botonCaraReal.interactable = true;
        botonMascara.interactable = true;
        ActualizarImagen();
    }
}
