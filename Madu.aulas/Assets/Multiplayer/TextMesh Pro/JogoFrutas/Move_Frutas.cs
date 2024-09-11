using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Frutas : MonoBehaviour
{
    Touch touch;
    public static Vector3 pos;
    public LayerMask frutas;
    public static bool moveFruta = false;
    public static bool moveThis = false;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            pos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero); // Usar Vector2.zero para atingir qualquer objeto na direção do raio

            // Desenha uma linha representando o raio lançado pelo Raycast
            Debug.DrawRay(pos, ray.point, Color.red, 1.0f);

            if (ray.collider != null) // Verifica se o raio colidiu com algum objeto
            {
                if (ray.collider.attachedRigidbody == Frutas_Frutas.rb)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        Debug.Log("Clicando");
                        moveThis = true;
                    }
                    if (touch.phase == TouchPhase.Moved && moveThis == true)
                    {
                        Debug.Log("Arrastando");
                        moveFruta = true; // Move a posição do objeto para a posição do toque
                    }
                }
            }
        }
    }
}
