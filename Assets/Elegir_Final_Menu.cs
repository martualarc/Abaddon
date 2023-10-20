using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elegir_Final_Menu : MonoBehaviour
{
    public void OnAceptarButton(){
        SceneManager.LoadScene(15);
    }

    public void OnNegarseButton(){
        AfterLife_SkyBox.inAfterLife = true;
        SceneManager.LoadScene(1);
    }
}

