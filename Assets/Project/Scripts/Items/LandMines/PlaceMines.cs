using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class PlaceMines : MonoBehaviour
    {
        public static void Place(GameObject hotate, GameObject mine, Transform muzzle)
        {
            // AudioSourceがstaticでないため、音をここで出すことができない。

            // 爆弾の複製
            GameObject bombs = Instantiate(mine, muzzle.position + muzzle.transform.forward * 5, muzzle.rotation) as GameObject;
        }
    }
}
