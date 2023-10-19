using UnityEngine;
using System.Collections;

public class FadingScript : MonoBehaviour
{
    private Material _myMaterial;
    private Coroutine _currentFade;

    // Define una enumeración para realizar el desvanecimiento.
    // Pásale el material para desvanecer, la opacidad objetivo (0 = transparente, 1 = opaco) y la duración en segundos.
    IEnumerator FadeTo(Material material, float targetOpacity, float duration)
    {
        // Almacena el color actual del material y su opacidad inicial.
        Color color = material.color;
        float startOpacity = color.a;

        // Realiza un seguimiento de cuántos segundos hemos estado desvaneciendo.
        float t = 0;

        while (t < duration)
        {
            // Avanza el desvanecimiento un fotograma.
            t += Time.deltaTime;
            // Convierte el tiempo en un factor de interpolación entre 0 y 1.
            float blend = Mathf.Clamp01(t / duration);

            // Mezcla hacia la opacidad correspondiente entre el inicio y el objetivo.
            color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

            // Aplica el color resultante al material.
            material.color = color;

            // Espera un fotograma y repite.
            yield return null;
        }
    }

    void Start()
    {
        // Obtiene el material del objeto al que se adjunta el script.
        _myMaterial = GetComponent<Renderer>().material;
    }

    // Inicia el desvanecimiento del objeto.
    public void IniciarDesvanecimiento(float duracion)
    {
        if (_currentFade != null)
        {
            // Detén la corutina de desvanecimiento en curso si existe.
            StopCoroutine(_currentFade);
        }

        // Inicia una nueva corutina para desvanecer el objeto alfa a 0 durante la duración especificada.
        _currentFade = StartCoroutine(FadeTo(_myMaterial, 0f, duracion));
    }

    // Restaura la opacidad del objeto.
    public void RestaurarOpacidad()
    {
        if (_currentFade != null)
        {
            // Detén la corutina de desvanecimiento en curso si existe.
            StopCoroutine(_currentFade);
        }

        // Restaura la opacidad del objeto al valor original.
        _myMaterial.color = new Color(_myMaterial.color.r, _myMaterial.color.g, _myMaterial.color.b, 1f);
    }
}
