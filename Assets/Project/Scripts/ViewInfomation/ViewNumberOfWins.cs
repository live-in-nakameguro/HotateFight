using GameScenes.SettingAndResultBattle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewNumberOfWins : MonoBehaviour
{
    public Text TextFrame;

    // Start is called before the first frame update
    void Start()
    {
        TextFrame.text = "Number Of Wins " + BattleSetting.NumberOfWins;
    }
}
