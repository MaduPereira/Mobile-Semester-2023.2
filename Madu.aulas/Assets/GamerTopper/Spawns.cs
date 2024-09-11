using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public GameObject cervejaPrefab;
    public GameObject[] clientePrefabs; // Array contendo os diferentes tipos de clientes
    public Transform[] spawnPoints; // Pontos de spawn para cervejas
    public Transform[] clienteSpawnPoints; // Pontos de spawn para clientes

    public static int clientesSpawned = 0;
    public int totalClientesPorFase = 4; // Total de clientes a serem spawnados nesta fase
    private float cervejaSpawnDelay = 2f; 
    private float cervejaSpawnTimer = 0f; // Cron�metro para o spawn de cervejas

    private void Start()
    {
        IniciarFase();
    }

    private void Update()
    {
        // Verifica se todos os clientes desta fase foram destru�dos
        if (clientesSpawned == 0)
        {
            // Avan�a para a pr�xima fase
            AvancarParaProximaFase();
        }

        // Conta o tempo para spawn de cervejas
        cervejaSpawnTimer -= Time.deltaTime;

        // Verifica se � hora de spawnar uma cerveja
        if (cervejaSpawnTimer <= 0)
        {
            SpawnCervejas();
            // Redefine o timer ap�s o spawn bem-sucedido
            cervejaSpawnTimer = cervejaSpawnDelay;
        }
    }

    private void IniciarFase()
    {
        // Resete o contador de clientes spawnados
        clientesSpawned = 0;

        // Defina o n�mero total de clientes para a fase atual (4 inimigos por fase)
        totalClientesPorFase = TempoJogo.currentFase * 4;

        // Certifique-se de que os pontos de spawn de cervejas estejam inicialmente vazios (sem cervejas)
        foreach (Transform spawnPoint in spawnPoints)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint.position, 0.1f);

            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Cerveja"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }

        SpawnClientes();
        Debug.Log(totalClientesPorFase);
        Debug.Log(clientesSpawned);
    }

    private void AvancarParaProximaFase()
    {
        // Avan�a para a pr�xima fase
        //TempoJogo.currentFase++;
        this.gameObject.GetComponent<TempoJogo>().StartNextFase();

        // Inicializa a nova fase
        IniciarFase();
    }

    private void SpawnClientes()
    {
        foreach (Transform spawnPoint in clienteSpawnPoints)
        {
            // Verifica se j� existe um cliente neste ponto de spawn
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint.position, 0.1f); // Ajuste o raio conforme necess�rio

            if (colliders.Length < totalClientesPorFase)
            {
                int randomClienteIndex = Random.Range(0, clientePrefabs.Length);
                GameObject newCliente = Instantiate(clientePrefabs[randomClienteIndex], spawnPoint.position, Quaternion.identity);

                // Empurra os clientes anteriores na fila (se houver)
                foreach (var collider in colliders)
                {
                    if (collider.gameObject == newCliente)
                    {
                        Vector3 newPos = collider.transform.position + Vector3.right * 0.5f;
                        collider.transform.position = newPos;
                    }
                }

                // Incrementa o contador de clientes spawnados
                clientesSpawned++;
            }
        }
    }

    private void SpawnCervejas()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint.position, 1f);

            bool spawnCerveja = true;

            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Cerveja"))
                {
                    spawnCerveja = false;
                    break;
                }
            }

            if (spawnCerveja)
            {
                Instantiate(cervejaPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}