using UnityEngine;

public class MovimientoDePacman : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public LevelManager levelManager; // Referencia al script del nivel
    
    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento);

        // Comprobar si el jugador ha completado el camino deseado
        if (/* Lógica para comprobar si se ha completado el camino */) 
        {
            levelManager.ShowScreamer();
        }
    }
}
