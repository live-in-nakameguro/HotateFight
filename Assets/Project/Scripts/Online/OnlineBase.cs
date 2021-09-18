using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace OnlineBase
{
    public class OnlineBase : MonoBehaviourPunCallbacks
    {
        // 部屋の最大人数
        private static byte RoomMaxNumber = 4;

        
        void Start()
        {
            // マスターサーバに接続するための処理
            PhotonNetwork.ConnectUsingSettings();
        }

        /*==================================== 【コールバック関数】==================================== */
        /* マスターサーバに接続した時に呼ばれる
         */
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            // マスターサーバに接続できたら、次はロビーに接続する。
            PhotonNetwork.JoinLobby();
        }

        /* マスターサーバに接続"失敗"した時に呼ばれる
         */
        public override void OnDisconnected(DisconnectCause cause)
        {
            //ロビー画面に戻るようにする。  
            SceneManager.LoadSceneAsync("OnlineLobbyScene");
        }

        /* ロビー接続完了時に呼ばれる。
        */
        public override void OnJoinedLobby()
        {
            // ロビーに参加する
            base.OnJoinedLobby();
        }

        // ルーム作成完了
        public override void OnCreatedRoom()
        {

        }

        // ルーム作成失敗
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log("ルームの作成に失敗しました。");
            // ToDo: 同一名称のルームが存在した旨のポップアップを表示する。

        }

        // ルームに入室した時
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            var localPlayer = PhotonNetwork.LocalPlayer;
            PhotonNetwork.IsMessageQueueRunning = false;
            // ルームホストなら設定画面に移動する
            if (localPlayer.IsMasterClient)
            {
                SceneManager.LoadSceneAsync("OnlineGameStartRuleScene", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadSceneAsync("WaitingRoomScene", LoadSceneMode.Single);
            }

        }

        // ルームに入室に失敗した時
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("ルーム入室失敗！!!");
            // ToDo: ルーム参加可能人数に到達している旨のポップアップを表示する。

        }

        // ルームから退出した時に呼ばれるコールバック
        public override void OnLeftRoom()
        {
            
        }

        // ルーム一覧更新処理
        // (ロビーに入室した時、他のプレイヤーが更新した時のみに呼ばれる)
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {

        }

        /*==================================== 【独自定義の関数】==================================== */
        // マスターサーバからの切断
        public void DisConnectPhoton()
        {
            PhotonNetwork.Disconnect();
        }

        //ルーム作成
        public void CreatRondomRoom()
        {
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = RoomMaxNumber;

            PhotonNetwork.CreateRoom(null, roomOptions);
        }

        public void CreatPrivateRoom(Text RoomNameText)
        {
            string RoomName = RoomNameText.text.ToString();

            if (!IsInvalidRoomName(RoomName))
                return;

            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = RoomMaxNumber;
            roomOptions.IsVisible = false;

            PhotonNetwork.CreateRoom(RoomName, roomOptions);
        }

        public void JoinPrivateRoom(Text RoomNameText)
        {
            string RoomName = RoomNameText.text.ToString();

            if (!IsInvalidRoomName(RoomName))
                return;

            PhotonNetwork.JoinRoom(RoomName);
        }

        private bool IsInvalidRoomName(string RoomName)
        {
            if(!Regex.IsMatch(RoomName, "[0-9]{5,6}")) {
                // ToDo: 有効なルーム名じゃない旨のポップアップ表示
                Debug.Log($"有効なRoomNameじゃない!!{RoomName}");

                return false;
            }
            return true;
        }

        public void JoinRondomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void ChangeGameRule()
        {
            var localPlayer = PhotonNetwork.LocalPlayer;
            PhotonNetwork.IsMessageQueueRunning = false;
            // ルームホストならゲームルールを変更可能
            if (localPlayer.IsMasterClient)
            {
                //ToDo: ゲームルールを変更する処理を記載
            }
            
        }

    }
}