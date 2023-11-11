using UnityEngine;

public class door3 : MonoBehaviour
{
    public AudioSource abrir;
    public AudioSource cerrar;
    public float velocidadRotacion = 90.0f; // Velocidad de rotación en grados por segundo
    private bool estaAbierta = false;

    private Transform jugador;

    public float distanciaActivacion = 2f;

    public float dir;
    public float anguloDestino;
    public float anguloActual;
    
    private string interactMessage = "";
    void Start()
    {
        jugador = Camera.main.transform;
    }

    void Update()
    {
        // Verifica si el jugador está lo suficientemente cerca y hace clic
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, jugador.position) < distanciaActivacion)
        {
            // Cambia el estado de la puerta (abierta o cerrada)
            if(estaAbierta){
                cerrar.Play();
            }
            else{
                abrir.Play();
            }
            estaAbierta = !estaAbierta;
            anguloDestino = (estaAbierta ? 90.0f : 0.0f) * dir;
        }
        if (Vector3.Distance(transform.position, jugador.position) < distanciaActivacion)
        {
            if(estaAbierta){
                interactMessage = "Cerrar";
            }
            else{
                interactMessage = "Abrir";
            }
        }
        else{
            interactMessage = "";
        }
        if(jugador.eulerAngles.y > 270f || jugador.eulerAngles.y < 90f){
            dir = -1f;
        }else{
            dir = 1f;
        }
        
         // Ángulo de rotación deseado
        anguloActual = transform.rotation.eulerAngles.y; // Ángulo actual de la puerta

        // Rota la puerta gradualmente hacia el ángulo de destino
        if (Mathf.Abs(anguloActual - anguloDestino) > 0.01f )
        {
            float pasoRotacion = velocidadRotacion * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, anguloDestino, 0), pasoRotacion);
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
        style.fontSize = 10;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(xPos, yPos, messageWidth, messageHeight), interactMessage, style);

    }
}
