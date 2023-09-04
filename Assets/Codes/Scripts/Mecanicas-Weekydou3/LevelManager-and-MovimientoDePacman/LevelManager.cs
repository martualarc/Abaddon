using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject screamerImage; // Referencia a la imagen del "screamer"

    private void Start()
    {
        screamerImage.SetActive(false); // Asegurarse de que la imagen del "screamer" esté desactivada al inicio
    }

    // Método para mostrar el "screamer"
    public void ShowScreamer()
    {
        screamerImage.SetActive(true);
        // Lógica para mostrar el "screamer" (puedes usar animaciones, efectos de sonido, etc.)
    }

    // Método para reiniciar el nivel (llámalo cuando el jugador colisione con un fantasma, por ejemplo)
    public void RestartLevel()
    {
        // Lógica para reiniciar el nivel
    }
}
