using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleNave : MonoBehaviour
{
    // Variáveis para controle de movimento e poder
    private bool poderAtivo = false;

    // Velocidade de movimento da nave
    public float velocidadeMovimento = 5.0f;

    public GameObject bala, cano, canvasTutorialMove;

    private void Start()
    {
        canvasTutorialMove.SetActive(true);
    }
    void Update()
    {
        // Verificar se a nave foi atingida
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward);

        if(hit.collider != null)
        {
            Destroy(gameObject);
            GameControllerNave.gameover = true;
        }


        // Verificar os toques na tela
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if(touch.phase == TouchPhase.Began)
            {
                canvasTutorialMove.SetActive(false);
            }

            // Verificar se o dedo foi arrastado
            if (touch.phase == TouchPhase.Moved)
            {
                // Mover a nave na direção do arrasto do dedo
                Vector3 touchDeltaPosition = touch.deltaPosition;
                Vector3 moveDirection = new Vector3(-touchDeltaPosition.y, touchDeltaPosition.x, 0f); //feito para se encaixar na rotação e eixo
                transform.Translate(moveDirection.normalized * velocidadeMovimento * Time.deltaTime);
            }

            // Verificar se dois dedos estão tocando na tela
            if (Input.touchCount >= 2) //>= 2
            {
                // Ativar o poder da nave
                poderAtivo = true;
            }
            else
            {
                // Desativar o poder da nave
                poderAtivo = false;
            }
        }

        // Executar a lógica de poder (por exemplo, disparar tiros) se o poder estiver ativo
        if (poderAtivo)
        {
            AtivarPoder();
        }
    }

    // Implemente a lógica para ativar o poder da nave
    void AtivarPoder()
    {
        // Coloque sua lógica de ativação de poder aqui
        Instantiate(bala, cano.transform.position, transform.rotation);
        poderAtivo = false;
    }
}
