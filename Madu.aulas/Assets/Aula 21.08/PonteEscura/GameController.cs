using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static float time;
    public Text cronometro;
    void Start()
    {
        time = 30f;
        cronometro.text = time.ToString("30");
    }
    void Update()
    {
        if(time > 0)
        {
            time = time - Time.deltaTime * 0.25f;   
        }
        else
        {
            time = 0;
        }
        cronometro.text = time.ToString();
    }
}
