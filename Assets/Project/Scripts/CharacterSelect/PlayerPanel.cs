using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hotate;
using UnityEngine.SceneManagement;
using Gamepad.CharacterSelect;
using UnityEngine.UI;
using GameScenes.SettingAndResultBattle;

namespace CharacterSelect.Panel
{
    public class PlayerPanel : MonoBehaviour
    {
        AudioSource audioSource;

        //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
        [SerializeField] int gamepadNumber = 0;

        private Characters character = Characters.NoSelect;

        // キャラクターの色
        private Color characterColor;
        // パンチするときの声
        private AudioClip punchVoice;
        // 弾丸を発射する声
        private AudioClip shootingVoice;

        public Text TextFrame;

        public static Dictionary<int, bool> playerSelectCharacter;

        private bool isAllSelected = false;

        static PlayerPanel()
        {
            SceneManager.sceneLoaded += Init;
        }

        private static void Init(Scene loadingScene, LoadSceneMode loadSceneMode)
        {
            playerSelectCharacter = new Dictionary<int, bool>()
            {
                { 1,false},
                { 2,true}, // デバッグの際は、ここをtrueにすれば、1人プレイ可能
                { 3,false},
                { 4,false}
            };
        }

        //ゲームプレイ人数に満たない場合、オブジェクトを非表示にする。
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            CharacterSelectUtil.CheckPlayersNumAndHidden(gamepadNumber, gameObject);
            TextFrame.text = "OK";
        }

        // Update is called once per frame
        void Update()
        {
            if (!isAllSelected) {
                BackScene(); // SelectCharacter()の後ろでBackScene()を実装すると、不具合が発生するので注意。
                ViewCharacter();
                SelectCharacter();
                AllSelected();
            }
        }

        void ViewCharacter()
        {
            if (CharacterPanel_HotateBlue.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateBlue.character;
                characterColor = CharacterPanel_HotateBlue.characterColor;
                punchVoice = CharacterPanel_HotateBlue.m_PunchVoice;
                shootingVoice = CharacterPanel_HotateBlue.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateBlue.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateBlue.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateBrown.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateBrown.character;
                characterColor = CharacterPanel_HotateBrown.characterColor;
                punchVoice = CharacterPanel_HotateBrown.m_PunchVoice;
                shootingVoice = CharacterPanel_HotateBrown.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateBrown.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateBrown.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateYellow.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateYellow.character;
                characterColor = CharacterPanel_HotateYellow.characterColor;
                punchVoice = CharacterPanel_HotateYellow.m_PunchVoice;
                shootingVoice = CharacterPanel_HotateYellow.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateYellow.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateYellow.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateRed.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateRed.character;
                characterColor = CharacterPanel_HotateRed.characterColor;
                punchVoice = CharacterPanel_HotateRed.m_PunchVoice;
                shootingVoice = CharacterPanel_HotateRed.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateRed.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateRed.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateRed.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateGreen.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateGreen.character;
                characterColor = CharacterPanel_HotateGreen.characterColor;
                punchVoice = CharacterPanel_HotateGreen.m_PunchVoice;
                shootingVoice = CharacterPanel_HotateGreen.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateGreen.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateGreen.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotatePink.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotatePink.character;
                characterColor = CharacterPanel_HotatePink.characterColor;
                punchVoice = CharacterPanel_HotatePink.m_PunchVoice;
                shootingVoice = CharacterPanel_HotatePink.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotatePink.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotatePink.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateWhite.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateWhite.character;
                characterColor = CharacterPanel_HotateWhite.characterColor;
                punchVoice = CharacterPanel_HotateWhite.m_PunchVoice;
                shootingVoice = CharacterPanel_HotateWhite.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateWhite.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateWhite.characterColor;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (CharacterPanel_HotateBlack.playerSelectCharacter[gamepadNumber])
            {
                character = CharacterPanel_HotateBlack.character;
                characterColor = CharacterPanel_HotateBlack.characterColor;
                punchVoice = CharacterPanel_HotateBlack.m_PunchVoice;
                shootingVoice = CharacterPanel_HotateBlack.m_ShootingVoice;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = CharacterPanel_HotateBlack.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = CharacterPanel_HotateBlack.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[2].color = CharacterPanel_HotateBlack.characterColor;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[2].color = CharacterPanel_HotateBlack.characterBodyColor; 
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        void SelectCharacter()
        {
            if (playerSelectCharacter[gamepadNumber])
            {
                if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_B)))
                {
                    playerSelectCharacter[gamepadNumber] = false;
                    TextFrame.color = Color.black;
                }
                return;
            }

            if (transform.GetChild(0).gameObject.activeSelf)
            {
                if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_A)))
                {
                    audioSource.PlayOneShot(punchVoice);
                    playerSelectCharacter[gamepadNumber] = true;
                    TextFrame.color = Color.red;
                    Debug.Log(string.Format("Player{0}:{1}", gamepadNumber, character));
                    HotateColor.HotateColorDict[gamepadNumber] = characterColor;
                    HotateVoice.HotatePunchVoice[gamepadNumber] = punchVoice;
                    HotateVoice.HotateShootingVoice[gamepadNumber] = shootingVoice;
                }
            }
        }

        void AllSelected()
        {
            for (int i = 1; i <= BattleSetting.NumberOfPlayers; i++)
            {
                if (!playerSelectCharacter[i])
                {
                    return;
                }
            }

            // キャラ選択後すぐに遷移すると、選択された際の音声が切れてしまう対策
            isAllSelected = true;
            Invoke(nameof(ToGameStartRuleScene),1.0f);
        }

        void ToGameStartRuleScene()
        {
            SceneManager.LoadScene("GameStartRuleScene");
        }

        // キャラクター選んでいない状態でBボタンが押された場合、プレイヤー人数セレクトシーンに遷移する。
        void BackScene()
        {
            if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_B)))
            {
                if (!playerSelectCharacter[gamepadNumber])
                {
                    SceneManager.LoadScene("PlayerNumSelectScene");
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
