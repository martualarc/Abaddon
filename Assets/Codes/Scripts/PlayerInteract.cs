using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

    public GameObject keyObj;
//keyObj tiene que ser el nombre utilizado en el editor de Unity? No.
/*
Nombre en el Inspector: En el Inspector de Unity, cuando agregas el 
script a un GameObject, verás la variable keyObj en el Inspector. 
Puedes arrastrar y soltar el GameObject que tiene el script
 "MiScript" adjunto en esa variable.
*/
    [SerializeField] private float interactDistance = 2f;
    public LayerMask interactLayers;

    void Start() {
//apuntar desde keyObj al componente (script) del objeto de clase Key
    Key scriptKey = keyObj.GetComponent<Key>
//initialize door: Door
    }
    void Update() {
        
        if (Input.GetMouseButtonDown(0)) // 0 representa el clic izquierdo del mouse
        {
            TryInteract();
        }
        if (Input.GetMouseButtonDown(1)) // linterna click derecho
        {
            // TryFlashlight();
        }
    }

    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayers))
        {
            Door scriptDoor = hit.collider.GetComponent<Door>();
            if (scriptDoor != null)
            {
                if (scriptDoor.interact(scriptkey.isKey, scriptKey.num))
                {
                    scriptkey.changeNum(scriptDoor.num);
                    Debug.Log("La puerta se abre");
                }
                else {
                    Debug.Log("Eso no es posible");
                }
            }
            Flashlight scriptFlash = hit.collider.GetComponent<Flashlight>();
            else if (scriptFlash != null) {
                //desarrollar
            }
            //interactuar con puzzle
            //otra componente posible para interactuar
        }
    }
}
