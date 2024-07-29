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


}
