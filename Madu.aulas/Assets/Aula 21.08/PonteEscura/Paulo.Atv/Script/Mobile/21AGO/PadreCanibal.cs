using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadreCanibal : MonoBehaviour
{
    int padre = 1, canibal = 1, somap, somac, lado1, lado2;
    void Start()
    {

    }
    void Update()
    {
        VerificaLado1();
        VerificaLado2();
    }
    void VerificaLado1()
    {
        if (somap < somac)
            Debug.Log("GAME OVER");
    }
    void VerificaLado2()
    {
        if (somap < somac)
            Debug.Log("GAME OVER");
        else if (somap == 3 && somac==3)
            Debug.Log("VOCÊ VENCEU");
    }
}
