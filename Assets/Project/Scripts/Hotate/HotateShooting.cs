using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotate.Shooting
{
    public class HotateShooting : MonoBehaviour
    {
        // SE
        [SerializeField] AudioClip shootingVoice;
        AudioSource audioSource;

        //ToDo どこかでまとめたい
        [SerializeField] int gamepadNumber = 0;

        // bullet prefab
        [SerializeField] GameObject bullet;

        // 弾丸発射点
        [SerializeField] Transform muzzle;

        // 弾丸の速度
        public float speed = 1000;

        // 発射可能な弾丸の最大数
        private const int MAX_BULLET_NUM = 3;
        // 発射可能な弾丸の最小数
        private const int MIN_BULLET_NUM = 0;

        // 発射可能な弾丸の数
        private int bulletNum = 3;

        public float reloadTime = 2.0f;

        // Use this for initialization
        void Start()
        {
            //Componentを取得
            audioSource = GetComponent<AudioSource>();
            if (HotateVoice.HotateShootingVoice[gamepadNumber] != null)
            {
                shootingVoice = HotateVoice.HotateShootingVoice[gamepadNumber];
            }
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

            // z キーが押された時
            if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_X)))
            {
                ShootingVoiceEffect();

                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force = this.gameObject.transform.forward * -speed;

                // Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // 弾丸の位置を調整
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
