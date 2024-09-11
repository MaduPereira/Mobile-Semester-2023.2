using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecas2_Quebracabeca : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 startPosition;
    public Collider2D alvo;
    public bool toaqui = false;

    private void Update()
    {
        if (Input.touchCount > 0) // Verificar se h� pelo menos um toque na tela
        {
            Touch touch = Input.GetTouch(0); // Obter o primeiro toque na tela

            if (touch.phase == TouchPhase.Began) // Verificar se o toque come�ou
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (GetComponent<Collider2D>().OverlapPoint(touchPosition)) // Verificar se o toque come�ou na pe�a
                {
                    isDragging = true;
                    startPosition = transform.position;
                }
            }

            if (touch.phase == TouchPhase.Ended && isDragging) // Verificar se o toque terminou
            {
                isDragging = false;

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D[] hitColliders = Physics2D.OverlapPointAll(touchPosition); // Verificar todos os colliders tocados

                foreach (Collider2D collider in hitColliders)
                {
                    if (collider == alvo) // Verificar se o collider tocado � o alvo
                    {
                        toaqui = true;
                        transform.position = alvo.gameObject.transform.position; // Se estiver, fixar a posi��o
                        this.transform.localScale = alvo.transform.localScale;
                        GameController_QuebraCabeca.contFigures--;
                        this.enabled = false;
                        return; // Sair do loop e encerrar a fun��o
                    }
                }

                toaqui = false;
                transform.position = startPosition; // Se n�o estiver, voltar para a posi��o inicial
            }

            if (touch.phase == TouchPhase.Moved && isDragging) // Verificar se o toque est� em movimento
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = transform.position.z; // Manter a mesma profundidade da pe�a
                transform.position = touchPosition; // Atualizar a posi��o da pe�a com a posi��o do toque
            }
        }
    }
}
