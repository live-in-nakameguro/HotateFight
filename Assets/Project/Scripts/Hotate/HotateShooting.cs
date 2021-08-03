using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotate.Shooting
{
    public class HotateShooting : MonoBehaviour
    {
        // SE
        [SerializeField] AudioClip sound1;
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
        }

        // Update is called once per frame
        void Update()
        {
            Shooting();
        }

        void Shooting()
        {
            if (bulletNum <= MIN_BULLET_NUM)
            {
                return;
            }

            // z �L�[�������ꂽ��
            if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_X)))
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
            audioSource.PlayOneShot(sound1);
        }

        void ReloadBullet()
        {
            bulletNum += 1;
        }

        string SetGamepadNumber(string gamepadKey)
        {
            string gamepadNumberStr = "";
            if (gamepadNumber != 0)
            {
                gamepadNumberStr = $" {gamepadNumber}";
            }
            return string.Format(gamepadKey, gamepadNumberStr);
        }

    }
}
