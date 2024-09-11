using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject[] all;
    public GameObject pointSpawn, canvasFinish, canvasGameOver;
    int i;
    public static float time = 10;
    public static bool solta, pontos;
    public static int cont, contfrutas, contsucos, contmoney;
    public Text points, tempo, contFrutas, contSucos, contMoney;
    void Start()
    {
        canvasFinish.SetActive(false);
        canvasGameOver.SetActive(false);
        pontos = false;
        solta = true;
        contsucos = 10;
        contfrutas = 10;
        contmoney = 10;
        contSucos.text = contsucos.ToString();
        contFrutas.text = contfrutas.ToString();
        contMoney.text = contmoney.ToString();
        points.text = cont.ToString();
        tempo.text = time.ToString();
    }

    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
            canvasGameOver.SetActive(true);
            Time.timeScale = 0;
        }
        tempo.text = time.ToString("0");

        i = Random.Range(0, all.Length);

        if(solta == true)
        {
            StartCoroutine(spawner());
            solta = false;
        }

        if (pontos == true)
        {
            contSucos.text = contsucos.ToString();
            contFrutas.text = contfrutas.ToString();
            contMoney.text = contmoney.ToString();
            points.text = cont.ToString();
            pontos = false;
        }

        if(contsucos <= 0 && contfrutas <= 0 && contmoney <= 0)
        {
            canvasFinish.SetActive(true);
            Time.timeScale = 0; 
        }
    }

    IEnumerator spawner()
    {
        Instantiate(all[i], pointSpawn.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
    }
}
