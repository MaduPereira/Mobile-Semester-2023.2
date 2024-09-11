using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticMove : MonoBehaviour
{
    public GameObject circle, dot;
    Rigidbody2D rb;
    float speed;
    Touch oneTouch;
    Vector2 touchPos, moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circle.gameObject.SetActive(false);
        dot.gameObject.SetActive(false);
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            oneTouch= Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(oneTouch.position);

            switch(oneTouch.phase)
            {
                case TouchPhase.Began:

                    circle.SetActive(true);
                    dot.SetActive(true);

                    circle.transform.position = touchPos;
                    dot.transform.position = touchPos;
                    break;

                case TouchPhase.Stationary:

                    MoveDuck();

                    break;

                case TouchPhase.Moved:

                    MoveDuck();

                    break;

                case TouchPhase.Ended:

                    circle.SetActive(false);
                    dot.SetActive(false);

                    rb.velocity = Vector2.zero;

                    break;
            }
        }

        void MoveDuck()
        {
            dot.transform.position = touchPos;

            dot.transform.position = new Vector2(Mathf.Clamp(dot.transform.position.x,
                circle.transform.position.x - 0.5f, circle.transform.position.x + 0.5f),
                    Mathf.Clamp(dot.transform.position.y, circle.transform.position.y - 0.5f, circle.transform.position.y + 0.5f));

            moveDirection = (dot.transform.position - circle.transform.position).normalized;
            rb.velocity = moveDirection * speed;
        }
    }
}
