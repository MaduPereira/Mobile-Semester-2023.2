using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCanvas : MonoBehaviour
{
    public float altura;
    public float largura;
    public float tamanho;
    Vector3 posicao;
    // Start is called before the first frame update
    void Awake()
    {
        largura = (float)Screen.width/2.0f;
        altura = (float)Screen.height/2.0f;

        posicao = new Vector3(0f,0f,0f);
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(tamanho/*Screen.width/25f*/); //tamanho da fonte

        GUI.Label(new Rect(20,20,largura,altura * 0.25f), "x=" + posicao.x.ToString("f2")+", y=" + posicao.y.ToString("f2")); //desenho
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - largura) / largura;
                pos.y = (pos.y - altura) / altura;
                posicao = new Vector3(/*-*/pos.x, pos.y,0f);

                transform.position = posicao; 
            }

            if(Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);
            }

            if(touch.phase == TouchPhase.Began)
            {
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                transform.localScale = new Vector3(1f,1f,1f);
            }
        }
        
    }
}
