using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterLife_SkyBox : MonoBehaviour
{
    public Material normalSkyBox;
    public Material afterLifeSkyBox;
    public static bool inAfterLife;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inAfterLife == true)
        {
            RenderSettings.skybox = afterLifeSkyBox;
        }
        else
        {
            RenderSettings.skybox = normalSkyBox;
        }
    }
}
