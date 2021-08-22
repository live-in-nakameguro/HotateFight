using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// ネットワーク接続スクリプト
public class RandomMatchMaker : MonoBehaviourPunCallbacks
{
    public GameObject PhotonObject;

    void Start()
    {
        // マスターサーバに接続するための処理
        // 参考
        // https://zenn.dev/o8que/books/bdcb9af27bdd7d/viewer/322089
        PhotonNetwork.ConnectUsingSettings();   

    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // ランダムの部屋に接続
        PhotonNetwork.JoinRandomRoom();
    }

    // Photonのサーバーから切断された時に呼ばれるコールバック
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"サーバーとの接続が切断されました: {cause.ToString()}");
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        // 部屋の最大人数
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        //オブジェクトのインスタンス化
        //②position　③lローテーション　④
        PhotonNetwork.Instantiate(
            PhotonObject.name,
            new Vector3(0f, 1f, 0f),
            Quaternion.identity,
            0
       );

    }
}
