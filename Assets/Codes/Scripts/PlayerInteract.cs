using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    public Key scriptKey;
    public Flashlight scriptFlash; //toma el valor que le retorna FalseFlash
    public bool clickOn;
    private Demonio scriptDem;
    BarraDeMiedo playerBarra;


    [SerializeField] private float interactDistance = 7f;
    [SerializeField] private int layer = 7;
    [SerializeField] private int layerD = 6;
    private int demonLayers;
    private int interactLayers;
    private string interactMessage = "";
    private string rightMessage = "";
    private GUIStyle redTextStyle;

    void Start()
    {
        interactLayers = (1 << layer);
        demonLayers = (1 << layerD);
        scriptKey = GameObject.FindWithTag("Player").GetComponent<Key>(); //apuntar desde keyObj al componente (script) del objeto de clase Key
        clickOn = false;
    }
    void Update()
    {
        DetectInteractView();


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
        else if (scriptFlash != null && clickOn)
        {
            clickOn = false;
            scriptFlash.flashOn = false;
        }
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.Z))
        {
            Application.Quit();
        }
    }

    private void DetectInteractView()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayers))
        {
            Door scriptDoor = hit.collider.GetComponent<Door>();
            Note scriptNote = hit.collider.GetComponent<Note>();
            FalseFlash scriptFalseF = hit.collider.GetComponent<FalseFlash>();
            TangibleKey tangKey = hit.collider.GetComponent<TangibleKey>();
            if (scriptDoor != null)
            {
                interactMessage = "ABRIR";
            }
            else if (tangKey != null)
            {
                interactMessage = "RECOGER";
            }
            else if (scriptNote != null)
            {
                interactMessage = "LEER";
            }
            else if (scriptFalseF != null)
            {
                interactMessage = "RECOGER";
            }
            else
            {
                interactMessage = "";
            }
        }
        else
        {
            interactMessage = "";
        }
    }
    void OnGUI()
    {
        // Mostrar el mensaje de la izquierda
        float messageHeight = 40f;
        float messageWidth = GUI.skin.label.CalcSize(new GUIContent(interactMessage)).x;
        float xPos = (Screen.width - messageWidth) / 2f;
        float yPos = Screen.height - messageHeight - 10;
        GUIStyle style = new GUIStyle();
        style.fontSize = 35;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(xPos, yPos, messageWidth, messageHeight), interactMessage, style);

        // Mostrar el mensaje de la derecha
        float rightMessageWidth = GUI.skin.label.CalcSize(new GUIContent(rightMessage)).x;
        float rightXPos = Screen.width - rightMessageWidth - 10;
        GUI.Label(new Rect(rightXPos, yPos, rightMessageWidth, messageHeight), rightMessage);
    }
    private void ClearRightMessage()
    {
        rightMessage = "";
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
            TangibleKey tangKey = hit.collider.GetComponent<TangibleKey>();

            if (scriptDoor != null)
            {
                Debug.Log("Es una puerta.");
                if (scriptDoor.interact(scriptKey.isKey, scriptKey.num))
                {
                    tangKey = GameObject.FindWithTag("Key").GetComponent<TangibleKey>();
                    tangKey.destroy();
                    scriptKey.changeNum(scriptDoor.num);
                    Debug.Log("La puerta se abre");
                }
                else
                {
                    Debug.Log("Eso no es posible");
                    rightMessage = "La puerta está trabada o necesitas una llave";
                    Invoke("ClearRightMessage", 3f);
                }
            }
            else if (tangKey != null)
            {
                tangKey.destroy();
                scriptKey.getKey();
            }
            else if (scriptNote != null)
            {
                Debug.Log("Es una nota.");
                scriptNote.interact();
            }
            else if (scriptFalseF != null)
            {
                Debug.Log("Es una linterna.");
                scriptFlash = scriptFalseF.interact();
                rightMessage = "Click derecho para iluminar";
                Invoke("ClearRightMessage", 3f);
            }

            //interactuar con puzzle
            //otra componente posible para interactuar
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 5);
            Debug.Log("Did not Hit");
        }
    }

    private void TryFlash()
    {
        if (scriptFlash != null)
        {
            Debug.Log("Flasheando.");
            scriptFlash.flashOn = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, demonLayers))
            {
                scriptDem = hit.collider.GetComponent<Demonio>(); //guarda cualquier objeto con clase heredada de demonio
                if (scriptDem != null)
                {
                    scriptFlash.isFlashing = true;
                    Debug.Log("Flasheando demonio");
                }
            }
            else
            {
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
