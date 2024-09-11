using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaToque : MonoBehaviour
{
    float deltaX, deltaY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 Touchpos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    deltaX = Touchpos.x - transform.position.x;
                    deltaY = Touchpos.y - transform.position.y;
                break;

                case TouchPhase.Moved:

                    rb.MovePosition(new Vector2(Touchpos.x - deltaX, Touchpos.y - deltaY));

                break;

                case TouchPhase.Ended:

                    rb.velocity = Vector2.zero;
                break;

            }
        }
    }
}
