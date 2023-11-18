using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargar : MonoBehaviour
{
    
    private string interactMessage = "";
    

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            interactMessage = "Tomar el poder del fuego (E)";
        }
        else{
            interactMessage = " ";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactMessage = " ";
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
        style.normal.textColor = Color.red;
        GUI.Label(new Rect(xPos, yPos, messageWidth, messageHeight), interactMessage, style);

    }

}
