using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_Frutas : MonoBehaviour
{
    public Text points, time, finalText;
    public static int GamePoints = 0;
    private float tempo, FinalTime, FinalPontos;
    public static bool gameOver = false;

    public GameObject GameOver;
    void Start()
    {
        GameOver.SetActive(false);
        tempo = 0f; // Inicialize o tempo como zero
        UpdateTimeText();
        points.text = "Pontos: " + GamePoints.ToString();
    }
    void Update()
    {
        tempo += Time.deltaTime; // Atualize o tempo a cada quadro
        UpdateTimeText();

        if (GamePoints > 0)
        {
            points.text = "Pontos: " + GamePoints.ToString();
        }

        if(gameOver)
        {
            FinalPontos = GamePoints;
            FinalTime = (int)tempo;
            GameOver.SetActive(true);
            Time.timeScale = 0;
            finalText.text = "Pontuação: " + FinalPontos.ToString() + "\n" + "Tempo: " + FinalTime.ToString();
        }
    }
    void UpdateTimeText()
    {
        // Atualize o texto do tempo formatando o tempo total em segundos
        time.text = "Time: " + Mathf.FloorToInt(tempo).ToString();
    }
}
