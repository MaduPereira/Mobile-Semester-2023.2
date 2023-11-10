using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_JogoFrutas : MonoBehaviour
{
    public bool isDragging = false;
    private float touchForceThreshold = 0.1f; // Limiar de velocidade vertical negativa para arrastar para baixo

    private void Awake()
    {
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = transform.position.z;

                if (GetComponent<Collider2D>().OverlapPoint(touchPosition))
                {
                    isDragging = true;
                }
            }

            if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = transform.position.z;

                // Limitar a movimentação no eixo X entre x < 2f e x > -2f
                touchPosition.x = Mathf.Clamp(touchPosition.x, -2f, 2f);
                // Fixar a posição Y em 3
                touchPosition.y = 3.3f;

                transform.position = touchPosition;  
            }

            if(touch.phase == TouchPhase.Ended && isDragging) //soltar cai
            {
                if (transform.position.y < touch.position.y - touchForceThreshold)
                {
                    Debug.Log("Cair");

                    StartCoroutine(timeWait());

                    this.enabled = false;
                    isDragging = false;
                }
            }
        }
    }

    IEnumerator timeWait()
    {
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        yield return new WaitForSeconds(1);  
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    
}