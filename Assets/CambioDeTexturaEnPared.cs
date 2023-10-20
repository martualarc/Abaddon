using System.Collections;
using UnityEngine;

public class CambioDeTexturaEnPared : MonoBehaviour
{
    public Renderer[] paredes; 
    public Texture texturaNormal; 
    public Texture texturaAlterna1;
    public Texture texturaAlterna2; 
    public float tiempoParaIniciar = 4.0f; 
    public float tiempoDeAlternancia = 0.1f;
    public float tiempoDeDuracion = 20.0f;

    private bool alternando = false;

    private void Start()
    {
        StartCoroutine(ControlDeTexturasCoroutine());
    }

    IEnumerator ControlDeTexturasCoroutine()
    {
        yield return new WaitForSeconds(tiempoParaIniciar);

        float tiempoTranscurrido = 0.0f;

        while (tiempoTranscurrido < tiempoDeDuracion)
        {
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
