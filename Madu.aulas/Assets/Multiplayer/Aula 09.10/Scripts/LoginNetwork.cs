using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginNetwork : MonoBehaviourPunCallbacks
{
    public GameObject connectedScreen, login;
    public InputField nameEntrarSala, nameCriarSala;
    public bool isPlayer1Active = true;
    public string playerList = "Players in the room:\n";

    public static LoginNetwork Instancia { get; private set; }

    public string PlayerList
    {
        get { return playerList; }
        set { playerList = value; }
    }

    private PhotonView photonView; // Refer�ncia ao PhotonView

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;
        //DontDestroyOnLoad(gameObject);
        photonView = GetComponent<PhotonView>(); // Inicializa o PhotonView
    }

    public void ButtonCreateRoom()
    {
        string roomName = nameCriarSala.text.Trim();
        if (string.IsNullOrEmpty(roomName))
        {
            Debug.Log("Nome da sala n�o pode estar em branco.");
        }
        else
        {
            if (PhotonNetwork.InLobby)
            {
                RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
                TypedLobby typedLobby = new TypedLobby(TypedLobby.Default.Name, LobbyType.Default);
                PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby, null);
            }
            else
            {
                Debug.Log("Ainda n�o est� no lobby. Aguarde at� estar no lobby.");
            }
        }
    }

    public void ButtonSearchRoom()
    {
        string roomName = nameEntrarSala.text.Trim();
        if (string.IsNullOrEmpty(roomName))
        {
            Debug.Log("Nome da sala n�o pode estar em branco.");
        }
        else
        {
            PhotonNetwork.JoinRoom(roomName);
        }

        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            // O primeiro jogador a entrar na sala � considerado o jogador 1.
            isPlayer1Active = true;
            photonView.RPC("SetPlayer1Active", RpcTarget.All, isPlayer1Active); // Envie RPC para definir o jogador 1 para todos os jogadores.
        }
        else
        {
            isPlayer1Active = false;
            photonView.RPC("SetPlayer1Active", RpcTarget.All, isPlayer1Active); // Envie RPC para definir o jogador 2 para todos os jogadores.
        }

        // Atualize a lista de jogadores
        string playerList = GetPlayerListAsString();
        photonView.RPC("UpdatePlayerList", RpcTarget.All, playerList);

        StartCoroutine(timeLoad());
    }

    public void SetPlayer1Active(bool active)
    {
        isPlayer1Active = active;
    }

    public string GetPlayerListAsString()
    {
        List<string> playerList = GetPlayerList();
        return "Players in the room:\n" + string.Join("\n", playerList);
    }

    IEnumerator timeLoad()
    {
        yield return new WaitForSeconds(2f);
        login.SetActive(false);
        connectedScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        connectedScreen.SetActive(false);
        isPlayer1Active = false;
        Debug.Log("Room failed! " + returnCode + " Message " + message);
    }

    [PunRPC]
    public bool IsPlayer1Active()
    {
        return isPlayer1Active;
    }

    [PunRPC]
    public void UpdatePlayerList(string playerList)
    {
        this.PlayerList = playerList;
    }

    [PunRPC]
    public List<string> GetPlayerList()
    {
        List<string> playerList = new List<string>();

        if (IsPlayer1Active())
        {
            playerList.Add("Player 1");
            playerList.Add("Player 2");
        }
        else
        {
            playerList.Add("Player 2");
            playerList.Add("Player 1");
        }

        return playerList;
    }
}