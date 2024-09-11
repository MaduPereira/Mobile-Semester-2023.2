using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca : MonoBehaviour
{
    public Transform AssociarUrso;
    Vector2 PosInicial;
    float deltaX, deltaY;
    public static bool verifica;
    // Start is called before the first frame update
    void Start()
    {
        PosInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && !verifica)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase)
            {
                case TouchPhase.Began:

                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y; 
                    }

                break;

                case TouchPhase.Moved:

                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }

                break;
                
                case TouchPhase.Ended:

                    if(Mathf.Abs(transform.position.x - AssociarUrso.position.x) <= 0.5f && Mathf.Abs(transform.position.y - AssociarUrso.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(AssociarUrso.position.x, AssociarUrso.position.y);
                        verifica = true;
                    }
                    else
                    {
                        transform.position = new Vector2(PosInicial.x, PosInicial.y);
                    }

                break;
            }
        }
    }
}
