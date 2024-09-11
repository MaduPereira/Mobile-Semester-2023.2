using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerNave : MonoBehaviour
{
    public static bool gameover = false;
    public GameObject canvasGO;

    // Start is called before the first frame update
    void Start()
    {
        canvasGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameover)
        {
            Time.timeScale = 0;
            canvasGO.SetActive(true);

            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Began)
                {
                    if(ControleSpawn.tempoEntreObs > 5f)
                    {
                        ControleSpawn.tempoEntreObs -= 1f;
                    }

                    ControleMoveObs.velocidade += 1f;
                    gameover = false;
                    SceneManager.LoadScene(0);

                    Debug.Log(ControleSpawn.tempoEntreObs);
                }
            }
            
        }
        else
        {
            canvasGO.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
