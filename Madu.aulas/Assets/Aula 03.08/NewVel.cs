using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVel : MonoBehaviour
{
    public float vel = 1f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = vel * Vector2.up;
    }
}
