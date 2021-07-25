using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotate.Dead
{
    public class HotateDeadController : MonoBehaviour
    {
        // TODO プレイヤーの人数を設定する
        [SerializeField] int PlayerNum = 2;

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

            for (int i = 1; i <= PlayerNum; i++)
            {
                if (IsHotateDeadDict[i])
                {
                    deadNum += 1;
                }
            }

            // 1人だけ生き残った場合
            if (deadNum == PlayerNum - 1)
            {
                // TODO 途中成績画面を表示する。

                // 仮の処理
                SceneManager.LoadScene("TitleScene");
            }

            // 相打ちになった場合
            if (deadNum == PlayerNum)
            {
                // TODO どうする？
            }
        }
    }
}
