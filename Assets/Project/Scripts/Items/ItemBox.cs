using GameScenes.SettingAndResultBattle;
using Hotate.Life;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Item
{
    public class ItemBox : MonoBehaviour
    {
        //itemBox prefab
        [SerializeField] GameObject itemBox;

        private void Start()
        {

        }

        void OnCollisionEnter(Collision col)
        {
            HitPlayer(col);
        }

        void HitPlayer(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                int gamepadNumber = GetGamepadNumber(col);
                PlayerItem.playerItemDict[gamepadNumber] = RondomItem();
                Destroy(itemBox);
            }
        }

        // 接触したプレイヤーが何Pかを判断する実装。
        // 今までの実装が悪いため、このように対応。
        // GetComponentは重い処理のため、場合によっては今までの実装を改変する。
        int GetGamepadNumber(Collision col)
        {
            HotateLife1 hotateLife1;
            HotateLife2 hotateLife2;
            HotateLife3 hotateLife3;
            HotateLife4 hotateLife4;

            if (col.gameObject.TryGetComponent(out hotateLife1))
            {
                return 1;
            }
            if (col.gameObject.TryGetComponent(out hotateLife2))
            {
                return 2;
            }
            if (col.gameObject.TryGetComponent(out hotateLife3))
            {
                return 3;
            }
            if (col.gameObject.TryGetComponent(out hotateLife4))
            {
                return 4;
            }

            //通らない 
            return 0;
        }

        ItemSetting.Items RondomItem()
        {
            var randomItemList = new List<ItemSetting.Items>();
            // ランダムスイッチがONのアイテムを抽出する。
            foreach (var pair in ItemSetting.RandomItemSettingDic)
            {
                if (pair.Value)
                {
                    randomItemList.Add(pair.Key);
                }
            }

            //ランダムにアイテムを選択
            var item = randomItemList[UnityEngine.Random.Range(0, randomItemList.Count)];
            Debug.Log(item);
            return item;
        }
    }
}
