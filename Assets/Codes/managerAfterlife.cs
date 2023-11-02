using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerAfterlife : MonoBehaviour
{
    public Key scriptKey;
    private static Transform m_DestroyOnLoadGO;
    public GameObject player;
    public GameObject canvas;

    void Start()
    {
        scriptKey = GameObject.FindWithTag("Player").GetComponent<Key>();
        player = GameObject.FindWithTag("Player");
        canvas = GameObject.FindWithTag("UICanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptKey.isKey){
            DestroyOnLoad(player);
            DestroyOnLoad(canvas);
            ExitLevel();
        }
    }

    public static void DestroyOnLoad(GameObject aGO)
{
    if (m_DestroyOnLoadGO == null)
        m_DestroyOnLoadGO = (new GameObject("DestroyOnLoad")).transform;
        aGO.transform.SetParent(m_DestroyOnLoadGO);
}

    private void ExitLevel(){
        SceneManager.LoadScene("Elegir_final");
    }
}
