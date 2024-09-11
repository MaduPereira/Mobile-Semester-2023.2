using System.Collections;
using Photon.Pun;
using TMPro;
using UnityEngine;

// Enum para definir o resultado do jogo
public enum GameResult 
{
    WIN, LOSE, DRAW
}

public class RoomManager : MonoBehaviourPunCallbacks
{

    [SerializeField] TextMeshProUGUI player1ScoreText, player2ScoreText;
    [SerializeField] GameObject player1Controller, player2Controller, player1panel, player2panel;
    [SerializeField] GameObject syncScreen, winScreen, lostScreen, drawScreen, Info;
    PhotonView phView; 
    
    // Sincronização
    int syncTime = 13;
    bool isAllPlayersInRoom = false;
    public static bool gameStarted = false;
    public static bool canvaInfo = false;
    
    // Cronometro
    bool startTimer;
    ExitGames.Client.Photon.Hashtable roomProperties;
    [SerializeField] TextMeshProUGUI timerText;
    float gameStartTime;
    float elapsedTime;
    [SerializeField] float totalGameTimeSecs = 120f;
    float totalTimeInitialSecs;
    int pointsPlayer1, pointsPlayer2; // Pontuações dos jogadores

    void Awake()
    {
        phView = GetComponent<PhotonView>();
    }

    void Start()
    {
        totalTimeInitialSecs = totalGameTimeSecs;
        CreatePlayers();
        CreateTimerRoomProps();
        Info.SetActive(false);
    }

    void Update()
    {
        if (!startTimer)
            return;

        elapsedTime = (float)PhotonNetwork.Time - gameStartTime;
        totalGameTimeSecs = totalTimeInitialSecs - elapsedTime;
        totalGameTimeSecs = Mathf.Clamp(totalGameTimeSecs, 0f, totalTimeInitialSecs);

        if (totalGameTimeSecs <= 0f)
        {
            startTimer = false;

            GameResult gameResult = GetGameResult();
            phView.RPC("DisplayGameResult", RpcTarget.All, gameResult);
        }

        UpdateGameTimer();

        if(canvaInfo == false)
        {
            Info.SetActive(false);
        }
    }

    void UpdateGameTimer()
    {
        timerText.text = $"Tempo restante: {Mathf.FloorToInt(totalGameTimeSecs / 60).ToString("00")}:{Mathf.FloorToInt(totalGameTimeSecs % 60).ToString("00")}";
    }

    GameResult GetGameResult()
    {        
        if (pointsPlayer1 > pointsPlayer2)
        {
            return GameResult.WIN;
        }
        else if (pointsPlayer2 > pointsPlayer1)
        {
            return GameResult.LOSE;
        }
        else
        {
            return GameResult.DRAW;
        }
    }

    void CreatePlayers()
    {
        if (PhotonNetwork.IsMasterClient)
            StartCoroutine(ExecPlayersCreationCorountine());
    }

    void CreateTimerRoomProps()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            roomProperties = new ExitGames.Client.Photon.Hashtable();
            gameStartTime = (float)PhotonNetwork.Time;
            roomProperties.Add("Timer", gameStartTime);
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomProperties);
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("Timer", out object valorTempoInicial))
            {
                gameStartTime = (float)valorTempoInicial;
            }
            else
            {
                print("Não foi possível obter o tempo inicial do jogo");
            }
        }
    }

    IEnumerator ExecPlayersCreationCorountine()
    {
        yield return new WaitForSeconds(syncTime);

        if (!isAllPlayersInRoom && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            phView.RPC("CreatePlayer", RpcTarget.AllBuffered);
            isAllPlayersInRoom = true;
            gameStarted = true;

            UpdatePoints(1, 0);
            UpdatePoints(2, 0);
        }

        if (isAllPlayersInRoom == false)
            StartCoroutine(ExecPlayersCreationCorountine());
    }

    IEnumerator LeftRoomCouroutine()
    {
        yield return new WaitForSeconds(5f);
        phView.RPC("EndGame", RpcTarget.All);
    }

    [PunRPC]
    void CreatePlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            print("Player One Created");
            PhotonNetwork.Instantiate(player1Controller.name, transform.position, Quaternion.identity);
        }
        else
        {
            print("Player Two Created");
            PhotonNetwork.Instantiate(player2Controller.name, transform.position, Quaternion.identity);
        }
        syncScreen.SetActive(false);
        startTimer = true;
    }

    [PunRPC]
    void DisplayGameResult(GameResult result)
    {
        winScreen.SetActive(false);
        lostScreen.SetActive(false);
        drawScreen.SetActive(false);

        if (result == GameResult.WIN)        
            winScreen.SetActive(true);        
        else if (result == GameResult.LOSE)        
            lostScreen.SetActive(true);    
        else    
           drawScreen.SetActive(true);
        
        startTimer = false;
        StartCoroutine(LeftRoomCouroutine());
    }

    [PunRPC]
    void EndGame()
    {
        print($"Finalizando jogo - cliente master: {PhotonNetwork.IsMasterClient}");
        PhotonNetwork.LeaveRoom(); // Desconecta o jogador da sala
        PhotonNetwork.Disconnect(); // Desconecta o jogador do servidor
        PhotonNetwork.LoadLevel("New Scene");
    }

    public void UpdatePoints(int player, int points)
    {
        if (player == 1)
        {
            pointsPlayer1 = points;
        }
        else if (player == 2)
        {
            pointsPlayer2 = points;
        }

        // RPC para sincronizar as pontuações em todos os clientes
        phView.RPC("SyncPoints", RpcTarget.All, pointsPlayer1, pointsPlayer2);
    }

    [PunRPC]
    void SyncPoints(int points1, int points2)
    {
        pointsPlayer1 = points1;
        pointsPlayer2 = points2;

        UpdateUIPoints(pointsPlayer1, pointsPlayer2);
    }

    void UpdateUIPoints(int points1, int points2)
    {
        player1ScoreText.text = pointsPlayer1.ToString();
        player2ScoreText.text = pointsPlayer2.ToString();
    }

    public void ButaoInfo()
    {
        Info.SetActive(true);
        canvaInfo = true;
    }

}

