using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlantaMove : MonoBehaviour
{
    Touch touch;
    Vector3 pos;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            pos = Camera.main.ScreenToViewportPoint(touch.position);

            /*if(this.gameObject.GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(pos))
            {*/
                if (touch.phase == TouchPhase.Moved)
                {
                    pos.y = transform.position.y;
                    pos.z = transform.position.z;
                    transform.position = pos;
                }
           /* }*/
            
        }
    }
}
