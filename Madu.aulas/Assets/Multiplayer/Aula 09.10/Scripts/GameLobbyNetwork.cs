using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class GameLobbyNetwork : LoginNetwork
{
    public GameObject canvas, player1, player2, GameOVER;
    public Text players, pontoPlayer1, pontoPlayer2;
    public Button startGame;
    public int pointsPlayer1, pointsPlayer2;
    public string player01, player02;

    public bool spawer = false;

    PhotonView phView; // Refer�ncia ao PhotonView

    void Awake()
    {
        gameObject.SetActive(true);
        GameOVER.SetActive(false);
        phView = GetComponent<PhotonView>(); // Inicializa o PhotonView
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        
        if(PhotonNetwork.IsMasterClient)
            UpdateList();
    }

    void Update()
    {
        if (LoginNetwork.Instancia != null)
        {
            player01 = LoginNetwork.Instancia.GetPlayerList()[0];
            player02 = LoginNetwork.Instancia.GetPlayerList()[1];
            pontoPlayer1.text = pointsPlayer1.ToString();
            pontoPlayer2.text = pointsPlayer2.ToString();
            Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        }

        if (phView.IsMine)
        {
            //UpdateList();
            //phView.RPC("UpdatePlayerList", RpcTarget.All, LoginNetwork.Instancia.PlayerList);
        }

        Debug.Log("Ping: " + PhotonNetwork.GetPing().ToString());
    }

    [PunRPC]
    // Chame essa fun��o sempre que quiser atualizar a lista de jogadores e a interatividade do bot�o.
    public void UpdateList()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            bool isPlayer1Active = IsPlayer1Active();
            startGame.interactable = isPlayer1Active;
            player1.SetActive(isPlayer1Active);
            player2.SetActive(!isPlayer1Active); // Ative o player2 apenas se o jogador for o Player 1
            phView.RPC("SetPlayer1Active", RpcTarget.All, isPlayer1Active);
            phView = player1.AddComponent<PhotonView>();


        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            startGame.interactable = false;
            player1.SetActive(false); // Desative o player1 se o jogador n�o for o Player 2
            player2.SetActive(true); // Ative o player2 apenas se o jogador for o Player 2
            phView.RPC("SetPlayer1Active", RpcTarget.All);
            phView = player2.AddComponent<PhotonView>();
        }
        else
        {
            // Desabilite o bot�o e os GameObjects player1 e player2 para jogadores que n�o s�o o Player 1 ou o Player 2
            startGame.interactable = false;
            player1.SetActive(false);
            player2.SetActive(false);
            phView.RPC("SetPlayer1Active", RpcTarget.All);
        }

        phView.ObservedComponents = null;
        // Atualize a lista de jogadores na UI
        phView.RPC("UpdatePlayerList", RpcTarget.All, LoginNetwork.Instancia.PlayerList);
    }

    [PunRPC]
    public void GameOver()
    {
        players.text = player01 + pointsPlayer1.ToString() + "/n" + player02 + pointsPlayer2.ToString();
        GameOVER.SetActive(true);
    }

    [PunRPC]
    public void StartButton()
    {
        // Verifique se ambos os jogadores est�o na sala
        if (BothPlayersAreInRoom())
        {
            spawer = true;
            // Iniciar o jogo
            startGame.gameObject.SetActive(false);
            Debug.Log("play");
        }
        else
        {
            startGame.gameObject.SetActive(true);
        }
    }

    [PunRPC]
    public bool BothPlayersAreInRoom() // dois na sala
    {
        return PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.PlayerCount == 2;
    }
}