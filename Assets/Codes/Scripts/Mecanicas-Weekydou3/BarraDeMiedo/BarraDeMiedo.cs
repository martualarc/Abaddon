using UnityEngine;
using UnityEngine.UI;

public class BarraDeMiedo : MonoBehaviour
{
    public Image barraDeMiedo; // Referencia a la barra de miedo en la interfaz de usuario
    public int aumentoDeMiedoPorInteraccion = 10; // Cuánto miedo se agrega por cada interacción con un demonio
    public int maximoMiedo = 100; // El valor máximo de la barra de miedo antes de entrar en shock
    public ScriptBarraMiedo barra;
    public int miedoActual = 0;


    private void Update()
    {
       /* if(!apuntandoDemonio){ 
             miedoActual += aumentoDeMiedoPorInteraccion;
            // Actualizar la barra de miedo en la interfaz de usuario
            ActualizarBarraDeMiedo();
        }*/ //descomentar cuando esté disponible variable del demonio
    }

    private void ActualizarBarraDeMiedo()
    {
        barra.SetMiedo(miedoActual);
    }

}
