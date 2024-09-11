using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerPlanta : MonoBehaviour
{
    public GameObject[] objetos; // Array de objetos
    public Text textoPontuacao; // Texto para exibir a pontuação
    public int maxPontos = 10; // Pontuação máxima antes do game over
    private int pontos = 0; // Pontuação atual

    public static int gamepoints = 0;

    private void Update()
    {
        if (pontos <= maxPontos)
        {
            pontos = gamepoints; // Incrementar a pontuação
            AtualizarCorObjetos(); // Atualizar a cor dos objetos de acordo com a pontuação
            textoPontuacao.text = pontos.ToString(); // Atualizar o texto de pontuação
        }

        if (pontos >= maxPontos)
        {
            // Game over
            Debug.Log("Game Over");
            textoPontuacao.text = "PARABÉNS";
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
