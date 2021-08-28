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

        //ToDo ‚Ç‚±‚©‚Å‚Ü‚Æ‚ß‚½‚¢
        [SerializeField] int gamepadNumber = 0;

        // bullet prefab
        [SerializeField] GameObject bullet;

        // ’eŠÛ”­Ë“_
        [SerializeField] Transform muzzle;

        // ’eŠÛ‚Ì‘¬“x
        public float speed = 1000;

        // ”­Ë‰Â”\‚È’eŠÛ‚ÌÅ‘å”
        private const int MAX_BULLET_NUM = 3;
        // ”­Ë‰Â”\‚È’eŠÛ‚ÌÅ¬”
        private const int MIN_BULLET_NUM = 0;

        // ”­Ë‰Â”\‚È’eŠÛ‚Ì”
        private int bulletNum = 3;

        public float reloadTime = 2.0f;

        // Use this for initialization
        void Start()
        {
            //Component‚ğæ“¾
            audioSource = GetComponent<AudioSource>();
            if (HotateVoice.HotateShootingVoice[gamepadNumber] != null)
            {
                shootingVoice = HotateVoice.HotateShootingVoice[gamepadNumber];
            }
        }

        // Update is called once per frame
        void Update()
        {
            //©•ª‚Ì‘€ì‚ª‘¼‚Ìƒ†[ƒU‚Ì‘€ì‚É‰e‹¿‚ğ—^‚¦‚È‚¢‚æ‚¤‚É‚·‚é
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

            // z ƒL[‚ª‰Ÿ‚³‚ê‚½
            if (HotateActionsUtils.isPressedShooting(gamepadNumber))
            {
                ShootingVoiceEffect();

                // ’eŠÛ‚Ì•¡»
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force = this.gameObject.transform.forward * -speed;

                // Rigidbody‚É—Í‚ğ‰Á‚¦‚Ä”­Ë
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // ’eŠÛ‚ÌˆÊ’u‚ğ’²®
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
