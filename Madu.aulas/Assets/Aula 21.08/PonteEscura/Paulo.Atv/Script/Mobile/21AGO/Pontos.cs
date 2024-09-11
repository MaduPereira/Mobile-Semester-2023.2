using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontos : MonoBehaviour
{
    int jog1 = 1, jog2 = 3, jog3 = 6, jog4 = 8, jog5 = 12,tempo=30, escolha;    
    void Start()
    {
        
    }
    void Update()
    {
        AtualizarTempo();
    }
    void AtualizarTempo()
    {
        switch (escolha)
        {
            //Selecionar os jogadores (dupla ou sozinho)
            case 1:
                // Jogador 1 selecionado sozinho
                tempo -= jog1;
                break;            
            case 2:
                // Jogador 2 selecionado sozinho
                tempo -= jog2;
                break;
            case 3:
                // Jogador 3 selecionado sozinho
                tempo -= jog3;
                break;
            case 4:
                // Jogador 4 selecionado sozinho
                tempo -= jog4;
                break;            
            case 5:
                // Jogador 5 selecionado sozinho
                tempo -= jog5;
                break;
            case 6:
                // Jogadores 1 e 2 selecionados
                tempo -= jog2;
                break;
            case 7:
                // Jogadores 1 e 3 selecionados
                tempo -= jog3;
                break;
            case 8:
                // Jogadores 1 e 4 selecionados
                tempo -= jog4;
                break;
            case 9:
                // Jogadores 1 e 5 selecionados
                tempo -= jog5;
                break;
            case 10:
                // Jogadores 2 e 3 selecionados
                tempo -= jog3;
                break;
            case 11:
                // Jogadores 2 e 4 selecionados
                tempo -= jog4;
                break;
            case 12:
                // Jogadores 2 e 5 selecionados
                tempo -= jog5;
                break;
            case 13:
                // Jogadores 3 e 4 selecionados
                tempo -= jog4;
                break;
            case 14:
                // Jogadores 3 e 5 selecionados
                tempo -= jog5;
                break;
            case 15:
                // Jogadores 4 e 5 selecionados
                tempo -= jog5;
                break;
        }
    }
}
