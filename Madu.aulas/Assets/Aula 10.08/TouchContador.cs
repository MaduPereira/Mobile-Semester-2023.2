using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchContador : MonoBehaviour
{
   
   public Text texto;
public Touch toque;
public int t;
    void Start()
    {
        texto=FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            t+=Input.touchCount;
            texto.text=t.ToString();
        }
    }
}
