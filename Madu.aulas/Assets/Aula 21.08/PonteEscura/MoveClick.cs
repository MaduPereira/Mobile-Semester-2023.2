using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClick : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 2;
    int contPessoas = 0;
    public GameObject luz, play;

    public static bool move,start1,start2 = false;
    private void Start()
    {
        play.SetActive(false);
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero);

            Debug.DrawLine(pos, ray.point, Color.red, 1.0f);

            if (ray.collider != null) // Verifica se o raio colidiu com algum objeto
            {               
                if (ray.collider.attachedRigidbody)
                {
                    rb = ray.collider.GetComponent<Rigidbody2D>();
                    Vector2 posInicial = rb.transform.position;
                    Debug.Log("clicando");

                    if (touch.phase == TouchPhase.Began && contPessoas < 2)
                    {
                        contPessoas++;
                        Debug.Log("andando");
                        //rb.velocity = Vector3.left * speed;
                        rb.transform.position = luz.transform.position;
                    }

                    else if (start1 == true && contPessoas == 2)
                    {
                        rb.transform.position = posInicial;
                    }

                    else if (start2 == true)
                    {
                        //
                    }
                }
                
                if (rb.transform.position == luz.transform.position)
                {
                    play.SetActive(true);
                    start1 = true;
                }

                if (ray.collider == play.GetComponent<Collider2D>())
                {
                    start1 = false;
                    move = true;
                    play.SetActive(false);
                    Debug.Log("GO");
                }

                
            }
        }
        
    }
}
