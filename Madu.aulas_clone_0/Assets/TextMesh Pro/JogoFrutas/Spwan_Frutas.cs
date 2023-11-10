using System.Collections;
using UnityEngine;

public class Spwan_Frutas : MonoBehaviour
{
    public GameObject[] frutas;
    public GameObject clone;

    private void Start()
    {
        StartCoroutine(SpawnFruta());
    }

    private void Update()
    {
        if (clone != null && clone.GetComponent<Rigidbody2D>().isKinematic == false)
        {
            StartCoroutine(SpawnFruta());
        }
    }

    IEnumerator SpawnFruta()
    {
        int aleatory = Random.Range(0, frutas.Length);
        clone = Instantiate(frutas[aleatory], new Vector2(Random.Range(2f, -2f), 3.3f), Quaternion.identity);
        clone.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(1);
    }
}
