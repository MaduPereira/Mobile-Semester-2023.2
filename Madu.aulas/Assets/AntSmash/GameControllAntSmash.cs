using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllAntSmash : MonoBehaviour
{
    public static bool ToqueControll = false;

    public static RaycastHit2D hit;
    Vector3 pos;

    void Update()
    {
        DetectaToque();
    }

    public void DetectaToque()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

            if (hit.collider != null)
            {
                ToqueObject(hit);
                ToqueControll = false;
            }
        }
    }

    public void ToqueObject(RaycastHit2D hit)
    {
        if (hit.collider.gameObject.CompareTag("Enemy") && !ToqueControll)
        {
            ToqueControll = true;
            Debug.Log(hit.transform.name);

            if(hit.collider.gameObject.tag == hit.collider.gameObject.name)
            {
                hit.collider.gameObject.GetComponent<Collider>().enabled = true;
                Enemy.speed = -1;
            }
            else
            {
                ToqueControll = false;
                Enemy.speed = 1;
                Debug.Log("nd");
            }
        }
        
    }
}
