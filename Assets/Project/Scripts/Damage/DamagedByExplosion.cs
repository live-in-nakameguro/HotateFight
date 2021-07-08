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

        bool isInvokeAlive = false;

        void Start()
        {
            //Componentを取得
            audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                if (!isInvokeAlive) {
                    isInvokeAlive = true;
                    audioSource.PlayOneShot(sound1);
                    // 炎の演出をアクティブにする。
                    transform.GetChild(childIndex).gameObject.SetActive(true);
                    Invoke(nameof(SetActive), 1.0f);
                }
            }
        }

        void SetActive()
        {
            // 炎の演出をアクティブにする。
            transform.GetChild(childIndex).gameObject.SetActive(false);
            isInvokeAlive = false;
        }

        public override void HotateMotion(Rigidbody rb, Transform transform)  //overrideを付与
        {
            rb.AddForce(transform.up * 600);
        }
    }
}
