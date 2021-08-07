using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hotate;
using UnityEngine.SceneManagement;
using Gamepad.CharacterSelect;

namespace CharacterSelect.Panel
{
    public class PlayerPanel : MonoBehaviour
    {
        //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
        [SerializeField] int gamepadNumber = 0;

        private Characters character = Characters.NoSelect;

        // キャラクターの色
        public static Color characterColor;

        private bool isSelectCharacter = false;

        //ゲームプレイ人数に満たない場合、オブジェクトを非表示にする。
        private void Start()
        {
            CharacterSelectUtil.CheckPlayersNumAndHidden(gamepadNumber, gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            ViewCharacter();
            SelectCharacter();
        }

        void ViewCharacter()
        {
            if (CharacterPanel_HotateBlue.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateBlue.character;
                characterColor = CharacterPanel_HotateBlue.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateBlue.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateBlue.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateBrown.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateBrown.character;
                characterColor = CharacterPanel_HotateBrown.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateBrown.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateBrown.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateYellow.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateYellow.character;
                characterColor = CharacterPanel_HotateYellow.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateYellow.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateYellow.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        void SelectCharacter()
        {
            if (isSelectCharacter)
            {
                return;
            }

            if (transform.GetChild(0).gameObject.activeSelf)
            {
                if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_A)))
                {
                    isSelectCharacter = true;
                    Debug.Log(string.Format("Player{0}:{1}", gamepadNumber, character));
                    HotateColor.HotateColorDict[gamepadNumber] = characterColor;
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
