using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hotate.Damage
{
    public class DamagedByExplosion : Damage
    {
        // SE
        [SerializeField] AudioClip sound1;
        AudioSource audioSource;

        // 親オブジェクトの子供の番号（上から数える）
        [SerializeField] int childIndex = 0;

        // 子オブジェクトを表示する時間
        [SerializeField] float activeTime = 1.0f;

        void Start()
        {
            //Componentを取得
            audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision col)
        {
            ExplosionTriger(col);
        }

        /// <summary>
        /// 爆発の演出を表示するかを判断する
        /// </summary>
        /// <param name="col">ホタテに接触したCollision</param>
        void ExplosionTriger(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                ExplosionEffect(col);
            }
        }

        /// <summary>
        /// 爆発の演出を表示する。
        /// </summary>
        /// <param name="col">ホタテに接触したCollision</param>
        void ExplosionEffect(Collision col)
        {
            audioSource.PlayOneShot(sound1);
            StartChildActive();
        }

        /// <summary>
        /// 子オブジェクトを一定時間表示する。
        /// </summary>
        void StartChildActive()
        {
            // 炎の演出を表示する。
            transform.GetChild(childIndex).gameObject.SetActive(true);
            Invoke(nameof(EndChildActive), activeTime);
        }

        /// <summary>
        /// 子オブジェクトを非表示にする。（Invokeで使用）
        /// </summary>
        void EndChildActive()
        {
            // 炎の演出を非表示にする。
            transform.GetChild(childIndex).gameObject.SetActive(false);
        }

        public override void HotateMotion(Rigidbody rb, Transform transform)  //overrideを付与
        {
            rb.AddForce(transform.up * 600);
        }
    }
}
