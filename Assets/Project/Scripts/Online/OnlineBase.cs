using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common.PopUp;

namespace OnlineBase
{
    public class OnlineBase : MonoBehaviourPunCallbacks
    {
        // �����̍ő�l��
        private static byte RoomMaxNumber = 4;

        [SerializeField] GameObject PopUpPanel;


        void Start()
        {
            // �}�X�^�[�T�[�o�ɐڑ����邽�߂̏���
            PhotonNetwork.ConnectUsingSettings();
        }

        /*==================================== �y�R�[���o�b�N�֐��z==================================== */
        /* �}�X�^�[�T�[�o�ɐڑ��������ɌĂ΂��
         */
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            // �}�X�^�[�T�[�o�ɐڑ��ł�����A���̓��r�[�ɐڑ�����B
            PhotonNetwork.JoinLobby();
        }

        /* �}�X�^�[�T�[�o�ɐڑ�"���s"�������ɌĂ΂��
         */
        public override void OnDisconnected(DisconnectCause cause)
        {
            //���r�[��ʂɖ߂�悤�ɂ���B  
            SceneManager.LoadSceneAsync("OnlineLobbyScene");
        }

        /* ���r�[�ڑ��������ɌĂ΂��B
        */
        public override void OnJoinedLobby()
        {
            // ���r�[�ɎQ������
            base.OnJoinedLobby();
        }

        // ���[���쐬����
        public override void OnCreatedRoom()
        {

        }

        // ���[���쐬���s
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            PopUp.OpenOkPopUp(PopUpPanel, "Failed to Create Room!",
                "There is already a Room with the same Number. Pease recreate it with a different Number...");

        }

        // ���[���ɓ���������
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            var localPlayer = PhotonNetwork.LocalPlayer;
            PhotonNetwork.IsMessageQueueRunning = false;
            // ���[���z�X�g�Ȃ�ݒ��ʂɈړ�����
            if (localPlayer.IsMasterClient)
            {
                SceneManager.LoadSceneAsync("OnlineGameStartRuleScene", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadSceneAsync("WaitingRoomScene", LoadSceneMode.Single);
            }

        }

        // ���[���ɓ����Ɏ��s������
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("���[���������s�I!!");
            PopUp.OpenOkPopUp(PopUpPanel, "Failed to Enter the Room!",
                "This is probably because the number of people who can enter the room has been reached or because the room does not exist. " +
                "Please find another room.");
        }

        // ���[������ޏo�������ɌĂ΂��R�[���o�b�N
        public override void OnLeftRoom()
        {
            
        }

        // ���[���ꗗ�X�V����
        // (���r�[�ɓ����������A���̃v���C���[���X�V�������݂̂ɌĂ΂��)
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {

        }

        /*==================================== �y�Ǝ���`�̊֐��z==================================== */
        // �}�X�^�[�T�[�o����̐ؒf
        public void DisConnectPhoton()
        {
            PhotonNetwork.Disconnect();
        }

        //���[���쐬
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
                PopUp.OpenOkPopUp(PopUpPanel, "Invalid Room Number!", "RoomNumber should be a five or six character number!!!");

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
            // ���[���z�X�g�Ȃ�Q�[�����[����ύX�\
            if (localPlayer.IsMasterClient)
            {
                //ToDo: �Q�[�����[����ύX���鏈�����L��
            }
            
        }

    }
}