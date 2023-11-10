using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frutas_Frutas : MonoBehaviour
{
    public static Rigidbody2D rb;
    public static int index;
    public static bool duplica = false;
    public static Transform ultimaLoc;
    public GameObject frutas;                       //que falta colidir e instanciar a nova fruta e acrescentar os pontos

    private bool instanciado = false; // Variável de controle
    private bool isCloneCreated = false; // Flag para controlar se o clone já foi criado

    private void Update()
    {
        if(transform.position.y <= 2)
        {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Limite")
        {
            // Verifique a direção do impacto
            Vector2 contactNormal = collision.contacts[0].normal;
            if (contactNormal.y < 0)
            {
                // Se o impacto foi por baixo, mantenha a colisão ativada
                collision.collider.enabled = true;
                GameController_Frutas.gameOver = true;
            }
            else
            {
                // Se o impacto foi por cima, desative a colisão
                collision.collider.enabled = false;
            }
        }

        if (!instanciado && !gameObject.GetComponent<Rigidbody2D>().isKinematic)
        {
            string myTag = gameObject.tag;
            string otherTag = collision.gameObject.tag;

            if (myTag == otherTag && !isCloneCreated)
            {
                int pontuacao = 0; // Inicialize a pontuação como 0

                switch (myTag)
                {
                    case "Maça":
                        pontuacao = 2;
                        break;
                    case "Laranja":
                        pontuacao = 4;
                        break;
                    case "Amora":
                        pontuacao = 6;
                        break;
                    case "Abacaxi":
                        pontuacao = 8;
                        break;
                    case "Pera":
                        pontuacao = 10;
                        break;
                    case "Banana":
                        pontuacao = 12;
                        break;
                    case "Uva":
                        pontuacao = 14;
                        break;
                    case "Limao":
                        pontuacao = 16;
                        break;
                    case "Melancia":
                        pontuacao = 20;
                        break;
                    default:
                        pontuacao = 0; // Se a tag não for reconhecida, pontuação zero
                        break;
                }

                GameController_Frutas.GamePoints += pontuacao; // Adicione a pontuação ao contador de pontos
                string mensagem = (myTag != "Melancia") ? myTag : "zero";

                if (myTag == "Melancia")
                {
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                }
                else
                {
                    // Crie o clone apenas se ainda não foi criado
                    var clone2 = Instantiate(frutas, (transform.position + collision.transform.position) / 2, Quaternion.identity);
                    clone2.GetComponent<Rigidbody2D>().isKinematic = false; // Defina isKinematic como false

                    // Desative o componente antes de destruir o objeto original
                    clone2.GetComponent<Move_JogoFrutas>().enabled = false;

                    // Ignore a colisão entre o objeto clonado e os objetos originais
                    Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                    Physics2D.IgnoreCollision(clone2.GetComponent<Collider2D>(), collision.collider);

                    // Destrua ambos os objetos originais separadamente
                    Destroy(gameObject);
                    Destroy(collision.gameObject);

                    isCloneCreated = true; // Marcar que o clone foi criado
                }

                Debug.Log("+" + GameController_Frutas.GamePoints + ", " + mensagem);
            }
            instanciado = true;
        }
    }
}
 
