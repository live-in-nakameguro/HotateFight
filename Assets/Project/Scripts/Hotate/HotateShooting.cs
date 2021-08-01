using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateShooting : MonoBehaviour
{
    // SE
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    //ToDo ‚Ç‚±‚©‚Å‚Ü‚Æ‚ß‚½‚¢
    [SerializeField] int gamepadNumber = 0;

    // bullet prefab
    public GameObject bullet;

    // ’eŠÛ”­Ë“_
    public Transform muzzle;

    // ’eŠÛ‚Ì‘¬“x
    public float speed = 1000;

    // Use this for initialization
    void Start()
    {
        //Component‚ğæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    void Execute()
    {
        // z ƒL[‚ª‰Ÿ‚³‚ê‚½
        if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_X)))
        {
            LaserVoiceEffect();

            // ’eŠÛ‚Ì•¡»
            GameObject bullets = Instantiate(bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * -speed;

            // Rigidbody‚É—Í‚ğ‰Á‚¦‚Ä”­Ë
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // ’eŠÛ‚ÌˆÊ’u‚ğ’²®
            bullets.transform.position = muzzle.position;
        }
    }

    void LaserVoiceEffect()
    {
        audioSource.PlayOneShot(sound1);
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
