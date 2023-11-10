using UnityEngine;
using UnityEngine.UI;

public class ImageNegro : MonoBehaviour
{
    public Image img;

    void Start()
    {
        img.enabled = false;
    }
    void Update(){

    }
    public void Mostrar(float tiempoVisible)
    {
        img.enabled = true;
        Debug.Log("mostrando");
        Invoke("Sacar", tiempoVisible);
    }
    void Sacar()
    {
        img.enabled = false;
    }
}
