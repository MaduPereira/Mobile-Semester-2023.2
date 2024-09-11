using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC2MC : MonoBehaviour
{
    private int somac, somap;
    private float TempoTotal = 120f;
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
        VerificaMargemE();
        VerificaMargemD();
    }
    void VerificaMargemD()
    {
        somac = 0;
        somap = 0;
        if (MvtCanibal1.conectadoMD)
            somac++;
        if (MvtCanibal2.conectadoMD)
            somac++;
        if (MvtCanibal3.conectadoMD)
            somac++;
        if (MvtBarco.margemD)
        {
            if ((MvtCanibal1.conectadoB1) || (MvtCanibal2.conectadoB1) || (MvtCanibal3.conectadoB1))
                somac++;
            if ((MvtCanibal1.conectadoB2) || (MvtCanibal2.conectadoB2) || (MvtCanibal3.conectadoB2))
                somac++;
        }
        if (MvtPadre1.conectadoMD)
            somap++;
        if (MvtPadre2.conectadoMD)
            somap++;
        if (MvtPadre3.conectadoMD)
            somap++;
        if (MvtBarco.margemD)
        {
            if ((MvtPadre1.conectadoB1) || (MvtPadre2.conectadoB1) || (MvtPadre3.conectadoB1))
                somap++;
            if ((MvtPadre1.conectadoB2) || (MvtPadre2.conectadoB2) || (MvtPadre3.conectadoB2))
                somap++;
        }
        if (somap != 0)
        {
            if (somac > somap)
            {
                message = "GAME OVER";
                texto.text = message;
            }
        }
        if (MvtCanibal1.conectadoME && MvtCanibal2.conectadoME && MvtCanibal3.conectadoME && MvtPadre1.conectadoME && MvtPadre2.conectadoME && MvtPadre3.conectadoME)
        {
            message = "PARABÉNS! VOCÊ VENCEU!";
            texto.text = message;
            JogoAtivo = false;
        }
    }
    void VerificaMargemE()
    {
        somac = 0;
        somap = 0;
        if (MvtCanibal1.conectadoME)
            somac++;
        if (MvtCanibal2.conectadoME)
            somac++;
        if (MvtCanibal3.conectadoME)
            somac++;
        if (MvtBarco.margemE)
        {
            if ((MvtCanibal1.conectadoB1) || (MvtCanibal2.conectadoB1) || (MvtCanibal3.conectadoB1))
                somac++;
            if ((MvtCanibal1.conectadoB2) || (MvtCanibal2.conectadoB2) || (MvtCanibal3.conectadoB2))
                somac++;
        }
        if (MvtPadre1.conectadoME)
            somap++;
        if (MvtPadre2.conectadoME)
            somap++;
        if (MvtPadre3.conectadoME)
            somap++;
        if (MvtBarco.margemE)
        {
            if ((MvtPadre1.conectadoB1) || (MvtPadre2.conectadoB1) || (MvtPadre3.conectadoB1))
                somap++;
            if ((MvtPadre1.conectadoB2) || (MvtPadre2.conectadoB2) || (MvtPadre3.conectadoB2))
                somap++;
        }
        if (somap != 0)
        {
            if (somac > somap)
            {
                message = "GAME OVER";
                texto.text = message;
            }
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
