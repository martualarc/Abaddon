using System.Collections;
using UnityEngine;

public class CambioDeColor : MonoBehaviour
{
     public float tiempoDeCambio = 2.0f;
    public Texture[] texturas;
    private Renderer rend;
    private int texturaActualIndex = 0;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        StartCoroutine(CambiarTexturaCoroutine());
    }

    IEnumerator CambiarTexturaCoroutine()
    {
        while (true)
        {
            rend.material.mainTexture = texturas[texturaActualIndex];

            texturaActualIndex = (texturaActualIndex + 1) % texturas.Length;

            yield return new WaitForSeconds(tiempoDeCambio);
        }
    }
}
