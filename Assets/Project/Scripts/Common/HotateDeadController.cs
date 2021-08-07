using GameScenes.SettingAndResultBattle;
using ScoreBourdScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotate.Dead
{
    public class HotateDeadController : MonoBehaviour
    {
        public static Dictionary<int, bool> IsHotateDeadDict;

        // シーン移動するたびに呼ばれる。
        static HotateDeadController()
        {
            SceneManager.sceneLoaded += Init;
        }

        private static void Init(Scene loadingScene, LoadSceneMode loadSceneMode)
        {
            IsHotateDeadDict = new Dictionary<int, bool>()
            {
                { 1, false},
                { 2, false},
                { 3, false},
                { 4, false},
            };
        }

        void Update()
        {
            DeadCheck();
        }

        private void DeadCheck()
        {
            int deadNum = 0;
            int AliveHotateNumber = 0;

            for (int i = 1; i <= BattleSetting.NumberOfPlayers; i++)
            {
                if (IsHotateDeadDict[i])
                {
                    deadNum += 1;
                }
                else
                {
                    AliveHotateNumber = i;
                }
            }

            // 1人だけ生き残った場合
            if (deadNum == BattleSetting.NumberOfPlayers - 1)
            {
                ScoreBourdController.PlayerNumberOfWins[AliveHotateNumber] += 1;
                // 途中成績画面を表示する。
                SceneManager.LoadScene("ScoreBourdScene");
            }

            // 相打ちになった場合
            if (deadNum == BattleSetting.NumberOfPlayers)
            {
                // TODO どうする？
            }
        }
    }
}
