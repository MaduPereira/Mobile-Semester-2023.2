using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC3PE : MonoBehaviour
{
    [SerializeField] private Text tpj1, tph1, tpm1, tpia1, tpio1, tpj2, tph2, tpm2, tpia2, tpio2;
    private int tpjovem=1, tphomem=3, tpmulher=6, tpidosa=8, tpidoso=12, tptotal=30, tpmaior;
    private float TempoTotal = 120f;
    private float TempoAtual = 0f;
    private bool JogoAtivo = true;
    public Text tempo;
    public Text texto;
    string message;
    void Start()
    {
        tpj1.text="1";
        tph1.text="3";
        tpm1.text="6";
        tpia1.text="8";
        tpio1.text="12";
        tpj2.text = " ";
        tph2.text = " ";
        tpm2.text = " ";
        tpia2.text = " ";
        tpio2.text = " ";
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
        if (MvtxLanterna.calculatempo)
            CalculaTempo();
        TempoJogador();

        if ((MvtxJovem.conectadoME) && (MvtxHomem.conectadoME) && (MvtxMulher.conectadoME) && (MvtxIdosa.conectadoME) && (MvtxIdoso.conectadoME))
        {
            texto.text = "PARABÉNS! VOCÊ VENCEU!";
            JogoAtivo = false;
            GameOver();
        }

        //if (Objeto1.verifica && Objeto2.verifica && Objeto3.verifica)
        //texto.SetActive(true);
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
    void CalculaTempo()
    {
        tpmaior = 0;
        if ((MvtxJovem.conectadoL1) || (MvtxJovem.conectadoL2))
            tpmaior = tpjovem;
        if ((MvtxHomem.conectadoL1) || (MvtxHomem.conectadoL2))
            tpmaior = tphomem;
        if ((MvtxMulher.conectadoL1) || (MvtxMulher.conectadoL2))
            tpmaior = tpmulher;
        if ((MvtxIdosa.conectadoL1) || (MvtxIdosa.conectadoL2))
            tpmaior = tpidosa;
        if ((MvtxIdoso.conectadoL1) || (MvtxIdoso.conectadoL2))
            tpmaior = tpidoso;
        tptotal -= tpmaior;
        texto.text = "Resta: " + tptotal.ToString("00");
        if (tptotal < 0)
        {
            message = "GAME OVER";
            texto.text = message;
            JogoAtivo = false;
            GameOver();
        }
        MvtxLanterna.calculatempo = false;
    }
    void TempoJogador()
    {
        if (MvtxJovem.conectadoMD)
            tpj1.text = "1";
        else
            tpj1.text = " ";
        if (MvtxHomem.conectadoMD)
            tph1.text = "3";
        else
            tph1.text = " ";
        if (MvtxMulher.conectadoMD)
            tpm1.text = "6";
        else
            tpm1.text = " ";
        if (MvtxIdosa.conectadoMD)
            tpia1.text = "8";
        else
            tpia1.text = " ";
        if (MvtxIdoso.conectadoMD)
            tpio1.text = "12";
        else
            tpio1.text = " ";
        if (MvtxJovem.conectadoME)
            tpj2.text = "1";
        else
            tpj2.text = " ";
        if (MvtxHomem.conectadoME)
            tph2.text = "3";
        else
            tph2.text = " ";
        if (MvtxMulher.conectadoME)
            tpm2.text = "6";
        else
            tpm2.text = " ";
        if (MvtxIdosa.conectadoME)
            tpia2.text = "8";
        else
            tpia2.text = " ";
        if (MvtxIdoso.conectadoME)
            tpio2.text = "12";
        else
            tpio2.text = " ";
    }
}