using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleChefao : MonoBehaviour
{
    public int vidaInicial = 5; // Vida inicial do chefe
    private int vidaAtual; // Vida atual do chefe
    public static int Dano = 0;

    void Start()
    {
        vidaAtual = vidaInicial; // Inicialize a vida atual com o valor inicial
    }

    // Método para causar dano ao chefe
    public void CausarDano(int quantidadeDano)
    {
        quantidadeDano = Dano;
        vidaAtual -= quantidadeDano; // Reduza a vida pelo valor do dano

        // Verifique se o chefe ainda está vivo
        if (vidaAtual <= 0)
        {
            DerrotarChefe();
        }
    }

    // Método chamado quando o chefe é derrotado
    void DerrotarChefe()
    {
        // Adicione aqui qualquer lógica que você deseja quando o chefe é derrotado
        Destroy(gameObject); // Exemplo: Destruir o objeto do chefe
        Dano = 0;
    }
}
