using Gamepad.Config;
using GameScenes.SettingAndResultBattle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Item
{
    public class PlayerItem : MonoBehaviour
    {
        // GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
        [SerializeField] int gamepadNumber = 0;

        // �A�C�e���摜�\��
        [SerializeField] Image image;

        public static Dictionary<int, ItemSetting.Items> playerItemDict;

        static PlayerItem()
        {
            SceneManager.sceneLoaded += Init;
        }

        private static void Init(Scene loadingScene, LoadSceneMode loadSceneMode)
        {
            playerItemDict = new Dictionary<int, ItemSetting.Items>()
            {
                { 1, ItemSetting.Items.None},
                { 2, ItemSetting.Items.None},
                { 3, ItemSetting.Items.None},
                { 4, ItemSetting.Items.None}
            };
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ViewItem();
            UseItem();
        }

        void ViewItem()
        {
            var sprite = ItemSetting.ItemTextureDict[playerItemDict[gamepadNumber]];
            image.sprite = sprite;
        }

        void UseItem()
        {
            // �A�C�e���������Ă���ꍇ
            if (playerItemDict[gamepadNumber] != ItemSetting.Items.None)
            {
                if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_Y)))
                {
                    Debug.Log("�A�C�e���g�p�F" + playerItemDict[gamepadNumber]);
                    playerItemDict[gamepadNumber] = ItemSetting.Items.None;
                }
            }
        }

        string SetGamepadNumber(string gamepadKey)
        {
            string gamepadNumberStr = "";
            if (gamepadNumber != 0)
            {
                gamepadNumberStr = $" {gamepadNumber}";
            }
            //Debug.Log(string.Format(gamepadKey, gamepadNumberStr));
            return string.Format(gamepadKey, gamepadNumberStr);
        }
    }
}
