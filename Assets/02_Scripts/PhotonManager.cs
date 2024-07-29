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
}
