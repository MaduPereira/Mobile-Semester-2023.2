using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tOUCHtELA : MonoBehaviour
{
 public GameObject Deslizar,Toque;
 private Touch toque;
 private Vector2 beginTouchPos,endTouchpos;
    void Start()
    {
       
    }

    
    void Update()
    {
      if(Input.touchCount>0)
      {
        toque=Input.GetTouch(0);
        switch(toque.phase)
        {
            case TouchPhase.Began:
            beginTouchPos=toque.position;
            break;
            case TouchPhase.Ended:
            endTouchpos=toque.position;
            if(beginTouchPos==endTouchpos)
            Instantiate(Toque,transform.position,Quaternion.identity);
            if(beginTouchPos!=endTouchpos)
            Instantiate(Deslizar,transform.position,Quaternion.identity);
            break;
        } 
      }
    }
}
