using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreBourdScene
{
    public class PlayerReady : MonoBehaviour
    {
        //GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
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

            // A�L�[�������ꂽ��
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
