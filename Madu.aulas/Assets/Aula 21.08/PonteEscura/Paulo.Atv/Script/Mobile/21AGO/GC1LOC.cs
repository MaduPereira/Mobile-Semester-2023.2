using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC1LOC : MonoBehaviour
{
    private float TempoTotal = 60f;
    private float TempoAtual = 0f;
    private bool JogoAtivo = true;
    public Text tempo;
    public Text texto;
    string message;
    void Start()
    {

    }
    void Update()
    {
        if (JogoAtivo)
        {
            TempoAtual += Time.deltaTime;
            if (TempoAtual >= TempoTotal)
            {
                JogoAtivo = false;
            }
            AtualizaTempo();
        }
        GameOver();
        if (MoveBarco.margemD)
        {
            VerificaMargemE();
        }
        if (MoveBarco.margemE)
        {
            VerificaMargemD();
        }
    }
    void VerificaMargemD()
    {
        if ((MoveLobo.conectadoMD && MoveOvelha.conectadoMD) || (MoveOvelha.conectadoMD && MoveCapim.conectadoMD))
        {
            message = "GAME OVER";
            texto.text = message;
        }
        if (MoveLobo.conectadoME && MoveOvelha.conectadoME && MoveCapim.conectadoME)
        {
            message = "PARABÉNS! VOCÊ VENCEU!";
            texto.text = message;
            JogoAtivo = false;
        }
    }
    void VerificaMargemE()
    {
        if ((MoveLobo.conectadoME && MoveOvelha.conectadoME) || (MoveOvelha.conectadoME && MoveCapim.conectadoME))
        {
            message = "GAME OVER";
            texto.text = message;
        }
    }
    void AtualizaTempo()
    {
        //float TempoRestante = TempoTotal - TempoAtual;
        //tempo.text = "Tempo: " + TempoRestante.ToString("00");
        tempo.text = "Tempo: " + TempoAtual.ToString("00");
    }
    private void GameOver()
    {
        if (JogoAtivo == false)
        {
            Time.timeScale = 0f;
        }
    }
}
