using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMoveBala : MonoBehaviour
{
    public float velocidade = 1.0f; // Velocidade da bala
    Rigidbody2D rb;
    public Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (cam == null)
        {
            cam = FindAnyObjectByType<Camera>();
        }
    }

    void Update()
    {
        // Mova a bala na dire��o especificada
        rb.velocity = velocidade * Vector2.right;

        // Destrua a bala quando estiver fora da tela (ou a uma dist�ncia suficientemente grande)
        if (!IsVisibleInCamera())
        {
            Destroy(gameObject);
        }
    }

    // Verifique se a bala est� vis�vel na c�mera
    bool IsVisibleInCamera()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider2D>().bounds))
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enimys")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Chefe")
        {
            // Obt�m a refer�ncia ao script de vida do chefe
            ControleChefao vidaChefe = collision.gameObject.GetComponent<ControleChefao>();
            ControleChefao.Dano++;

            if (vidaChefe != null)
            {
                // Configura a vari�vel Dano no script de vida do chefe
                //ControleChefao.Dano = danoDaColisao;

                // Chama o m�todo CausarDano no script de vida do chefe
                vidaChefe.CausarDano(ControleChefao.Dano);
            }

            Destroy(gameObject);
            Debug.Log(ControleChefao.Dano);
        }
    }
    
}
