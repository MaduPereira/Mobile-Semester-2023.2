using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch : MonoBehaviour
{
    public float vel;
    void Update()
    {
        if(Input.touchCount == 1)
        {
            transform.Translate(Input.touches[0].deltaPosition.x * vel, Input.touches[0].deltaPosition.y * vel,0);
        }
    }
}
