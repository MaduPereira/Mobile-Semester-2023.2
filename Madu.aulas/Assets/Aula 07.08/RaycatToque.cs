using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycatToque : MonoBehaviour
{
    public GameObject bala;

    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                Debug.Log("Entrando for");

                if(Physics.Raycast(ray))
                {
                    Instantiate(bala, transform.position, transform.rotation);
                     Debug.Log("Entrando if");
                }
            }
        }
    }
}
