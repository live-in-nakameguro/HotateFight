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

        // ItemBox�����蔲����悤�ɂ��邽�߂ɁAItemBox��IsTrigger�Ƀ`�F�b�N��t�^
        // �d�˂��Ă���ItemBox���擾���邽�߂ɁAOnTriggerStay���g�p
        void OnTriggerStay(Collider other)
        {
            HitPlayer(other);
        }

        void HitPlayer(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                int gamepadNumber = GetGamepadNumber(other);
                // �A�C�e���������Ă����ԂŁA�A�C�e�����擾�ł��Ȃ��悤�ɂ��邽�߂̑Ή�
                if (PlayerItem.playerItemDict[gamepadNumber] != ItemSetting.Items.None)
                {
                    return;
                }
                PlayerItem.playerItemDict[gamepadNumber] = RondomItem();
                Destroy(itemBox);
            }
        }

        // �ڐG�����v���C���[����P���𔻒f��������B
        // ���܂ł̎������������߁A���̂悤�ɑΉ��B
        // GetComponent�͏d�������̂��߁A�ꍇ�ɂ���Ă͍��܂ł̎��������ς���B
        int GetGamepadNumber(Collider other)
        {
            HotateLife1 hotateLife1;
            HotateLife2 hotateLife2;
            HotateLife3 hotateLife3;
            HotateLife4 hotateLife4;

            if (other.gameObject.TryGetComponent(out hotateLife1))
            {
                return 1;
            }
            if (other.gameObject.TryGetComponent(out hotateLife2))
            {
                return 2;
            }
            if (other.gameObject.TryGetComponent(out hotateLife3))
            {
                return 3;
            }
            if (other.gameObject.TryGetComponent(out hotateLife4))
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
