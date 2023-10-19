using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

    [SerializeField] public bool puertaPar = false;
    [SerializeField] public float xpos = 1.5f;
    [SerializeField] public float zpos = 1.3f;

    Vector3 newPosition;

    [SerializeField] public int num;

    public void Start(){
        newPosition = transform.position;
    }
    public bool interact(bool keyIsKey, int keyNum)
    {
        if (keyIsKey && keyNum == num)
        {
            openDoor(); // Llamamos a la función para abrir la puerta
            return true;
        }
        else
        {
            Debug.Log("La puerta está cerrada o necesitas una llave.");
            return false;
            //agregar logica para que te avise que te falta la llave o que te diga que ya no se puede entrar
        }
    }
    void openDoor()
    {
        // lógica para la animación de abrir la puerta
        // animación simple: abrir la puerta girándola sobre su eje Y durante 1 segundo.
        if(puertaPar)
        {
            newPosition.x =  newPosition.x - zpos;
            newPosition.z = newPosition.z - xpos;
            transform.position = newPosition;
            transform.Rotate(Vector3.up, 90f, Space.World);
        }
        else transform.Rotate(Vector3.up, 90f, Space.World);
    }
    
}
