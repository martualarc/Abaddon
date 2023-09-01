using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

//Saves a screenshot when a button is pressed
public KeyCode screenShotButton;
void Update()
{
    if (Input.GetKeyDown(screenShotButton))
    {
        ScreenCapture.CaptureScreenshot("screenshot.png");
        Debug.Log("A screenshot was taken!");
    }
}
}
