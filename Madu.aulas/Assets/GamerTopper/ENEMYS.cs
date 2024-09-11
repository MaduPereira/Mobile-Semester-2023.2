using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYS : MonoBehaviour
{
    public GameObject bala;

    void Start()
    {
        if (TempoJogo.currentFase > 3)
        {
            StartCoroutine(timeBala());
        }
    }

    IEnumerator timeBala()
    {
        Instantiate(bala, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        StartCoroutine(timeBala());
    }
}