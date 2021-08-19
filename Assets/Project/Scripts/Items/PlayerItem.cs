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
        // GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
        [SerializeField] int gamepadNumber = 0;

        // アイテム画像表示
        [SerializeField] Image image;

        // ホタテ
        [SerializeField] GameObject hotate;

        // アイテム発射点（弾丸発射個所と同じ座標）
        [SerializeField] Transform muzzle;

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
            // アイテムを持っている場合
            if (playerItemDict[gamepadNumber] != ItemSetting.Items.None)
            {
                if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_Y)))
                {
                    ExecuteItem(playerItemDict[gamepadNumber]);
                }
            }
        }

        void ExecuteItem(ItemSetting.Items item)
        {
            Debug.Log("アイテム使用：" + item);
            switch (item) 
            {
                case ItemSetting.Items.None:
                    break;
                case ItemSetting.Items.Bomb:
                    ShootingBomb.Shooting(hotate, ItemSetting.ItemPrefabDict[ItemSetting.Items.Bomb], muzzle);
                    break;
                case ItemSetting.Items.LandMines:
                    break;
                default:
                    break;
            }
            playerItemDict[gamepadNumber] = ItemSetting.Items.None;
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
