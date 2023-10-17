using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

    [SerializeField] public int num;

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
        transform.Rotate(Vector3.up, 90f, Space.World);
    }
    
}
