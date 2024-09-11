using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public GameObject finalPoint, play2, back;
    Rigidbody2D rb;
    Vector2 inicial;
    public float vel = 5.0f;
    bool pontePos = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        inicial = rb.transform.position;
        play2.SetActive(false);
    }
    private void Update()
    {
        if(MoveClick.move == true && MoveClick.start1 == true)
        {
            Segue();
            Debug.Log("final");
        }
        else if(MoveClick.move == true && MoveClick.start2 == true)
        {
            Volta();
            Debug.Log("back");
        }
        else
        { 
            rb.velocity = Vector2.zero;
        }
    }

    public void Segue()
    {
        if (inicial != rb.position && pontePos == true)
        {
            Vector2 currentPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
            Vector2 targetPosition = new Vector2(finalPoint.transform.position.x, finalPoint.transform.position.y);

            if (currentPosition != targetPosition)
            {
                // Calcula a direção para o objeto de destino
                Vector2 direction = (targetPosition - currentPosition).normalized;

                // Calcula a distância entre as posições
                float distance = Vector2.Distance(currentPosition, targetPosition);

                // Calcula a quantidade de movimento com base na velocidade e no tempo
                float movementAmount = vel * Time.deltaTime;

                // Verifica se o movimento necessário é menor do que a quantidade de movimento disponível nesse frame
                if (movementAmount > distance)
                {
                    // Chegamos ao destino
                    rb.MovePosition(targetPosition);
                    MoveClick.move = false;
                    play2.SetActive(true);
                    MoveClick.start2 = true;
                }
                else
                {
                    // Move gradualmente em direção ao destino
                    rb.MovePosition(rb.position + direction * movementAmount);
                    MoveClick.start2 = false;
                }
            }
            //transform.position = new Vector2(luz.transform.position.x, luz.transform.position.y);
        }
    }

    void Volta()
    {
        if (pontePos == true)
        {
            Vector2 currentPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
            Vector2 targetPosition = new Vector2(back.transform.position.x, back.transform.position.y);

            if (currentPosition != targetPosition)
            {
                // Calcula a direção para o objeto de destino
                Vector2 direction = (targetPosition - currentPosition).normalized;

                // Calcula a distância entre as posições
                float distance = Vector2.Distance(currentPosition, targetPosition);

                // Calcula a quantidade de movimento com base na velocidade e no tempo
                float movementAmount = vel * Time.deltaTime;

                // Verifica se o movimento necessário é menor do que a quantidade de movimento disponível nesse frame
                if (movementAmount > distance)
                {
                    // Chegamos ao destino
                    rb.MovePosition(targetPosition);
                    MoveClick.move = false;
                    //play2.SetActive(true);
                    //MoveClick.start2 = true;
                }
                else
                {
                    // Move gradualmente em direção ao destino
                    rb.MovePosition(rb.position + direction * movementAmount);
                    //MoveClick.start2 = false;
                }
            }
            //transform.position = new Vector2(luz.transform.position.x, luz.transform.position.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ponte")
        {
            pontePos = true;
        }
    }
}
