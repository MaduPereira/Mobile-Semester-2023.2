using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtPadre2 : MonoBehaviour
{
    Vector3 posInicial;
    Vector3 posDestino;
    Vector3 vetorDirecao;
    Rigidbody2D rb2D;
    bool arrastando;
    float distancia1, distancia2, distanciab1, distanciab2;
    public bool conectado;
    public static bool conectadoMD, conectadoME, conectadoB1, conectadoB2;
    [Range(1, 15)] public float velocidade = 10;
    public Transform conector1, conector2, conectorb1, conectorb2;
    [Range(0.1f, 2.0f)] public float distMinConector = 1f;
    void Start()
    {
        conectadoMD = true;
        conectadoME = false;
        conectadoB1 = false;
        conectadoB2 = false;
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
            distanciab1 = Vector2.Distance(transform.position, conectorb1.position);
            distanciab2 = Vector2.Distance(transform.position, conectorb2.position);
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
            if (distanciab1 < distMinConector)
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, conectorb1.position, 0.02f);
            }
            if (distanciab2 < distMinConector)
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, conectorb2.position, 0.02f);
            }
            if (distancia1 < 0.01f)
            {
                conectado = true;
                conectadoMD = true;
                conectadoME = false;
                conectadoB1 = false;
                conectadoB2 = false;
                transform.position = conector1.position;
                gameObject.transform.parent = conector1;
            }
            if (distancia2 < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = true;
                conectadoB1 = false;
                conectadoB2 = false;
                transform.position = conector2.position;
                gameObject.transform.parent = conector2;
            }
            if (distanciab1 < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = false;
                conectadoB1 = true;
                conectadoB2 = false;
                transform.position = conectorb1.position;
                gameObject.transform.parent = conectorb1;
            }
            if (distanciab2 < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = false;
                conectadoB1 = false;
                conectadoB2 = true;
                transform.position = conectorb2.position;
                gameObject.transform.parent = conectorb2;
            }
        }
    }
}
