using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScenes.SettingAndResultBattle;

namespace Gamepad.CharacterSelect
{
    public class CharacterSelectUtil : MonoBehaviour
    {
        /*�v���C���[�̐l���ɂ����
         * �I�u�W�F�N�g�̊����E�񊈐���ύX����B
         * �p�l����Z���N�^�[�ȂǗl�X�ȃt�@�C���Ŏg���邽��Util�Ƃ���B
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
