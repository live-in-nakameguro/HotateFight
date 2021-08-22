using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// ネットワーク接続スクリプト
public class OnlineWaitingRoom : MonoBehaviourPunCallbacks
{
    public GameObject PhotonObject;

    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        PhotonNetwork.Instantiate(
            PhotonObject.name,
            new Vector3(0f, 1f, 0f),
            Quaternion.identity,
            0
       );
    }

}
