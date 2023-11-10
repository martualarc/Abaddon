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
    public GameObject[] juego;
    private TangibleKey tangKey;
    private Momento momentoScript;
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
        if(indiceImagenActual == 0 || indiceImagenActual == 2 || indiceImagenActual == 6 || indiceImagenActual == 8){
            seleccionCorrecta = true;
        }
        if (!seleccionCorrecta)
        {
            mensajeResultado.text = "¡Selección incorrecta! Inténtalo de nuevo.";
        }
        else
        {
            SiguienteImagen();
        }
        seleccionCorrecta = false;
    }

    private void SeleccionMascara()
    {
        if(indiceImagenActual != 0 || indiceImagenActual != 2 || indiceImagenActual != 6 || indiceImagenActual != 8){
            seleccionCorrecta = true;
        }
        if (!seleccionCorrecta)
        {
            mensajeResultado.text = "¡Selección incorrecta! Inténtalo de nuevo.";
        }
        else
        {
            SiguienteImagen();
        }
        seleccionCorrecta = false;
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
            tangKey = GameObject.FindWithTag("Key").GetComponent<TangibleKey>();
            tangKey.finishRoom();
            momentoScript = GameObject.FindGameObjectWithTag("momento").GetComponent<Momento>();
            Invoke("DesactivarJuego", 3);
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

    public void DesactivarJuego(){
        momentoScript.elMomento();
        foreach(GameObject obj in juego) {
            obj.SetActive(false);
            }
    }
}
