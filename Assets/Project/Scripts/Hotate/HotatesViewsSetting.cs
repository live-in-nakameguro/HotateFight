using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScenes.SettingAndResultBattle;

public class HotatesViewsSetting : MonoBehaviour
{
    [SerializeField] Camera player1Camera;
    [SerializeField] Camera player2Camera;
    [SerializeField] Camera player3Camera;
    [SerializeField] Camera player4Camera;

    // Start is called before the first frame update
    void Start()
    {
        HotateHiden();
        CameraDivide();
    }

    // Update is called once per frame

    void CameraDivide()
    {
        switch (BattleSetting.NumberOfPlayers)
        {
            case 1:
                player1Camera.rect = new Rect(0f, 0f, 0f, 0f);
                break;
            case 2:
                player1Camera.rect = new Rect(0f, 0f, 0.5f, 1f);
                player2Camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
                break;
            case 3:
                player1Camera.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
                player2Camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                player3Camera.rect = new Rect(0f, 0f, 0.5f, 0.5f);
                break;
            case 4:
                player1Camera.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
                player2Camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                player3Camera.rect = new Rect(0f, 0f, 0.5f, 0.5f);
                player4Camera.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
                break;
        }
    }

    void HotateHiden()
    {
        for (int playerNum=0; playerNum < BattleSetting.NumberOfPlayers; playerNum++)
        {
            transform.GetChild(playerNum).gameObject.SetActive(true);
        }
    }

}
