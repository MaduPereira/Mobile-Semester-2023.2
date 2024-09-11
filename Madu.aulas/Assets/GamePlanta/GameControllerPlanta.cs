using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerPlanta : MonoBehaviour
{
    public GameObject[] objetos; // Array de objetos
    public Text textoPontuacao; // Texto para exibir a pontua��o
    public int maxPontos = 10; // Pontua��o m�xima antes do game over
    private int pontos = 0; // Pontua��o atual

    public static int gamepoints = 0;

    private void Update()
    {
        if (pontos <= maxPontos)
        {
            pontos = gamepoints; // Incrementar a pontua��o
            AtualizarCorObjetos(); // Atualizar a cor dos objetos de acordo com a pontua��o
            textoPontuacao.text = pontos.ToString(); // Atualizar o texto de pontua��o
        }

        if (pontos >= maxPontos)
        {
            // Game over
            Debug.Log("Game Over");
            textoPontuacao.text = "PARAB�NS";
            Time.timeScale = 0;
        }
    }

    private void AtualizarCorObjetos()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            if (i < pontos)
            {
                objetos[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
