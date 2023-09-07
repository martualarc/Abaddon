using UnityEngine;

public class AmbientLightController : MonoBehaviour
{
    public Light ambientLight; // Asigna la luz en el Inspector.
    public float minIntensity = 0.1f;
    public float maxIntensity = 0.4f;
    public float changeInterval = 0.2f;


    private float currentIntensity;


    private void Start()
    { 
        currentIntensity = ambientLight.intensity;
        InvokeRepeating("ChangeIntensity", 0.0f, changeInterval);
    }


    private void ChangeIntensity()
    {
        float randomIntensity = Random.Range(minIntensity, maxIntensity);
        currentIntensity = randomIntensity;
        ambientLight.intensity = randomIntensity;
    }
}