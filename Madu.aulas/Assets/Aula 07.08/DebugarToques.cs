using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugarToques : MonoBehaviour
{
    Vector2 startpos, direcao;
    public Text texto;
    string menssagem;

    // Update is called once per frame
    void Update()
    {
        texto.text = "Touch: " + menssagem + "na direção" + direcao;

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Began:

                    startpos = touch.position;
                    menssagem = "Began";
                break;

                case TouchPhase.Moved:

                    direcao = touch.position - startpos;
                    menssagem = "Moved";
                break;

                case TouchPhase.Ended:

                    direcao = touch.position - startpos;
                    menssagem = "Ended";
                break;
            }
        }

    }
}
