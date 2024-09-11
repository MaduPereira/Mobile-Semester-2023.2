using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchTeste : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if(touch.position.x < Screen.width/2 && transform.position.x > -2f)
                {
                    transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
                    Debug.Log("E");
                }
                if(touch.position.x > Screen.width/2 && transform.position.x < 2f)
                {
                    transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
                    Debug.Log("D");
                }
            }
        }
    }
}
