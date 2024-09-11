using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOCverifica : MonoBehaviour
{
    int lobo = 5, ovelha = 3, capim = 1, lado1, lado2;
    [SerializeField] Transform ladoone;
    void Start()
    {
        
    }
    void Update()
    {
        if (MvtBarco.margemD)
            VerificaMargemE();
        if(MvtBarco.margemE)
            VerificaMargemD();
    }
    void VerificaMargemD()
    {
        if (lado1 == 8 || lado1 == 4)
            Debug.Log("GAME OVER");        
    }
    void VerificaMargemE()
    {
        if (lado2 == 8 || lado2 == 4)
            Debug.Log("GAME OVER");
        else if (lado2 == 9)
            Debug.Log("VOCÊ VENCEU");
    }
}
