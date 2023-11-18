using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    public Key scriptKey;
    public Flashlight scriptFlash; //toma el valor que le retorna FalseFlash
    public bool clickOn;
    private Demonio scriptDem;
    BarraDeMiedo playerBarra;

    public bool tryInteractStatus = false;
    [SerializeField] private float interactDistance = 7f;
    [SerializeField] private int layer = 7;
    [SerializeField] private int layerD = 6;
    private int demonLayers;
    private int interactLayers;
    private string interactMessage = "";
    private string rightMessage = "";
    private GUIStyle redTextStyle;
    public AudioSource killingDemonSound;

    void Start()
    {
        interactLayers = (1 << layer);
        demonLayers = (1 << layerD);
        scriptKey = GameObject.FindWithTag("Player").GetComponent<Key>(); //apuntar desde keyObj al componente (script) del objeto de clase Key
        clickOn = false;
    }
    void Update()
    {

        tryInteractStatus = false;
        if (Input.GetMouseButtonDown(0)) // objetos y FFlash (clic izquierdo)
        {
            Debug.Log("Click");
            tryInteractStatus = true;
        }

        TryInteract();

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
            killingDemonSound.Pause();
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
            TangibleKey tangKey = hit.collider.GetComponent<TangibleKey>();
            scriptDem = hit.collider.GetComponent<Demonio>();

            if (scriptDoor != null)
            {
                interactMessage = "ABRIR";
                if (tryInteractStatus)
                {
                    if (scriptDoor.interact(scriptKey.isKey, scriptKey.num))
                    {
                        tangKey = GameObject.FindWithTag("Key").GetComponent<TangibleKey>();
                        tangKey.destroy();
                        scriptKey.changeNum(scriptDoor.num);
                        Debug.Log("La puerta se abre");
                    }
                    else
                    {
                        ClearRightMessage();
                        rightMessage = "La puerta está trabada o necesitas una llave";
                        Invoke("ClearRightMessage", 2f);
                    }
                }
            }
            else if (tangKey != null)
            {
                interactMessage = "RECOGER";
                if (tryInteractStatus)
                {
                    tangKey.destroy();
                    scriptKey.getKey();
                }
            }
            else if (scriptNote != null)
            {
                interactMessage = "LEER";
                if (tryInteractStatus)
                {
                    scriptNote.interact();
                }
            }
            else if (scriptFalseF != null)
            {
                interactMessage = "RECOGER";
                if (tryInteractStatus)
                {
                    scriptFlash = scriptFalseF.interact();
                    rightMessage = "Destruye a los demonios con el poder de la luz";
                    Invoke("ClearRightMessage", 4f);
                }
            }
            else if (scriptDem != null)
            {
                interactMessage = "DEMONNN";
                //NO FUNCIONA
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 5);
                Debug.Log("Did not Hit");
                interactMessage = "";
            }
        }
        else
        {
            interactMessage = "";
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
                if (hit.collider.GetComponent<Demonio>() != null || hit.collider.GetComponent<Doubulia1>() != null)
                {
                    scriptFlash.isFlashing = true;
                    Debug.Log("Flasheando demonio");
                }
            }
            else
            {
                scriptFlash.isFlashing = false;
                Debug.Log("Flasheando nada");
                killingDemonSound.Play();
            }
        }
        else
        {
            Debug.Log("Primero debes tener linterna.");
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
        style.fontSize = 25;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(xPos, yPos, messageWidth, messageHeight), interactMessage, style);

        // Mostrar el mensaje de la derecha
        float messageHeight2 = 70f;
        float rightMessageWidth = GUI.skin.label.CalcSize(new GUIContent(rightMessage)).x;
        float rightXPos = Screen.width - rightMessageWidth - 30f;
        GUIStyle style2 = new GUIStyle();
        style2.fontSize = 20;
        style2.normal.textColor = Color.white;
        GUI.Label(new Rect(rightXPos, yPos, rightMessageWidth, messageHeight2), rightMessage, style2);

        // Dibujar un punto blanco en el centro de la pantalla
        Texture2D whiteTexture = new Texture2D(1, 1);
        whiteTexture.SetPixel(0, 0, Color.white);
        whiteTexture.Apply();
        GUI.DrawTexture(new Rect(Screen.width / 2 - 1, Screen.height / 2 - 1, 2, 2), whiteTexture); // El punto será de 2x2 píxeles
    }
    private void ClearRightMessage()
    {
        rightMessage = "";
    }
}
