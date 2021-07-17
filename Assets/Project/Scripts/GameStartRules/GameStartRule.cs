using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScenes.Config;
using GameScenes.SettingAndResultBattle;

public class GameStartRule : MonoBehaviour
{
    public Text TextFrame;

    private int numberOfMatches = BattleSetting.NumberOfWins;

    public void countDownWins()
    {
        numberOfMatches -= 1;
        if (numberOfMatches < GameStartRuleConfig.MIN_NUMBER_OF_MATCHES)
        {
            numberOfMatches = GameStartRuleConfig.MAX_NUMBER_OF_MATCHES;
        }
        BattleSetting.NumberOfWins = numberOfMatches;
        TextFrame.text = numberOfMatches.ToString();
    }

    public void countUpWins()
    {
        numberOfMatches += 1;
        if (numberOfMatches > GameStartRuleConfig.MAX_NUMBER_OF_MATCHES)
        {
            numberOfMatches = GameStartRuleConfig.MIN_NUMBER_OF_MATCHES;
        }
        BattleSetting.NumberOfWins = numberOfMatches;
        TextFrame.text = numberOfMatches.ToString();
    }

}
