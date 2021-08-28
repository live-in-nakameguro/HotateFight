 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace OnlineBase
{
    public class OnlineLobby : MonoBehaviourPunCallbacks
    {
        // ルーム一覧
        public static List<RoomInfo> roomViewList = new List<RoomInfo>();

        // 部屋の最大人数
        private static byte RoomMaxNumber = 4;

        public GameObject joinRommButtonPrefab;
        public GameObject viewPortContent;

        void Start()
        {
            // マスターサーバに接続するための処理
            PhotonNetwork.ConnectUsingSettings();
        }

        /* Photonサーバ切断処理
         * ToDO: Bボタンを押した時に、タイトル画面に戻る時に呼び出す
         */
        public void DisConnectPhoton()
        {
            PhotonNetwork.Disconnect();
            // ToDo: タイトル画面に戻るようにする。
        }

        /* 【コールバック】
         * マスターサーバに接続した時に呼ばれる
         */
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            // マスターサーバに接続できたら、次はロビーに接続する。
            PhotonNetwork.JoinLobby();
        }

        /*【コールバック】
         * マスターサーバに接続"失敗"した時に呼ばれる
         */
        public override void OnDisconnected(DisconnectCause cause)
        {
            //ToDo: ポップアップ等を表示し、タイトル画面に戻るようにする。  
        }

        /*【コールバック】
         * ロビー接続完了時に呼ばれる。
        */
        public override void OnJoinedLobby()
        {
            // ロビーに参加する
            base.OnJoinedLobby();
        }

        // ルーム新規作成処理
        // ルームを作った人はホストになるので、自動でルームに参加することになる。
        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            // 部屋の最大人数
            roomOptions.MaxPlayers = RoomMaxNumber;

            string roomName = $"ROOM {roomViewList.Count + 1f}";
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        // ルーム入室処理(既存のルームに参加する)
        public static void ConnectToRoom(string roomName)
        {            
            PhotonNetwork.JoinRoom(roomName);
        }

        //【コールバック】
        // ルーム作成完了
        public override void OnCreatedRoom()
        {

        }

        //【コールバック】
        // ルーム作成失敗
        // 同一名のルームが存在する時など
        public override void OnCreateRoomFailed(short returnCode, string message)
        {

        }

        //【コールバック】
        // ルームに入室した時
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            Debug.Log("ルーム入室！!!");

            //待機室に移動
            PhotonNetwork.IsMessageQueueRunning = false;
            SceneManager.LoadSceneAsync("OnlineWaitingScene", LoadSceneMode.Single);

        }

        //【コールバック】
        // ルームに入室に失敗した時
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("ルーム入室失敗！!!");
        }

        //【コールバック】
        // ルーム一覧更新処理
        // (ロビーに入室した時、他のプレイヤーが更新した時のみに呼ばれる)
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            base.OnRoomListUpdate(roomList);

            // ルーム一覧更新
            roomViewList.Clear();
            foreach (var info in roomList)
            {
                roomViewList.Add(info);

            }
            UpdateRoomList();
            
        }

        //ルーム退室するとき
        public void LeaveRoom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
            }
        }

        public void UpdateRoomList(bool isRoomIn=false)
        {
            foreach (Transform child in viewPortContent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (RoomInfo roomInfo in roomViewList)
            {
                var parent = viewPortContent.transform;
                GameObject joinButtton = Instantiate(joinRommButtonPrefab, parent);
                joinButtton.transform.Find("JoinRoomButton").transform.Find("RoomName").GetComponent<Text>().text = roomInfo.Name;
                joinButtton.transform.Find("PlayerNumber").GetComponent<Text>().text = $"{roomInfo.PlayerCount}/{RoomMaxNumber}";
            }

        }

    }
}