using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    string mode;                 // ���[�h(ONLINE, OFFLINE)
    string dispStatus;           // ��ʍ��ځF���
    string dispMessage;          // ��ʍ��ځF���b�Z�[�W
    string dispRoomName;         // ��ʍ��ځF���[����
    List<RoomInfo> roomDispList; // ��ʍ��ځF���[���ꗗ

    // ���
    public enum Status
    {
        ONLINE,   // �I�����C��
        OFFLINE,  // �I�t���C��
    };

    private void Start()
    {
        initParam();
    }

    // �ϐ�����������
    private void initParam()
    {
        dispRoomName = "";
        dispMessage = "";
        dispStatus = Status.OFFLINE.ToString();
        roomDispList = new List<RoomInfo>();
    }

    // Photon�T�[�o�ڑ�����
    public void ConnectPhoton(bool boolOffline)
    {
        if (boolOffline)
        {
            // �I�t���C�����[�h��ݒ�
            mode = Status.OFFLINE.ToString();
            PhotonNetwork.OfflineMode = true; // OnConnectedToMaster()���Ă΂��
            dispMessage = "OFFLINE���[�h�ŋN�����܂����B";
            return;
        }
        // Photon�T�[�o�ɐڑ�����
        mode = Status.ONLINE.ToString();
        PhotonNetwork.OfflineMode = false;
        PhotonNetwork.ConnectUsingSettings();
    }

    // Photon�T�[�o�ؒf����
    public void DisConnectPhoton()
    {
        PhotonNetwork.Disconnect();
        // �ϐ�������
        initParam();
    }

    // �R�[���o�b�N�FPhoton�T�[�o�ڑ�����
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        if (Status.ONLINE.ToString().Equals(mode))
        {
            dispStatus = Status.ONLINE.ToString();
            dispMessage = "�T�[�o�ɐڑ����܂����B";
            // ���r�[�ɐڑ�
            PhotonNetwork.JoinLobby();
        }
    }

    // �R�[���o�b�N�FPhoton�T�[�o�ڑ����s
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        dispMessage = "�T�[�o����ؒf���܂����B";
        dispStatus = Status.OFFLINE.ToString();
    }

    // �R�[���o�b�N�F���r�[��������
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }

    // ���[���ꗗ�X�V����
    // (���r�[�ɓ����������A���̃v���C���[���X�V�������̂�)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        // ���[���ꗗ�X�V
        foreach (var info in roomList)
        {
            if (!info.RemovedFromList)
            {
                // �X�V�f�[�^���폜�łȂ��ꍇ
                roomDispList.Add(info);
            }
            else
            {
                // �X�V�f�[�^���폜�̏ꍇ
                roomDispList.Remove(info);
            }
        }
    }

    // ���[���쐬����
    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    // ���[����������
    public void ConnectToRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    // �R�[���o�b�N�F���[���쐬����
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        dispMessage = "���[�����쐬���܂����B";
    }

    // �R�[���o�b�N�F���[���쐬���s
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        dispMessage = "���[���쐬�Ɏ��s���܂����B";
    }

    // �R�[���o�b�N�F���[���ɓ���������
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        // �\�����[�����X�g�ɒǉ�����
        roomDispList.Add(PhotonNetwork.CurrentRoom);
        dispMessage = "�y" + PhotonNetwork.CurrentRoom.Name + "�z" + "�ɓ������܂����B";
    }

    // ---------- �ݒ�GUI ----------
    void OnGUI()
    {
        float scale = Screen.height / 480.0f;
        GUI.matrix = Matrix4x4.TRS(new Vector3(
            Screen.width * 0.5f, Screen.height * 0.5f, 0),
            Quaternion.identity,
            new Vector3(scale, scale, 1.0f));

        GUI.Window(0, new Rect(-200, -200, 400, 400),
            NetworkSettingWindow, "Photon�ڑ��e�X�g");
    }

    Vector2 scrollPosition;
    void NetworkSettingWindow(int windowID)
    {
        // �X�e�[�^�X, ���b�Z�[�W�̕\��
        GUILayout.BeginHorizontal();
        GUILayout.Label("���: " + dispStatus, GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        if (Status.ONLINE.ToString().Equals(dispStatus))
        {
            // �T�[�o�ڑ����̂ݕ\��
            if (GUILayout.Button("�ؒf"))
                DisConnectPhoton();
        }
        GUILayout.EndHorizontal();
        GUILayout.Label(dispMessage);
        GUILayout.Space(20);

        if (!Status.ONLINE.ToString().Equals(dispStatus))
        {
            // --- �����\�����AOFFLINE���[�h�̂ݕ\��
            // �}�X�^�[�T�[�o�ɐڑ�����
            GUILayout.Label("�y���[�h�I���z");
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("ONLINE Mode"))
                ConnectPhoton(false);
            if (GUILayout.Button("OFFLINE Mode"))
                ConnectPhoton(true);
            GUILayout.EndHorizontal();
        }
        else if (Status.ONLINE.ToString().Equals(dispStatus))
        {
            // --- ONLINE���[�h�̂ݕ\��
            if (!(PhotonNetwork.CurrentRoom != null))
            {
                // ���[���쐬
                GUILayout.Label("�y���[���쐬�z");
                GUILayout.BeginHorizontal();
                GUILayout.Label("�@���[����: ");
                dispRoomName = GUILayout.TextField(dispRoomName, GUILayout.Width(150));
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                // �쐬�{�^��
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("�쐬 & ����"))
                {
                    CreateRoom(dispRoomName);
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(20);

                // ���[���ꗗ
                GUILayout.Label("�y���[���ꗗ (�N���b�N�œ���)�z");
                // �ꗗ�\��
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(380), GUILayout.Height(100));
                if (roomDispList != null && roomDispList.Count > 0)
                {
                    // �X�V�{�^��
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("�X�V"))
                    {
                        // ���r�[�ɓ��蒼��
                        roomDispList = new List<RoomInfo>();
                        PhotonNetwork.LeaveLobby();
                        PhotonNetwork.JoinLobby();
                    }
                    // ���[���ꗗ
                    GUILayout.EndHorizontal();
                    foreach (RoomInfo roomInfo in roomDispList)
                        if (GUILayout.Button(roomInfo.Name, GUI.skin.box, GUILayout.Width(360)))
                            ConnectToRoom(roomInfo.Name);
                }
                GUILayout.EndScrollView();
            }
        }
    }
}