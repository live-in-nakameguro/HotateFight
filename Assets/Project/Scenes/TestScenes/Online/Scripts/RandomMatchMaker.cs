using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// �l�b�g���[�N�ڑ��X�N���v�g
public class RandomMatchMaker : MonoBehaviourPunCallbacks
{
    public GameObject PhotonObject;

    void Start()
    {
        // �}�X�^�[�T�[�o�ɐڑ����邽�߂̏���
        // �Q�l
        // https://zenn.dev/o8que/books/bdcb9af27bdd7d/viewer/322089
        PhotonNetwork.ConnectUsingSettings();   

    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // �����_���̕����ɐڑ�
        PhotonNetwork.JoinRandomRoom();
    }

    // Photon�̃T�[�o�[����ؒf���ꂽ���ɌĂ΂��R�[���o�b�N
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"�T�[�o�[�Ƃ̐ڑ����ؒf����܂���: {cause.ToString()}");
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        // �����̍ő�l��
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        //�I�u�W�F�N�g�̃C���X�^���X��
        //�Aposition�@�Bl���[�e�[�V�����@�C
        PhotonNetwork.Instantiate(
            PhotonObject.name,
            new Vector3(0f, 1f, 0f),
            Quaternion.identity,
            0
       );

    }
}
