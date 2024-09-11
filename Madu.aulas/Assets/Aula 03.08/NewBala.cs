using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBala : MonoBehaviour
{
    public GameObject projetil,clone;
    float timePress;
    float delay = 0.5f;

    void Update()
    {
        for(int i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                clone = Instantiate(projetil, transform.position,transform.rotation) as GameObject;
                Debug.Log("began");
                timePress = Time.time;
            }

            if(Input.GetTouch(i).phase == TouchPhase.Stationary)
            {
                if(Time.time - timePress > delay)
                {
                    clone.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 2f;
                    clone = Instantiate(projetil, transform.position, transform.rotation) as GameObject;
                    Debug.Log("stationary");
                }
                
            }   

        }
    }
}
