using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScenes.SettingAndResultBattle;

namespace Gamepad.CharacterSelect
{
    public class CharacterSelectUtil : MonoBehaviour
    {
        /*プレイヤーの人数によって
         * オブジェクトの活性・非活性を変更する。
         * パネルやセレクターなど様々なファイルで使えるためUtilとする。
         */
        public static void checkPlayersNumAndHidden(int playerOnwNumber, GameObject gameObject)
        {
            if (BattleSetting.NumberOfPlayers < playerOnwNumber)
            {
                gameObject.SetActive(false);
            }

        }

    }
}
