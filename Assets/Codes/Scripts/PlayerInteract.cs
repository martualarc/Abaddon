using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour 
{
    public GameObject keyObj;
    public Key scriptKey;
    public Flashlight scriptFlash; //toma el valor que le retorna FalseFlash
    public bool clickOn;
    private Demonio scriptDem;
    BarraDeMiedo playerBarra;

    private GameObject transportObject;
    private Collider transportCollider;

    [SerializeField] private float interactDistance = 8f;
    [SerializeField] private int layer = 7;
    [SerializeField] private int layerD = 6;
    private int demonLayers;
    private int interactLayers;

    void Start() {
        interactLayers = (1 << layer);
        demonLayers = (1 << layerD);
        keyObj = GameObject.FindWithTag("Key");
        scriptKey = keyObj.GetComponent<Key>(); //apuntar desde keyObj al componente (script) del objeto de clase Key
        clickOn = false;
        transportObject = GameObject.FindWithTag("Transport");
        transportCollider = transportObject.GetComponent<Collider>();

    }
    void Update() {
        
        if (Input.GetMouseButtonDown(0)) // objetos y FFlash (clic izquierdo)
        {
            Debug.Log("Click");
            TryInteract();
        }
        if (Input.GetMouseButton(1)) // linterna (mantener click derecho)
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
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.Z))
        {
            Application.Quit();
        }
    }

    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayers))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            Door scriptDoor = hit.collider.GetComponent<Door>();
            Note scriptNote = hit.collider.GetComponent<Note>();
            FalseFlash scriptFalseF = hit.collider.GetComponent<FalseFlash>();

            if (scriptDoor != null)
            {
                Debug.Log("Es una puerta.");
                if (scriptDoor.interact(scriptKey.isKey, scriptKey.num))
                {
                    scriptKey.changeNum(scriptDoor.num);
                    transportCollider.isTrigger = true;
                    Debug.Log("La puerta se abre");
                }
                else {
                    Debug.Log("Eso no es posible");
                }
            }
            else if (scriptNote != null) {
                Debug.Log("Es una nota.");
                scriptNote.interact();
            }
            else if(scriptFalseF != null){
                Debug.Log("Es una linterna.");
                scriptFlash = scriptFalseF.interact();
            }
            
            //interactuar con puzzle
            //otra componente posible para interactuar
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward, Color.white, 5);
            Debug.Log("Did not Hit");
        }
    }

    private void TryFlash()
    {
        if(scriptFlash != null)
        {
            Debug.Log("Flasheando.");
            scriptFlash.flashOn = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, demonLayers))
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                scriptDem = hit.collider.GetComponent<Demonio>(); //guarda cualquier objeto con clase heredada de demonio
                if (scriptDem != null)
                {
                    scriptFlash.isFlashing = true;
                    Debug.Log("Flasheando demonio");
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 5);
                scriptFlash.isFlashing = false;
                Debug.Log("Flasheando nada");
            }

        }
        else
        {
            Debug.Log("Primero debes tener linterna.");
        }
    }
}
