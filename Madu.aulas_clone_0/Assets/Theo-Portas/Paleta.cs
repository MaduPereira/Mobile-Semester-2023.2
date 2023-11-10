using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paleta : MonoBehaviour
{
    public List<GameObject> Cores;
    public Color corSelected;
    Porta portaCode;
    // Start is called before the first frame update
    void Start()
    {
        portaCode = GameObject.Find("Porta").GetComponent<Porta>();
        if(portaCode.code.Count == 4)
        {
            portaCode.code[0] = Cores[3].GetComponent<SpriteRenderer>().color;
            portaCode.code[1] = Cores[3].GetComponent<SpriteRenderer>().color;
            portaCode.code[2] = Cores[1].GetComponent<SpriteRenderer>().color;
            portaCode.code[3] = Cores[0].GetComponent<SpriteRenderer>().color;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.zero);
            if(hit)
            {
                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        for(int i = 0; i < Cores.Count; i++)
                        {
                            if(hit.collider.gameObject == Cores[i])
                            {
                                corSelected = Cores[i].GetComponent<SpriteRenderer>().color;
                                break;
                            }
                        }
                        if(corSelected != null && hit.collider.gameObject.CompareTag("Quadro"))
                        {
                            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = corSelected;
                        }
                    break;
                }
            }
            
        }
    }
}
