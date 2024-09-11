using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSpawn : MonoBehaviour
{
    public GameObject[] obstaculos; // Array de obstáculos
    public GameObject[] chefes; // Array de chefes
    public Transform[] spawnPoints; // Pontos de spawn
    public static float tempoEntreChefes = 30.0f; // Tempo entre spawns de chefes
    public static float tempoEntreObs = 10.0f;
    private float tempoUltimoSpawnChefe, tempoUltimoSpawnObs;
    private int indiceChefeAtual = 0;

    void Start()
    {
        tempoUltimoSpawnObs = Time.time;
        tempoUltimoSpawnChefe = Time.time; // Inicialize para permitir o spawn de um chefe após 30 segundos
        SpawnObstaculo();
    }


    void Update()
    {
        // Verifique se é hora de spawnar um chefe
        if (Time.time - tempoUltimoSpawnChefe >= tempoEntreChefes)
        {  
            SpawnChefe();
            tempoUltimoSpawnChefe = Time.time; // Atualize o tempo do último spawn de chefe
            
        }
        else
        {
            // Verifique se pode spawnar um obstáculo (não há chefes na cena)
            if (!ExisteChefeNaCena() && Time.time - tempoUltimoSpawnObs >= tempoEntreObs)
            {
                SpawnObstaculo();
                tempoUltimoSpawnObs = Time.time; // Atualize o tempo do último spawn de obstáculo
            }
        }
    }

    bool ExisteChefeNaCena()
    {
        GameObject[] chefesNaCena = GameObject.FindGameObjectsWithTag("Chefe"); // Certifique-se de adicionar uma tag "Chefe" aos chefes

        return chefesNaCena.Length > 0;
    }

    void SpawnObstaculo()
    {
        GameObject obstaculo = obstaculos[Random.Range(0, obstaculos.Length)];
        Instantiate(obstaculo, new Vector2(spawnPoints[0].position.x, Random.Range(4f, -4f)), spawnPoints[0].rotation);
    }

    void SpawnChefe()
    {
        if (indiceChefeAtual < chefes.Length)
        {
            Transform spawnPoint = spawnPoints[1];
            GameObject chefeAtual = chefes[indiceChefeAtual];

            if(!ExisteChefeNaCena())
            {
                Instantiate(chefeAtual, spawnPoint.position, chefeAtual.transform.rotation);
            }
            indiceChefeAtual++;
        }
        else
        {
            Debug.Log("Todos os chefes foram spawnados.");
        }
    }
}