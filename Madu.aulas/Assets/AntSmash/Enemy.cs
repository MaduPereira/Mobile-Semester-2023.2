using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 1;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        /*if (GameControllAntSmash.ToqueControll == true && GameControllAntSmash.hit.collider.gameObject.transform == this.gameObject.transform)
        {
            speed = -1;
            Debug.Log("aq");
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            Destroy(this.gameObject, 2);
        }
        else
        {
            speed = 1;
            Debug.Log("n aq");
        }*/
        Movement();
        Animation();
    }

    void Movement()
    {
        if(speed > 0)
        {
           transform.Translate(Vector2.up * (Time.deltaTime * speed));  
        }
        else
        {
            transform.Translate(Vector2.zero);
        }
       
    }

    void Animation()
    {
        anim.SetFloat("Vel", speed);
    }
}
