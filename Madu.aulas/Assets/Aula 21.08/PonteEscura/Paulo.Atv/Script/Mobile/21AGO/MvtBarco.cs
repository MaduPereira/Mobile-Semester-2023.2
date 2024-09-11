using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtBarco : MonoBehaviour
{
    public float speed = 5.0f;
    public static bool margemD, margemE;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        margemD = true;
        margemE = false;
    }
    void Update()
    {
        if (BMovDir.moveDir)
        {
            if (sprite != null)
                sprite.flipX = true;
            transform.position = new Vector2(transform.position.x + 1 * speed * Time.deltaTime, transform.position.y);
            if (transform.position.x > 5f)
            {
                BMovDir.moveDir = false;
                margemD = true;
                margemE = false;
            }
        }
        if (BMovEsq.moveEsq)
        {
            if (sprite != null)
                sprite.flipX = false;
            transform.position = new Vector2(transform.position.x -1 * speed * Time.deltaTime, transform.position.y);
            if (transform.position.x < -4.5)
            {
                BMovEsq.moveEsq = false;
                margemD = false;
                margemE = true;
            }
        }        
    }
}
