using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{
    public Transform target;
    Transform eu;

    private void Start()
    {
        if(target == null)
        {
            target = target.GetComponent<Transform>().Find("TankBody");
        }
        eu = GetComponent<Transform>();
    }

    void Update()
    {
        if (target == null)
        {
            target = target.GetComponent<Transform>().Find("TankBody");
            //target = eu.Find("TankBody");
        }

        transform.LookAt(target.position);
        eu.position = Vector2.MoveTowards(transform.position, target.position, 3f * Time.deltaTime);
    }
}
