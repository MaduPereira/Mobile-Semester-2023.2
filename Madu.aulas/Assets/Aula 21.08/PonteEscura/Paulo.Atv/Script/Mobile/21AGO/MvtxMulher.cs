using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtxMulher : MonoBehaviour
{
    Vector3 posInicial;
    Vector3 posDestino;
    Vector3 vetorDirecao;
    Rigidbody2D rb2D;
    bool arrastando;
    float distancia1, distancia2, distancial1, distancial2;
    public bool conectado;
    public static bool conectadoMD, conectadoME, conectadoL1, conectadoL2;
    [Range(1, 15)] public float velocidade = 10;
    public Transform conector1, conector2, conectorl1, conectorl2;
    [Range(0.1f, 2.0f)] public float distMinConector = 1f;
    void Start()
    {
        conectadoMD = true;
        conectadoME = false;
        conectadoL1 = false;
        conectadoL2 = false;
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
            distancial1 = Vector2.Distance(transform.position, conectorl1.position);
            distancial2 = Vector2.Distance(transform.position, conectorl2.position);
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
            if (distancial1 < distMinConector)
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, conectorl1.position, 0.02f);
            }
            if (distancial2 < distMinConector)
            {
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, conectorl2.position, 0.02f);
            }
            if (distancia1 < 0.01f)
            {
                conectado = true;
                conectadoMD = true;
                conectadoME = false;
                conectadoL1 = false;
                conectadoL2 = false;
                transform.position = conector1.position;
                gameObject.transform.parent = conector1;
            }
            if (distancia2 < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = true;
                conectadoL1 = false;
                conectadoL2 = false;
                transform.position = conector2.position;
                gameObject.transform.parent = conector2;
            }
            if (distancial1 < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = false;
                conectadoL1 = true;
                conectadoL2 = false;
                transform.position = conectorl1.position;
                gameObject.transform.parent = conectorl1;
            }
            if (distancial2 < 0.01f)
            {
                conectado = true;
                conectadoMD = false;
                conectadoME = false;
                conectadoL1 = false;
                conectadoL2 = true;
                transform.position = conectorl2.position;
                gameObject.transform.parent = conectorl2;
            }
        }
    }
}
