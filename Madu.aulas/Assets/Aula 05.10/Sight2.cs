using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight2 : MonoBehaviour
{   
    public GameObject bala;
    private float velocidadeMovimento = 5.0f;

    private void Start()
    {
        //this.gameObject.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        /*mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);*/

        // Verificar os toques na tela
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            Vector3 touchpos = Camera.main.ScreenToViewportPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                this.gameObject.SetActive(true);
                //transform.position = touchPos;
            }

            // Verificar se o dedo foi arrastado
            if (touch.phase == TouchPhase.Moved)
            {
                // Mover a nave na direção do arrasto do dedo
                Vector3 touchDeltaPosition = touch.deltaPosition;
                transform.position = touchpos;
            }

            if (Input.touchCount == 2) //>= 2
            {
                Instantiate(bala, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
        }
    }
}
