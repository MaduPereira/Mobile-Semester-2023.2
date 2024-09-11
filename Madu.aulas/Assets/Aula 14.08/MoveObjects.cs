using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveObjects : MonoBehaviour
{
    public float vel;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero); // Usar Vector2.zero para atingir qualquer objeto na direção do raio

            // Desenha uma linha representando o raio lançado pelo Raycast
            Debug.DrawRay(pos, ray.point, Color.red, 1.0f);

            if (ray.collider != null) // Verifica se o raio colidiu com algum objeto
            {
                if (ray.collider.gameObject == this.gameObject)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        Debug.Log("Clicando");
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        Debug.Log("Arrastando");
                        transform.position = pos; // Move a posição do objeto para a posição do toque
                    }
                }
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "cestaFrutas")
        {
            Debug.Log("colidi");
            if(this.gameObject.tag == "Frutas" && Spawn.contfrutas >= 0)
            {
                Spawn.time += 5f;
                Spawn.contfrutas--;
                Spawn.pontos = true;
                Debug.Log("fruta");
                Spawn.cont += 10;
                Destroy(this.gameObject);
                Spawn.solta = true;
            }
            else
            {
                Spawn.contfrutas = 0;
            }
        }

        if(coll.gameObject.tag == "cestaSucos" )
        {
            Debug.Log("colidi");
            if(this.gameObject.tag == "Sucos" && Spawn.contsucos >= 0)
            {
                Spawn.time += 5f;
                Spawn.contsucos--;
                Spawn.pontos = true;
                Debug.Log("suco");
                Spawn.cont += 10;
                Destroy(this.gameObject);
                Spawn.solta = true;
            }
            else
            {
                Spawn.contsucos = 0;
            }
        } 

        if (coll.gameObject.tag == "Money")
        {
            Debug.Log("colidi");
            if (this.gameObject.tag == "money" && Spawn.contmoney >= 0)
            {
                Spawn.time += 5f;
                Spawn.contmoney--;
                Spawn.pontos = true;
                Debug.Log("Money");
                Spawn.cont += 10;
                Destroy(this.gameObject);
                Spawn.solta = true;
            }
            else
            {
                Spawn.contmoney = 0;
            }
        }

        if (coll.gameObject.tag == "limite")
        {
            Spawn.time += 1f;
            Debug.Log("colidi limite");
            Destroy(this.gameObject);
            Spawn.solta = true;
        }
       
    }
}