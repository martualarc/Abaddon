using UnityEngine;

public class luz : MonoBehaviour
{
    public GameObject doubulia;
    public Light luz1;
    public Light luz2;
    public Light luz3;

    private void Start()
    {
        luz1.enabled = true;
        luz2.enabled = true;
        luz3.enabled = true;
    }

private void Update()
{
    GameObject doubuliaObject = GameObject.Find("doubulia");

    if (doubuliaObject != null)
    {
        Debug.Log("Doubulia encontrado");
        luz1.enabled = false;
        luz2.enabled = false;
        luz3.enabled = false;
    }
        if (doubuliaObject == null)
    {
        Debug.Log("Doubulia no encontrado");
        luz1.enabled = true;
        luz2.enabled = true;
        luz3.enabled = true;
    }
}

}
