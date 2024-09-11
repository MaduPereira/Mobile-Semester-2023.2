using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMoveObs : MonoBehaviour
{
    public static float velocidade = 1f; // Velocidade da obs
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
        // Mova a obs na dire��o especificada
        rb.velocity = velocidade * Vector2.left;

        // Destrua a obs quando estiver fora da tela (ou a uma dist�ncia suficientemente grande)
        if (!IsVisibleInCamera())
        {
            Destroy(gameObject);
        }
    }

    // Verifique se a obs est� vis�vel na c�mera
    bool IsVisibleInCamera()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        /*if(transform.position.x <= 0)
        {*/
            if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider2D>().bounds))
            {
                return true;
            }
        /*}*/

        return false;
    }
}
