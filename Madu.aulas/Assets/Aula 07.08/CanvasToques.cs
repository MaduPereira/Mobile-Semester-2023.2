using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToques : MonoBehaviour
{
    private void OnGUI()
    {
        foreach (Touch touch in Input.touches)
        {
            string texto = "";
            texto = "Id: " + touch.fingerId +"\n";
            int num = touch.fingerId;
            GUI.Label(new Rect(20 + 130 * num, 200, 900,900), texto);
        }

        foreach (Touch touch1 in Input.touches)
        {
            string texto = "";
            texto += "Identificação: " + touch1.fingerId + "\n";
            texto += "Qtd toques: " + touch1.tapCount + "\n";
            texto += "Fase: " + touch1.phase.ToString() + "\n";
            texto += "Posição X: " + touch1.position.x + "\n";
            texto += "Posição Y: " + touch1.position.y + "\n";

            int num = touch1.fingerId;
            GUI.Label(new Rect(20 + 130 * num, 250, 900,900), texto);
        }
    }
}
