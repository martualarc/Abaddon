using System.Collections;
using UnityEngine;

public class CambioDeTexturaEnPared : MonoBehaviour
{
    public Renderer[] paredes; // Lista de Renderers de las paredes
    public Texture texturaNormal; // Textura normal
    public Texture texturaAlterna1; // Primera textura alternativa (por ejemplo, negro)
    public Texture texturaAlterna2; // Segunda textura alternativa (por ejemplo, rojo)
    public float tiempoParaIniciar = 4.0f; // Tiempo en segundos antes de iniciar la alternancia
    public float tiempoDeAlternancia = 0.1f; // Tiempo en segundos para alternar entre texturas
    public float tiempoDeDuracion = 20.0f; // Tiempo en segundos para la duración de la alternancia

    private bool alternando = false;

    private void Start()
    {
        // Inicia una corrutina para controlar el cambio de texturas
        StartCoroutine(ControlDeTexturasCoroutine());
    }

    IEnumerator ControlDeTexturasCoroutine()
    {
        yield return new WaitForSeconds(tiempoParaIniciar);

        float tiempoTranscurrido = 0.0f;

        while (tiempoTranscurrido < tiempoDeDuracion)
        {
            // Alterna entre las dos texturas alternas (negro y rojo)
            if (alternando)
            {
                foreach (var pared in paredes)
                {
                    if (pared.material.mainTexture == texturaNormal)
                    {
                        pared.material.mainTexture = texturaAlterna1;
                    }
                    else if (pared.material.mainTexture == texturaAlterna1)
                    {
                        pared.material.mainTexture = texturaAlterna2;
                    }
                    else
                    {
                        pared.material.mainTexture = texturaAlterna1;
                    }
                }
            }
            else
            {
                foreach (var pared in paredes)
                {
                    pared.material.mainTexture = texturaAlterna2;
                }
            }

            alternando = !alternando;
            tiempoTranscurrido += tiempoDeAlternancia;

            yield return new WaitForSeconds(tiempoDeAlternancia);
        }
        if (tiempoTranscurrido >= tiempoDeDuracion)
        {
            foreach (var pared in paredes)
                {
                    pared.material.mainTexture = texturaNormal;
                }
        }
    }
}
