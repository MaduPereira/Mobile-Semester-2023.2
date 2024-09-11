using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnimy : MonoBehaviour
{
    public GameObject enimy;
    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Instantiate(enimy, new Vector2(Random.Range(10f,-10f), Random.Range(10f,-10f)), Quaternion.identity);
        yield return new WaitForSeconds(5);
        StartCoroutine(spawn());
    }
}
