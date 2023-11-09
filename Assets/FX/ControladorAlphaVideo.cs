using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // Agrega esta línea para acceder a SceneManager

public class ControladorAlphaVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float velocidadDesvanecimiento = 0.02f;

    private Material material;
    private float alpha = 0.0f; // Inicializa el valor de alfa en 0

    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("No se ha asignado un VideoPlayer. Asigna el VideoPlayer en el Inspector.");
            return;
        }

        // Obtenemos el material del objeto con el shader "UI/Default"
        material = GetComponent<Renderer>().material;

        // Asegúrate de que el material tenga un Shader con un canal alfa


        // Suscribirse al evento SceneManager.sceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            // Reduce gradualmente el valor de alfa
            alpha -= velocidadDesvanecimiento * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha); // Asegura que el valor de alfa esté en el rango [0, 1]

            // Actualiza el canal alfa del material
            Color color = material.color;
            color.a = alpha;
            material.color = color;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verificar si se ha cargado la escena "nivel_tres"
        if (scene.name == "nivel_tres")
        {
            // Comenzar la reproducción del video
            videoPlayer.Play();
            alpha = 0.3f;
        }
        else
        {
            // Restablecer el valor de alfa para hacer el plano transparente en otras escenas
            alpha = 0.0f;
            Color color = material.color;
            color.a = alpha;
            material.color = color;
        }
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento cuando se destruye el objeto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
