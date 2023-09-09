using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour 
{
    Collider doorCollider;
    public GameObject keyObj;
    Key scriptKey;
    Flashlight scriptFlash; //toma el valor que le retorna FalseFlash
    public bool clickOn;

    [SerializeField] private float interactDistance = 4f;
    [SerializeField] private int layer = 5;
    private int interactLayers;

    void Start() {
    interactLayers = (1 << layer);
    interactLayers = ~interactLayers;
    scriptKey = keyObj.GetComponent<Key>(); //apuntar desde keyObj al componente (script) del objeto de clase Key
    clickOn = false;
    }
    void Update() {
        
        if (Input.GetMouseButtonDown(0)) // objetos y FFlash (clic izquierdo)
        {
            Debug.Log("Click");
            TryInteract();
        }
        if (Input.GetMouseButtonDown(1)) // linterna (mantener click derecho)
        {
            Debug.Log("Click derecho");
            clickOn = true;         
            TryFlash();
        }
        else if(scriptFlash != null && clickOn)
        {   
            clickOn = false;
            scriptFlash.flashOn = false;
        }
    }

    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayers))
        {
            Door scriptDoor = hit.collider.GetComponent<Door>();
            Object scriptObj = hit.collider.GetComponent<Object>();
            FalseFlash scriptFalseF = hit.collider.GetComponent<FalseFlash>();

            if (scriptDoor != null)
            {
                Debug.Log("Es una puerta.");
                doorCollider = hit.collider.GetComponent<Collider>();

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
            /*
            else if (scriptObj != null) {
                Debug.Log("Es un objeto.");
                //scriptObj.interact()
            }
            else if(scriptFalseF != null){
                Debug.Log("Es una linterna.");
                scriptFlash = scriptFalseF.interact();
            }
            */
            //interactuar con puzzle
            //otra componente posible para interactuar
        }
    }
    private void TryFlash()
    {
        if(scriptFlash != null)
        {
            Debug.Log("Flasheando.");
            scriptFlash.flashOn = true;

        }
        else
        {
            Debug.Log("Primero debes tener linterna.");
        }
    }
}
