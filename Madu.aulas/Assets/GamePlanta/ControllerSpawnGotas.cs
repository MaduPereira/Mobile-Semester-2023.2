using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSpawnGotas : MonoBehaviour
{
    public GameObject gota;

    private void Start()
    {
        StartCoroutine(spawnGota());
    }

    IEnumerator spawnGota()
    {
        float aleatory = Random.Range(-2, 1);
        Instantiate(gota, new Vector2(aleatory, this.gameObject.transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(2);
        StartCoroutine(spawnGota());
    }
}
