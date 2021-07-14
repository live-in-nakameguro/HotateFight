using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScenes.SettingAndResultBattle;

public class ViewNumberOfMatches : MonoBehaviour
{
    public Text TextFrame;

    private void Start()
    {
        //シーンに変数を渡せるかのテストをするための仮の文字です。
        TextFrame.text = "Round: " + BattleSetting.getNumberOfWins().ToString();
    }
    
}
