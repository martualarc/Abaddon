using System.Collections;
using UnityEngine;

public class Nivel7 : MonoBehaviour
{
    public GameObject[] maniquies;
    public Light luzFlash;
    public Light luzFlash2;
    public GameObject imagenMensaje;
    public GameObject demonioPrefab;

    public float duracionMensaje;
    public float retrasoDemonio;

    private bool isFlashing = false;

    void Start()
    {
        imagenMensaje.SetActive(false);

        luzFlash.enabled = false;
        luzFlash2.enabled = false;

        foreach (GameObject maniqui in maniquies)
        {
            maniqui.SetActive(true);
        }

        StartCoroutine(SequenciaNivel7());
    }

    IEnumerator SequenciaNivel7()
    {
        yield return new WaitForSeconds(3f);

        isFlashing = true;
        luzFlash.enabled = true;
        luzFlash2.enabled = true;

        StartCoroutine(EfectoFlash());
        StartCoroutine(EfectoFlash2());

        yield return new WaitForSeconds(2f);
        imagenMensaje.SetActive(true);
        yield return new WaitForSeconds(duracionMensaje);

        isFlashing = false;

        imagenMensaje.SetActive(false);
        yield return new WaitForSeconds(2f);

        isFlashing = true;
        StartCoroutine(EfectoFlash());
        StartCoroutine(EfectoFlash2());

        yield return new WaitForSeconds(4f);

        isFlashing = false;
        luzFlash.enabled = false;
        luzFlash2.enabled = false;
    }

    IEnumerator EfectoFlash()
    {
        while (isFlashing)
        {
            luzFlash.enabled = !luzFlash.enabled;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator EfectoFlash2()
    {
        while (isFlashing)
        {
            luzFlash2.enabled = !luzFlash2.enabled;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
