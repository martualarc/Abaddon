using UnityEngine;

public class luznivel1 : MonoBehaviour
{
    public Light luz1;
    public Light luz2;
    public Light luz3;
    public Light luz4;
    public Light luz5;
    public Light luz6;
    public Light luz7;
    public Light luz8;
    public Light luz9;
    public GameObject cubo1;
    public GameObject cubo2;
    public GameObject cubo3;
    public GameObject cubo4;
    public GameObject cubo5;
    private bool jugado;
    public AdivinanzaPuzzle adivinanzaPuzzle;

    private void Start()
    {       
        adivinanzaPuzzle = GameObject.FindObjectOfType<AdivinanzaPuzzle>();
        luz1.enabled = false;
        luz2.enabled = false;
        luz3.enabled = false;
        luz4.enabled = false;
        luz5.enabled = false;
        luz6.enabled = false;
        luz7.enabled = false;
        luz8.enabled = false;
        cubo1.SetActive(true);
        cubo2.SetActive(true);
        cubo3.SetActive(true);
        cubo4.SetActive(true);
        cubo5.SetActive(true);
        jugado = false;

        Invoke("LucesPuzzle", 19.0f);
        Invoke("LucesFlashes", 9.0f);
    }

    private void Update()
    {       
        if (adivinanzaPuzzle.ganoPuzzle) {
            PuzzleFinalizadoLuces();
        }
        
    }
    public void PuzzleFinalizadoLuces() {
        luz5.enabled = true;
        luz6.enabled = true;
        luz7.enabled = true;
        luz8.enabled = true;
    }

    private void LucesPuzzle() {
        luz1.enabled = true;
        luz2.enabled = true;
        luz3.enabled = true;
        luz4.enabled = true;
        luz9.enabled = false;
        cubo1.SetActive(false);
        cubo2.SetActive(false);
        cubo3.SetActive(false);
        cubo4.SetActive(false);
        cubo5.SetActive(false);
        jugado = true;
    }

    private void LucesFlashes()
    {
        luz5.enabled = true;
        luz6.enabled = true;
        luz7.enabled = true;
        luz8.enabled = true;
        Invoke("ApagarFlashes", 3.0f);
    }

    private void ApagarFlashes()
    {
        luz5.enabled = false;
        luz6.enabled = false;
        luz7.enabled = false;
        luz8.enabled = false;
    }
}
