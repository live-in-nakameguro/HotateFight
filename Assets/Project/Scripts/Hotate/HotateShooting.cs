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

        //ToDo Ç«Ç±Ç©Ç≈Ç‹Ç∆ÇﬂÇΩÇ¢
        [SerializeField] int gamepadNumber = 0;

        // bullet prefab
        [SerializeField] GameObject bullet;

        // íeä€î≠éÀì_
        [SerializeField] Transform muzzle;

        // íeä€ÇÃë¨ìx
        public float speed = 1000;

        // î≠éÀâ¬î\Ç»íeä€ÇÃç≈ëÂêî
        private const int MAX_BULLET_NUM = 3;
        // î≠éÀâ¬î\Ç»íeä€ÇÃç≈è¨êî
        private const int MIN_BULLET_NUM = 0;

        // î≠éÀâ¬î\Ç»íeä€ÇÃêî
        private int bulletNum = 3;

        public float reloadTime = 2.0f;

        // Use this for initialization
        void Start()
        {
            //ComponentÇéÊìæ
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

            // z ÉLÅ[Ç™âüÇ≥ÇÍÇΩéû
            if ((Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_X))) || (gamepadNumber == 1 & Input.GetKeyDown(KeyCode.Y)))
            {
                ShootingVoiceEffect();

                // íeä€ÇÃï°êª
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force = this.gameObject.transform.forward * -speed;

                // RigidbodyÇ…óÕÇâ¡Ç¶Çƒî≠éÀ
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // íeä€ÇÃà íuÇí≤êÆ
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
