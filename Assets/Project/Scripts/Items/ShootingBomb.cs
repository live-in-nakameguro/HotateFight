using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ShootingBomb : MonoBehaviour
    {
        public static void Shooting(GameObject hotate, GameObject bomb, Transform muzzle)
        {
            // AudioSourceがstaticでないため、音をここで出すことができない。

            // 爆弾の速度
            float speed = 10;

            // 爆弾の複製
            GameObject bombs = Instantiate(bomb, muzzle.position + new Vector3(0, 1, 0), muzzle.rotation) as GameObject;

            // 正面方向に発射する
            var force = muzzle.transform.forward * -speed;

            // 斜方投射する
            force += new Vector3(0,10,0);

            // 爆弾オブジェクトのRigidbodyコンポーネントへの参照を取得
            Rigidbody rb = bombs.GetComponent<Rigidbody>();

            // 力を加えるメソッド
            // ForceMode.Impulseは撃力
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
