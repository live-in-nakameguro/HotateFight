using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotate.Damage
{
    // 未使用
    public enum DamageTypes
    {   
        // 未選択時の設定
        NoType,
        // テストで作成した爆発
        Explosion,
        // テストで作成したダメージ床
        Floor
    }

    public class Damage : MonoBehaviour
    {
        // ダメージ値
        public float damageNum = 20.0f;

        // ダメージを受けた後の無敵時間（秒）
        public float invincibleTime = 3.0f;

        // 未使用
        // オブジェクトの種類
        public DamageTypes damageType = DamageTypes.NoType;

        /// <summary>
        /// ダメージを受けた際のホタテの挙動
        /// </summary>
        /// <param name="rb">ホタテのRigidbody</param>
        /// <param name="transform">ホタテのTransform</param>
        public virtual void HotateMotion(Rigidbody rb, Transform transform)  //virtualを付与
        {
            Debug.Log("モーション設定なし");
        }
    }
}
