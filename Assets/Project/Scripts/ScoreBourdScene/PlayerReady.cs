using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreBourdScene
{
    public class PlayerReady : MonoBehaviour
    {
        //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
        [SerializeField] int gamepadNumber = 0;

        public bool isReady = false;

        public Text TextFrame;

        // Start is called before the first frame update
        void Start()
        {
            TextFrame.text = "OK";
        }

        // Update is called once per frame
        void Update()
        {
            CheckReady();
        }

        void CheckReady()
        {
            if (isReady)
            {
                return;
            }

            // Aキーが押された時
            if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_A)))
            {
                isReady = true;
                TextFrame.color = Color.red;
                ScoreBourdController.IsReadyDict[gamepadNumber] = true;
            }
        }

        string SetGamepadNumber(string gamepadKey)
        {
            string gamepadNumberStr = "";
            if (gamepadNumber != 0)
            {
                gamepadNumberStr = $" {gamepadNumber}";
            }
            return string.Format(gamepadKey, gamepadNumberStr);
        }
    }
}
