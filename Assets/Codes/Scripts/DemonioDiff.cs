using UnityEngine;
using System.Collections;

public class DemonioDiff: Demonio {
    public float maxLifeBar;

    Start()
    {
        base.Start();
        maxLifeBar = lifeBar;
    }
    void reduceLifeBar()
    {   
        float tF = scriptFlash.timeFlashing;
        if(scriptFlash.timeNotFlashing == 0.0)
        {
            scriptFlash.timeFlashing = 0.0f;
            lifeBar -= tF;
            Debug.Log("-" + tF "segundos");
        }
        else
        {
            if(lifeBar!=maxLifeBar)
            {
                Debug.Log("Dejaste de apuntar.");
            }
            lifeBar = maxLifeBar;
        }
    }
}