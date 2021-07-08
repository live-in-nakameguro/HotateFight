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

        // �e�I�u�W�F�N�g�̎q���̔ԍ��i�ォ�琔����j
        [SerializeField] int childIndex = 0;

        bool isInvokeAlive = false;

        void Start()
        {
            //Component���擾
            audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                if (!isInvokeAlive) {
                    isInvokeAlive = true;
                    audioSource.PlayOneShot(sound1);
                    // ���̉��o���A�N�e�B�u�ɂ���B
                    transform.GetChild(childIndex).gameObject.SetActive(true);
                    Invoke(nameof(SetActive), 1.0f);
                }
            }
        }

        void SetActive()
        {
            // ���̉��o���A�N�e�B�u�ɂ���B
            transform.GetChild(childIndex).gameObject.SetActive(false);
            isInvokeAlive = false;
        }

        public override void HotateMotion(Rigidbody rb, Transform transform)  //override��t�^
        {
            rb.AddForce(transform.up * 600);
        }
    }
}
