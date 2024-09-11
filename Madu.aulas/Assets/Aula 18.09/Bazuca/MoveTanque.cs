using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTanque : MonoBehaviour
{
    public Rigidbody2D rbBase, rbTopo;
    public Rigidbody2D bala;
    public Transform cano;
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                
                if(touch.phase == TouchPhase.Began && Input.touchCount == 1)
                {
                    Instantiate(bala, cano.position, cano.rotation);
                }

                if(touch.phase == TouchPhase.Stationary)
                {
                    rbBase.GetComponent<Rigidbody2D>().transform.Translate(Vector2.left * pos * (5f * Time.deltaTime));
                }

                if(touch.phase == TouchPhase.Moved)
                {
                    if(pos.x > 0)
                    {
                        rbTopo.GetComponent<Rigidbody2D>().transform.Rotate(0f, 0f, pos.z - transform.position.z * Time.deltaTime);
                    }
                    if(pos.x < 0)
                    {
                        rbTopo.GetComponent<Rigidbody2D>().transform.Rotate(0f, 0f, -pos.z + transform.position.z * Time.deltaTime);
                    }
                }
        }
    }
}
