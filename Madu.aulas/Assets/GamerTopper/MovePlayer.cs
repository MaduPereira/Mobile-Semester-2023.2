using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform[] pontosVerticais; // Insira os pontos no Inspector.

    private Transform alvo;
    private int pontoAtual = 0;

    public static bool moveCerva = false;

    private void Start()
    {
        alvo = pontosVerticais[pontoAtual];
        transform.position = alvo.position;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(toque.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

            if (toque.phase == TouchPhase.Began)
            {
                if (hit.collider != null && hit.collider.transform == transform)
                {
                    // Clicou no objeto, mova-o para o ponto clicado
                    Debug.Log("colidindo corno");
                    alvo = pontosVerticais[pontoAtual];
                    pontoAtual = EncontrarPontoClicado(toque.position);
                }

                if(hit.collider != null && hit.collider.name == "cerveja")
                {
                    Debug.Log("colidiu corno");
                    moveCerva = true;
                }
            }
            else if (toque.phase == TouchPhase.Moved)
            {
                // Mova o objeto para cima ou para baixo com base na direção do toque
                float direction = toque.deltaPosition.y;
                int novaPosicao = Mathf.Clamp(pontoAtual + (int)Mathf.Sign(direction), 0, pontosVerticais.Length - 1);
                if (novaPosicao != pontoAtual)
                {
                    alvo = pontosVerticais[novaPosicao];
                    pontoAtual = novaPosicao;
                }
            }
        }

        // Mova suavemente o objeto para o ponto atual
        transform.position = alvo.position;
    }

    private int EncontrarPontoClicado(Vector2 position)
    {
        for (int i = 0; i < pontosVerticais.Length; i++)
        {
            if (Vector2.Distance(position, pontosVerticais[i].position) < 1.0f)
            {
                return i;
            }
        }
        return pontoAtual;
    }
}
