using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScenes.SettingAndResultBattle;
using UnityEngine.SceneManagement;

public class PlayerNumSelect : MonoBehaviour
{
    [SerializeField] int numberOfPlayers;

    private bool firstPush = false;

    public void selectPlayerNum()
    {
        if (!firstPush)
        {
            firstPush = true;
            BattleSetting.NumberOfPlayers = numberOfPlayers;
            SceneManager.LoadScene("CharacterSelectScene");
        }
    }

}
