using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelect.Panel
{
    public class PlayerPanel : MonoBehaviour
    {
        //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
        [SerializeField] int gamepadNumber = 0;

        private Characters character = Characters.NoSelect;

        private bool isSelectCharacter = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ViewCharacter();
            SelectCharacter();
        }

        void ViewCharacter()
        {
            if (CharacterPanel.playerSelectCharacter[gamepadNumber])
            {
                //transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = CharacterPanel.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel.characterColor;
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
                    character = CharacterPanel.characterName;
                    Debug.Log(string.Format("Player{0}:{1}", gamepadNumber, character));
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
