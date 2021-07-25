using CharacterSelect.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterSelect.Panel
{
    public class CharacterPanel_HotateBrown : MonoBehaviour
    {
        // このスクリプトをもつコンポーネントのキャラクター
        public static Characters character = Characters.HotateBrown;
        // キャラクターのマテリアル
        public Material material;
        // キャラクターのマテリアル
        public static Color characterColor;
        // どのプレイヤーがキャラクターを選んだかどうか判断する
        public static Dictionary<int, bool> playerSelectCharacter;

        static CharacterPanel_HotateBrown()
        {
            SceneManager.sceneLoaded += Init;
        }

        private static void Init(Scene loadingScene, LoadSceneMode loadSceneMode)
        {
            playerSelectCharacter = new Dictionary<int, bool>()
            {
                { 1,false},
                { 2,false},
                { 3,false},
                { 4,false}
            };
        }

        // Start is called before the first frame update
        void Start()
        {
            characterColor = material.color;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                var moveCharacterSelectPlayer = col.gameObject.GetComponent<MoveCharacterSelectPlayer>();
                playerSelectCharacter[moveCharacterSelectPlayer.gamepadNumber] = true;
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                transform.GetChild(0).gameObject.SetActive(false);
                var moveCharacterSelectPlayer = col.gameObject.GetComponent<MoveCharacterSelectPlayer>();
                playerSelectCharacter[moveCharacterSelectPlayer.gamepadNumber] = false;
            }
        }
    }
}
