using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugandoNewCanvas : MonoBehaviour
{
    Vector3 posicao;

    private Vector2 startpos;
    private Vector2 direcao;
    private string menssagem, texto;

    // Start is called before the first frame update
    void Awake()
    {
        posicao = new Vector3(0f,0f,0f);
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(60); //tamanho da fonte

        GUI.Label(new Rect(20,20,900,900), texto);
    }

    void Update()
    {
        texto = "Touch: " + menssagem + " na direção " + direcao;

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
