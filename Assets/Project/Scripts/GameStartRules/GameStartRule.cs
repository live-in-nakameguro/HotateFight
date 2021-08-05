using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScenes.Config;
using GameScenes.SettingAndResultBattle;
using UnityEngine.SceneManagement;

public class GameStartRule : MonoBehaviour
{
    public Text TextFrameWins;
    public Text TextFrameHP;
    public Text TextFrameStage;
    public Text TextFrameItems;

    private int numberOfMatches = BattleSetting.NumberOfWins;
    private float hotateHP= BattleSetting.HotateHP;
    private bool isRondom = BattleSetting.IsRondom;
    private bool isItemsOn = BattleSetting.IsItemsOn;


    public void countDownWins()
    {
        numberOfMatches -= 1;
        if (numberOfMatches < GameStartRuleConfig.MIN_NUMBER_OF_MATCHES)
        {
            numberOfMatches = GameStartRuleConfig.MAX_NUMBER_OF_MATCHES;
        }
        BattleSetting.NumberOfWins = numberOfMatches;
        TextFrameWins.text = numberOfMatches.ToString();
    }

    public void countUpWins()
    {
        numberOfMatches += 1;
        if (numberOfMatches > GameStartRuleConfig.MAX_NUMBER_OF_MATCHES)
        {
            numberOfMatches = GameStartRuleConfig.MIN_NUMBER_OF_MATCHES;
        }
        BattleSetting.NumberOfWins = numberOfMatches;
        TextFrameWins.text = numberOfMatches.ToString();
    }

    public void countDownHP()
    {
        hotateHP -= 10;
        if (hotateHP < GameStartRuleConfig.MIN_HOTATE_HP)
        {
            hotateHP = GameStartRuleConfig.MAX_HOTATE_HP;
        }
        BattleSetting.HotateHP = hotateHP;
        TextFrameHP.text = hotateHP.ToString();
    }

    public void countUpHP()
    {
        hotateHP += 10;
        if (hotateHP > GameStartRuleConfig.MAX_HOTATE_HP)
        {
            hotateHP = GameStartRuleConfig.MIN_HOTATE_HP;
        }
        BattleSetting.HotateHP = hotateHP;
        TextFrameHP.text = hotateHP.ToString();
    }

    public void changeStageRondom()
    {
        isRondom = !isRondom;
        
        BattleSetting.IsRondom = isRondom;
        if(isRondom) TextFrameStage.text = "Rondom";
        else TextFrameStage.text = "Select";
    }

    public void changeItemsOnOff()
    {
        isItemsOn = !isItemsOn;

        BattleSetting.IsItemsOn = isItemsOn;
        if (isItemsOn) TextFrameItems.text = "ON";
        else TextFrameItems.text = "OFF";
    }

    public void gameStartButton()
    {
        if (isRondom)
        {
            var randomStageOnList = new List<string>();
            var randomStageOffList = new List<string>();
            // ランダムスイッチがONのステージを抽出する。
            foreach (KeyValuePair<string, bool> pair in RandomStageSetting.RandomStageSettingDic)
            {
                if (pair.Value) randomStageOnList.Add(pair.Key);
                else randomStageOffList.Add(pair.Key);
            }

            // ランダムスイッチがすべてOFFだった場合、すべてONの場合と挙動を変わらなくする。
            if (randomStageOnList.Count == 0)
                randomStageOnList = randomStageOffList;

            //ランダムにステージを選択
            string selectedRandomStage = randomStageOnList[Random.Range(0, randomStageOnList.Count)];
            Debug.Log(selectedRandomStage);
            SceneManager.LoadScene(selectedRandomStage+ "Scene");
        }
        else
        {
            //ランダムがオフの場合、ステージセレクト画面に遷移
            SceneManager.LoadScene("StageSelectScene");
        }
    }
}
