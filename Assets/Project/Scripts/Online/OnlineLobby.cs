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
        // ���[���ꗗ
        public static List<RoomInfo> roomViewList = new List<RoomInfo>();

        // �����̍ő�l��
        private static byte RoomMaxNumber = 4;

        public GameObject joinRommButtonPrefab;
        public GameObject viewPortContent;

        void Start()
        {
            // �}�X�^�[�T�[�o�ɐڑ����邽�߂̏���
            PhotonNetwork.ConnectUsingSettings();
        }

        /* Photon�T�[�o�ؒf����
         * ToDO: B�{�^�������������ɁA�^�C�g����ʂɖ߂鎞�ɌĂяo��
         */
        public void DisConnectPhoton()
        {
            PhotonNetwork.Disconnect();
            // ToDo: �^�C�g����ʂɖ߂�悤�ɂ���B
        }

        /* �y�R�[���o�b�N�z
         * �}�X�^�[�T�[�o�ɐڑ��������ɌĂ΂��
         */
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            // �}�X�^�[�T�[�o�ɐڑ��ł�����A���̓��r�[�ɐڑ�����B
            PhotonNetwork.JoinLobby();
        }

        /*�y�R�[���o�b�N�z
         * �}�X�^�[�T�[�o�ɐڑ�"���s"�������ɌĂ΂��
         */
        public override void OnDisconnected(DisconnectCause cause)
        {
            //ToDo: �|�b�v�A�b�v����\�����A�^�C�g����ʂɖ߂�悤�ɂ���B  
        }

        /*�y�R�[���o�b�N�z
         * ���r�[�ڑ��������ɌĂ΂��B
        */
        public override void OnJoinedLobby()
        {
            // ���r�[�ɎQ������
            base.OnJoinedLobby();
        }

        // ���[���V�K�쐬����
        // ���[����������l�̓z�X�g�ɂȂ�̂ŁA�����Ń��[���ɎQ�����邱�ƂɂȂ�B
        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            // �����̍ő�l��
            roomOptions.MaxPlayers = RoomMaxNumber;

            string roomName = $"ROOM {roomViewList.Count + 1f}";
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        // ���[����������(�����̃��[���ɎQ������)
        public static void ConnectToRoom(string roomName)
        {            
            PhotonNetwork.JoinRoom(roomName);
        }

        //�y�R�[���o�b�N�z
        // ���[���쐬����
        public override void OnCreatedRoom()
        {

        }

        //�y�R�[���o�b�N�z
        // ���[���쐬���s
        // ���ꖼ�̃��[�������݂��鎞�Ȃ�
        public override void OnCreateRoomFailed(short returnCode, string message)
        {

        }

        //�y�R�[���o�b�N�z
        // ���[���ɓ���������
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            Debug.Log("���[�������I!!");

            //�ҋ@���Ɉړ�
            PhotonNetwork.IsMessageQueueRunning = false;
            SceneManager.LoadSceneAsync("OnlineWaitingScene", LoadSceneMode.Single);

        }

        //�y�R�[���o�b�N�z
        // ���[���ɓ����Ɏ��s������
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("���[���������s�I!!");
        }

        //�y�R�[���o�b�N�z
        // ���[���ꗗ�X�V����
        // (���r�[�ɓ����������A���̃v���C���[���X�V�������݂̂ɌĂ΂��)
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            base.OnRoomListUpdate(roomList);

            // ���[���ꗗ�X�V
            roomViewList.Clear();
            foreach (var info in roomList)
            {
                roomViewList.Add(info);

            }
            UpdateRoomList();
            
        }

        //���[���ގ�����Ƃ�
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