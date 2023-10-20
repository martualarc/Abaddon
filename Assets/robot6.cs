using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot6 : StateMachineBehaviour
{
    public float oscillationSpeed = 2.0f;
    
    public float oscillationAmplitude = 0.1f;
    
    private Vector3 initialPosition;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        initialPosition = animator.transform.position;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float verticalOffset = Mathf.Sin(Time.time * oscillationSpeed) * oscillationAmplitude;
        
        Vector3 newPosition = initialPosition + new Vector3(0.0f, verticalOffset, 0.0f);
        
        animator.transform.position = newPosition;
    }
}


