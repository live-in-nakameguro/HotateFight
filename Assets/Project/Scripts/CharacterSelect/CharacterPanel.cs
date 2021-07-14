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
        // どのプレイヤーがキャラクターを選んだかどうか判断する
        public Dictionary<int,bool> playerSelectCharacter;

        // Start is called before the first frame update
        void Start()
        {
            playerSelectCharacter = new Dictionary<int, bool>()
            {
                { 1,false},
                { 2,false},
                { 3,false},
                { 4,false}
            };
        }

        // Update is called once per frame
        void Update()
        {
            //var isFocus = transform.GetChild(0).gameObject.activeSelf;

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
