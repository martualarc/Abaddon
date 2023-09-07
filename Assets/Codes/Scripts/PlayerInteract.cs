using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

    Collider doorCollider;
    public GameObject keyObj;
    Key scriptKey;
//keyObj tiene que ser el nombre utilizado en el editor de Unity? No.
/*
Nombre en el Inspector: En el Inspector de Unity, cuando agregas el 
script a un GameObject, verás la variable keyObj en el Inspector. 
Puedes arrastrar y soltar el GameObject que tiene el script
 "MiScript" adjunto en esa variable.
*/
    [SerializeField] private float interactDistance = 4f;
    public LayerMask interactLayers;

    void Start() {
//apuntar desde keyObj al componente (script) del objeto de clase Key
    scriptKey = keyObj.GetComponent<Key>();
//initialize door: Door
    }
    void Update() {
        
        if (Input.GetMouseButtonDown(0)) // 0 representa el clic izquierdo del mouse
        {
            Debug.Log("Click");
            TryInteract();
        }
        if (Input.GetMouseButtonDown(1)) // linterna click derecho
        {
            Debug.Log("Click derecho");
            // TryFlashlight();
        }
    }

    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayers))
        {
            // Flashlight scriptFlash = hit.collider.GetComponent<Flashlight>();
            Door scriptDoor = hit.collider.GetComponent<Door>();
            doorCollider = hit.collider.GetComponent<Collider>();
            if (scriptDoor != null)
            {
                Debug.Log("Es una puerta.");
                if (scriptDoor.interact(scriptKey.isKey, scriptKey.num))
                {
                    scriptKey.changeNum(scriptDoor.num);
                    doorCollider.isTrigger = true;
                    Debug.Log("La puerta se abre");
                }
                else {
                    Debug.Log("Eso no es posible");
                }
            }
           // else if (scriptFlash != null) {
                //desarrollar
           // }
            //interactuar con puzzle
            //otra componente posible para interactuar
        }
    }
}
