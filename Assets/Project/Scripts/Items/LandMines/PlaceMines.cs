using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class PlaceMines : MonoBehaviour
    {
        public static void Place(GameObject hotate, GameObject mine, Transform muzzle)
        {
            // AudioSource��static�łȂ����߁A���������ŏo�����Ƃ��ł��Ȃ��B

            // ���e�̕���
            GameObject bombs = Instantiate(mine, muzzle.position + muzzle.transform.forward * 5, muzzle.rotation) as GameObject;
        }
    }
}
