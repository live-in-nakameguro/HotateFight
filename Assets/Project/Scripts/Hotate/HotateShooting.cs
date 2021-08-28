using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Utils;
using Photon.Pun;

namespace Hotate.Shooting
{
    public class HotateShooting : MonoBehaviourPunCallbacks
    {
        // SE
        [SerializeField] AudioClip shootingVoice;
        AudioSource audioSource;

        //ToDo �ǂ����ł܂Ƃ߂���
        [SerializeField] int gamepadNumber = 0;

        // bullet prefab
        [SerializeField] GameObject bullet;

        // �e�۔��˓_
        [SerializeField] Transform muzzle;

        // �e�ۂ̑��x
        public float speed = 1000;

        // ���ˉ\�Ȓe�ۂ̍ő吔
        private const int MAX_BULLET_NUM = 3;
        // ���ˉ\�Ȓe�ۂ̍ŏ���
        private const int MIN_BULLET_NUM = 0;

        // ���ˉ\�Ȓe�ۂ̐�
        private int bulletNum = 3;

        public float reloadTime = 2.0f;

        // Use this for initialization
        void Start()
        {
            //Component���擾
            audioSource = GetComponent<AudioSource>();
            if (HotateVoice.HotateShootingVoice[gamepadNumber] != null)
            {
                shootingVoice = HotateVoice.HotateShootingVoice[gamepadNumber];
            }
        }

        // Update is called once per frame
        void Update()
        {
            //�����̑��삪���̃��[�U�̑���ɉe����^���Ȃ��悤�ɂ���
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
                return;

            Shooting();
        }

        void Shooting()
        {
            if (bulletNum <= MIN_BULLET_NUM)
            {
                return;
            }

            // z �L�[�������ꂽ��
            if (HotateActionsUtils.isPressedShooting(gamepadNumber))
            {
                ShootingVoiceEffect();

                // �e�ۂ̕���
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force = this.gameObject.transform.forward * -speed;

                // Rigidbody�ɗ͂������Ĕ���
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // �e�ۂ̈ʒu�𒲐�
                bullets.transform.position = muzzle.position;

                bulletNum -= 1;
                Invoke(nameof(ReloadBullet), reloadTime);
            }
        }

        void ShootingVoiceEffect()
        {
            audioSource.PlayOneShot(shootingVoice);
        }

        void ReloadBullet()
        {
            bulletNum += 1;
        }

    }
}
