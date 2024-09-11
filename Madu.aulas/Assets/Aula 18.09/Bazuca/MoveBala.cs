using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBala : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.up * (2f * Time.deltaTime));
    }
}
