using UnityEngine;

public class ScorpioTele: MonoBehaviour
{
    public Transform obj;
    public Vector3 posAnt;
    public Quaternion rotAnt;

    [SerializeField] private Vector3 posicionDeseada;
    [SerializeField] private Vector3 rotacionDeseada;


    void Start()
    {
        obj = transform;
        posAnt = transform.position;
        rotAnt = transform.rotation;
    }
    void Update(){

    }
    public void Mover()
    {
        obj.position = posicionDeseada;
        obj.rotation = Quaternion.Euler(rotacionDeseada);
    }
    public void Volver(){
        obj.position = posAnt;
        obj.rotation = rotAnt;
    }

}
