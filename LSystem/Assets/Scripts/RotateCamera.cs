using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [HideInInspector]
    public bool isThreeD;

    public void Reset()
    {
        isThreeD = false;
        transform.rotation = Quaternion.identity;
    }
    void Update()
    {
        if(isThreeD)
        {
            transform.Rotate(0,10 * Time.deltaTime, 0);
        }
        
    }
}
