using UnityEngine;
using UnityEngine.Video;

public class CuboController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public FadingScript fadingScript;

    private float fadeStartTime; // Tiempo en segundos antes del final del video para comenzar el desvanecimiento.

    void Start()
    {
        // Configura el tiempo en el que deseas que comience el desvanecimiento antes del final del video.
        fadeStartTime = (float)(videoPlayer.clip.length - 5.0);

        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        // Verifica si el video ha llegado al tiempo de inicio de desvanecimiento.
        if (vp.time >= fadeStartTime)
        {
            // Inicia el desvanecimiento del cubo.
            fadingScript.IniciarDesvanecimiento(5.0f); // Cambia la duración según tus necesidades.
        }
    }
}
