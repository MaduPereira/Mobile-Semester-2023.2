using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtxLanterna : MonoBehaviour
{
    public float speed = 5.0f;
    public static bool margemD, margemE, calculatempo;
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
            if (transform.position.x > 6f)
            {
                BMovDir.moveDir = false;
                calculatempo = true;
                margemD = true;
                margemE = false;
            }
        }
        if (BMovEsq.moveEsq)
        {
            if (sprite != null)
                sprite.flipX = false;
            transform.position = new Vector2(transform.position.x - 1 * speed * Time.deltaTime, transform.position.y);
            if (transform.position.x < -6)
            {
                BMovEsq.moveEsq = false;
                calculatempo = true;
                margemD = false;
                margemE = true;
            }
        }
    }
}
