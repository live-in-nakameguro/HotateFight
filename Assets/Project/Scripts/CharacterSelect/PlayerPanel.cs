using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelect.Panel
{
    public class PlayerPanel : MonoBehaviour
    {
        //GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
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
            if (CharacterPanel_HotateBlue.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateBlue.character;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateBlue.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateBlue.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateBrown.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateBrown.character;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateBrown.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateBrown.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateYellow.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateYellow.character;
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
