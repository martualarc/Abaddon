using UnityEngine;

public class DoubuliaDrop : MonoBehaviour
{
    public GameObject keyObject;
    private Vector3 doubuliaPosition;

    public float heightOffset = 1f; // Ajusta esta variable para controlar la altura de la llave

    void Start()
    {
        //keyScript = GetComponent<Key>();
    }

    void Update()
    {
        GameObject demonioObj = GameObject.Find("doubulia");
        if (demonioObj != null)
        {
            doubuliaPosition = demonioObj.transform.position + Vector3.up * heightOffset; // Añade la altura deseada
        }

        if (demonioObj == null)
        {
            keyObject.SetActive(true);
            keyObject.transform.position = doubuliaPosition;
            //keyScript.GetKey();
        }
    }
}
