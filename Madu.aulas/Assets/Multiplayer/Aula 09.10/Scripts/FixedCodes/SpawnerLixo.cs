using UnityEngine;
using Photon.Pun;

public class SpawnerLixo : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject[] trashObjects;
    
    float time = 0;

    void Update()
    {
        if(RoomManager.gameStarted){
            time += Time.deltaTime;
            if (time >= 1.3f)
            {
                time = 0;
                SpawnTrash();
            }
        }
    }

    void SpawnTrash()
    {
        int randomIndex = Random.Range(0, trashObjects.Length);
        PhotonNetwork.Instantiate(trashObjects[randomIndex].name, transform.position, Quaternion.identity);
    }
}
