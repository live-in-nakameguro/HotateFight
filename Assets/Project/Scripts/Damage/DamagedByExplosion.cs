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

        // �q�I�u�W�F�N�g��\�����鎞��
        [SerializeField] float activeTime = 1.0f;

        void Start()
        {
            //Component���擾
            audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision col)
        {
            ExplosionTriger(col);
        }

        /// <summary>
        /// �����̉��o��\�����邩�𔻒f����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void ExplosionTriger(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                ExplosionEffect(col);
            }
        }

        /// <summary>
        /// �����̉��o��\������B
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void ExplosionEffect(Collision col)
        {
            audioSource.PlayOneShot(sound1);
            StartChildActive();
        }

        /// <summary>
        /// �q�I�u�W�F�N�g����莞�ԕ\������B
        /// </summary>
        void StartChildActive()
        {
            // ���̉��o��\������B
            transform.GetChild(childIndex).gameObject.SetActive(true);
            Invoke(nameof(EndChildActive), activeTime);
        }

        /// <summary>
        /// �q�I�u�W�F�N�g���\���ɂ���B�iInvoke�Ŏg�p�j
        /// </summary>
        void EndChildActive()
        {
            // ���̉��o���\���ɂ���B
            transform.GetChild(childIndex).gameObject.SetActive(false);
        }

        public override void HotateMotion(Rigidbody rb, Transform transform)  //override��t�^
        {
            rb.AddForce(transform.up * 600);
        }
    }
}
