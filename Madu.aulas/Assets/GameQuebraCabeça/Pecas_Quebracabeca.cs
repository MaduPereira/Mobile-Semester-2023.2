using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecas_Quebracabeca : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 startPosition;
    public Collider2D alvo;
    public bool toaqui2 = false;

    private void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (alvo.OverlapPoint(transform.position)) // Verificar se a pe�a est� no lugar correto
        {
            toaqui2 = true;
            transform.position = alvo.gameObject.transform.position; // Se estiver, fixar a posi��o
            this.transform.localScale = alvo.transform.localScale;
            GameController_QuebraCabeca.contFigures--;
            this.enabled = false;
        }
        else
        {
            toaqui2 =false;
            transform.position = startPosition;  // Se n�o estiver, voltar para a posi��o inicia
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            // Atualizar a posi��o da pe�a de acordo com o movimento do mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
}
