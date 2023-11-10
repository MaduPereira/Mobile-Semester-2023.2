using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public bool isOpen = false;
    public List<GameObject> locks = new List<GameObject>(4);
    public List<Color> code = new List<Color>(4);
    // Start is called before the first frame update
    void Start()
    {
        //paletCor = GameObject.Find("Paleta").GetComponent<Paleta>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.zero);
            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    switch(touch.phase)
                    {
                        case TouchPhase.Began:
                            if(isOpen)
                            {
                                Destroy(this.gameObject);
                            }
                        break;
                    }
                }
                if(code.Count == 4)
                {
                    if(locks[0].GetComponent<SpriteRenderer>().color == code[0] && locks[1].GetComponent<SpriteRenderer>().color == code[1]
                    && locks[2].GetComponent<SpriteRenderer>().color == code[2] && locks[3].GetComponent<SpriteRenderer>().color == code[3])
                    {
                        isOpen = true;
                    }
                }
            }
        }
    }
}
