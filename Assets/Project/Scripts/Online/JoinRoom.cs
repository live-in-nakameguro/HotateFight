using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OnlineBase;

public class JoinRoom : MonoBehaviour
{
    [SerializeField] Text RoomName;

    public void JoinRoomButton()
    {
        Debug.Log($"ボタンから入室してみる: room name: {RoomName.GetComponent<Text>().text}");
        OnlineLobby.ConnectToRoom(RoomName.GetComponent<Text>().text);
    }

}
