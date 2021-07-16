using CharacterSelect.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelect.Panel
{
    public enum Characters
    {
        // 未選択時の設定
        NoSelect,
        // ホタテ（ブラン）
        HotateBrown,
        // ホタテ（ブルー）
        HotateBlue,
        // ホタテ（イエロー）
        HotateYellow
    }

    public class CharacterPanel : MonoBehaviour
    {
        // このスクリプトをもつコンポーネントのキャラクター
        public Characters character = Characters.NoSelect;
        // このスクリプトをもつコンポーネントのキャラクター
        public static Characters characterName;

        // キャラクターのマテリアル
        public Material material;
        // キャラクターのマテリアル
        public static Color characterColor;

        // どのプレイヤーがキャラクターを選んだかどうか判断する
        public static Dictionary<int,bool> playerSelectCharacter = new Dictionary<int, bool>()
            {
                { 1,false},
                { 2,false},
                { 3,false},
                { 4,false}
            };

        // Start is called before the first frame update
        void Start()
        {
            characterName = character;
            characterColor = material.color;
            Debug.Log(string.Format("characterName:{0},characterColor:{1}", characterName, characterColor));
        }

        // Update is called once per frame
        void Update()
        {
            //var isFocus = transform.GetChild(0).gameObject.activeSelf;
            Debug.Log(string.Format("characterName:{0},characterColor:{1}", characterName, characterColor));
        }

        void OnTriggerStay2D(Collider2D col)
        {
            Debug.Log("OnTriggerStay2D");
            if (col.gameObject.tag == "Player")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                var moveCharacterSelectPlayer = col.gameObject.GetComponent<MoveCharacterSelectPlayer>();
                playerSelectCharacter[moveCharacterSelectPlayer.gamepadNumber] = true;
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("OnTriggerExit2D:");
            if (col.gameObject.tag == "Player")
            {
                transform.GetChild(0).gameObject.SetActive(false);
                var moveCharacterSelectPlayer = col.gameObject.GetComponent<MoveCharacterSelectPlayer>();
                playerSelectCharacter[moveCharacterSelectPlayer.gamepadNumber] = false;
            }
        }
    }
}
