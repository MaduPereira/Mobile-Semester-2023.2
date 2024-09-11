using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChave : MonoBehaviour
{
    public GameObject victory, mensage, door;

    Rigidbody2D rb;
    void Start()
    {
        door.SetActive(true);
        mensage.SetActive(true);
        victory.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

            if(rb.GetComponent<Collider2D>() == Physics2D.OverlapPoint(pos))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("click msm posição");
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("move em cima");
                    rb.position = pos;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == door)
        {
            door.SetActive(false);
            victory.SetActive(true);
            mensage.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
