using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public GameObject menu, login;

    private void Start()
    {
        menu.SetActive(true);
    }

    public void ConnectBr()
    {
        int maxAttempts = 10;
        for (int i = 1; i <= maxAttempts; i++)
        {
            Debug.Log("Tentativa de conexão: " + i);
            if (PhotonNetwork.ConnectUsingSettings())
            {
                Debug.Log("Conexão bem-sucedida!");
                break;
            }
            else
            {
                Debug.Log("Falha na tentativa de conexão. Tentando novamente...");
                float retryDelay = 5f;
                System.Threading.Thread.Sleep((int)(retryDelay * 1000));
            }
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado...");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        menu.SetActive(false);
        login.SetActive(true);
    }

    public void botaoBackMenu()
    {
        menu.SetActive(true);
        login.SetActive(false);
    }

    
}