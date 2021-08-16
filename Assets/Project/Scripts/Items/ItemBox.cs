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

        // �ڐG�����v���C���[����P���𔻒f��������B
        // ���܂ł̎������������߁A���̂悤�ɑΉ��B
        // GetComponent�͏d�������̂��߁A�ꍇ�ɂ���Ă͍��܂ł̎��������ς���B
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

            //�ʂ�Ȃ� 
            return 0;
        }

        ItemSetting.Items RondomItem()
        {
            var randomItemList = new List<ItemSetting.Items>();
            // �����_���X�C�b�`��ON�̃A�C�e���𒊏o����B
            foreach (var pair in ItemSetting.RandomItemSettingDic)
            {
                if (pair.Value)
                {
                    randomItemList.Add(pair.Key);
                }
            }

            //�����_���ɃA�C�e����I��
            var item = randomItemList[UnityEngine.Random.Range(0, randomItemList.Count)];
            Debug.Log(item);
            return item;
        }
    }
}
