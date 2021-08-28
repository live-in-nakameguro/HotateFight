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
        OnlineLobby.ConnectToRoom(RoomName.GetComponent<Text>().text);
    }

}
