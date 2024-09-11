using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGotaPlanta : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
        if (cam == null)
        {
            cam = FindAnyObjectByType<Camera>();
        }
    }

    private void Update()
    {
        if (!IsVisibleInCamera())
        {
            Destroy(gameObject);
        }
    }

    // Verifique se a bala está visível na câmera
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
        if (collision.gameObject.name == "Planta")
        {
            GameControllerPlanta.gamepoints++;
            Destroy(gameObject);
        }
    }
}
