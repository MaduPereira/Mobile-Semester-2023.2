using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOvelha : MonoBehaviour
{
    Vector3 posInicial;
    Vector3 posDestino;
    Vector3 vetorDirecao;
    Rigidbody2D rb2D;
    bool arrastando;
    float distancia1, distancia2, distanciab;
    public bool conectado;
    public static bool conectadoMD, conectadoME;    
    [Range(1, 15)] public float velocidade = 10;
    public Transform conector1, conector2, conectorb;
    [Range(0.1f, 2.0f)] public float distMinConector = 1f;
    void Start()
    {
        conectadoMD = true;
        conectadoME = false;
        rb2D = transform.GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0.25f;
    }
    void OnMouseDown()
    {
        posInicial = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb2D.gravityScale = 0;
        arrastando = true;
        conectado = false;
    }
    void OnMouseDrag()
    {
        posDestino = posInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vetorDirecao = posDestino - transform.position;
        rb2D.velocity = vetorDirecao * velocidade;
    }
    void OnMouseUp()
    {
        rb2D.gravityScale = 0.25f;
        arrastando = false;
    }
    void FixedUpdate()
    {
        if (!arrastando && !conectado)
        {
            distancia1 = Vector2.Distance(transform.position, conector1.position);
            distancia2 = Vector2.Distance(transform.position, conector2.position);
            distanciab = Vector2.Distance(transform.position, conectorb.position);
            if (distancia1 < distMinConector)
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, conector1.position, 0.02f);
            }
            if (distancia2 < distMinConector)
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, conector2.position, 0.02f);
            }
            if (distanciab < distMinConector)
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, conectorb.position, 0.02f);
            }
            if (distancia1 < 0.01f)
            {
                conectado = true;
                conectadoMD = true;
                conectadoME = false;
                transform.position = conector1.position;
                gameObject.transform.parent = conector1;
            }
            if (distancia2 < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = true;
                transform.position = conector2.position;
                gameObject.transform.parent = conector2;
            }
            if (distanciab < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = false;
                transform.position = conectorb.position;
                gameObject.transform.parent = conectorb;
            }
        }
    }
}
