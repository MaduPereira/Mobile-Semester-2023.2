using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GamePlayNetWork : GameLobbyNetwork
{
    public GameObject[] lixos;
    public GameObject objSpawn;

    public float minimumDistance = 2.0f; // Defina o valor desejado

    public Vector2 lastSpawnPosition;

    public float spawnInterval = 3.0f;
    private float timer = 0.0f;

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (spawer)
            {
                Debug.Log("spawer true");
                timer += Time.deltaTime;

                if (timer >= spawnInterval)
                {
                    RPC_SpawnRandomObject();
                    timer = 0.0f;
                }
            }
        }
    }

    [PunRPC]
    void RPC_SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, lixos.Length);
        Vector2 randomPosition;
        randomPosition = new Vector2(Random.Range(-4f, 4f), objSpawn.transform.position.y);

        if(lastSpawnPosition != randomPosition)
        {
            Debug.Log("to aqui no instance");
            PhotonNetwork.Instantiate(lixos[randomIndex].name, randomPosition, Quaternion.identity);
        }
        lastSpawnPosition = randomPosition;
    }
}