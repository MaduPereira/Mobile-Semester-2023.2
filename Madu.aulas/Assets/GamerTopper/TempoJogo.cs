using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempoJogo : MonoBehaviour
{
    public Text faseText; // Referência ao Text para exibir a fase
    public Text tempoText; // Referência ao Text para exibir o tempo restante
    public static int currentFase = 1; // Fase atual
    private float faseDuration = 30f; 
    private float faseTimer; // Cronômetro da fase

    public GameObject canvasMenu, canvasGameOver;

    private void Start()
    {
        canvasMenu.SetActive(true);
        canvasGameOver.SetActive(false);
        faseTimer = faseDuration;
        UpdateFaseText();
        UpdateTempoText();
    }

    private void Update()
    {
        faseTimer -= Time.deltaTime;

        /*if (faseTimer <= 0)
        {
            StartNextFase();
        }*/

        UpdateTempoText();

        if (faseTimer <= 0)
        {
            tempoText.text = "00:00";
            canvasGameOver.SetActive(true);
            Time.timeScale = 0;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
    public void Play()
    {
        canvasMenu.SetActive(false);
    }
    public void StartNextFase()
    {
        currentFase++;
        faseTimer = faseDuration;
        UpdateFaseText();

        // Execute aqui qualquer ação que você deseja que ocorra no início de uma nova fase.
    }

    void UpdateFaseText()
    {
        faseText.text = "Fase: " + currentFase;
    }

    void UpdateTempoText()
    {
        int minutos = Mathf.FloorToInt(faseTimer / 60f);
        int segundos = Mathf.FloorToInt(faseTimer % 60f);

        tempoText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
