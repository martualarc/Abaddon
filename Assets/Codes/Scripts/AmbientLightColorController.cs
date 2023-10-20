using UnityEngine;

public class AmbientLightColorController : MonoBehaviour
{

    public Light directionalLight;
    private Color[] lightColors;

    private int indiceColor;
    public Key scriptKey;
    Color color;


    private void Start()
    {
        scriptKey = GameObject.FindWithTag("Player").GetComponent<Key>();

        lightColors = new Color[]
        {
            new Color(1.0f, 0.0f, 0.0f), // Rojo
            new Color(0.0f, 1.0f, 0.0f), // Verde
            new Color(0.0f, 0.0f, 1.0f), // Azul
            new Color(1.0f, 1.0f, 0.0f), // Amarillo
            new Color(1.0f, 0.0f, 1.0f), // Magenta
            new Color(0.0f, 1.0f, 1.0f), // Cian
            new Color(1.0f, 0.5f, 0.0f), // Naranja
            new Color(0.5f, 0.0f, 0.5f), // Púrpura
            new Color(0.5f, 0.5f, 0.5f), // Gris
            new Color(1.0f, 1.0f, 1.0f)  // Blanco
        };
    }

    private void Update()
    {
        if (scriptKey.isKey)
        {
            ChangeLight();
        }
    }

    public void ChangeLight()
    {
        indiceColor = scriptKey.num;

        Debug.Log(scriptKey.num);
        Debug.Log(color);
        color = lightColors[scriptKey.num - 1];

        directionalLight.color = color;

        Debug.Log(color);
        Debug.Log(directionalLight.color);
    }
}