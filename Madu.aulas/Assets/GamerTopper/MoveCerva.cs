using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCerva : MonoBehaviour
{
    public float velocidade = 2f; 
    private bool foiTocada = false; 

    public GameObject pontoReferenciaJogador;
    private Transform jogador; // Adicione uma referência ao jogador

    public bool enemyCll = false;

    public void Start()
    {
        pontoReferenciaJogador = GameObject.FindWithTag("Player");

        // Encontre a referência ao jogador
        jogador = pontoReferenciaJogador.transform;
    }

    private void Update()
    {
        if (foiTocada)
        {
            // Move a cerveja para a esquerda
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }

        // Verifica toques na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

            if (touch.phase == TouchPhase.Began && !foiTocada)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        jogador.position = new Vector3(jogador.position.x, transform.position.y, jogador.position.z);
                        foiTocada = true;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colidiu com inimigo");

            // Verifica se a cerveja já foi tocada 
            if (foiTocada)
            {
                Spawns.clientesSpawned--;
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
