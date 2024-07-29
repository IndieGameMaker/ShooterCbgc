using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    // 게임버전
    [SerializeField] private const string version = "1.0";
    // 닉네임
    [SerializeField] private string nickName = "Zack";

    void Awake()
    {
        // 게임 버전 설정
        PhotonNetwork.GameVersion = version;
        // 유저명 설정
        PhotonNetwork.NickName = nickName;
        // 포톤 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 서버에 접속 했을 때 호출되는 콜백
    public override void OnConnectedToMaster()
    {
        Debug.Log("포톤 서버에 접속 완료");

        // 로비에 입장(접속) 요청
        PhotonNetwork.JoinLobby();
    }

    // 로비에 입장 완료시 호출되는 콜백
    public override void OnJoinedLobby()
    {
        Debug.Log("로비에 입장 완료");
        // 무작위 룸에 입장 요청
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"무작위 입장 실퍠 : {message}");

        // Room 속성을 정의
        RoomOptions ro = new RoomOptions
        {
            MaxPlayers = 20,
            IsOpen = true,
            IsVisible = true,
        };

        // Room 생성 요청
        PhotonNetwork.CreateRoom("MyRoom", ro);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성 완료 !!");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방 입장 완료 !!");
    }
}
