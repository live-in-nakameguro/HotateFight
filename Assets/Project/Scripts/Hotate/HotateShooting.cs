using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateShooting : MonoBehaviour
{
    // SE
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    //ToDo どこかでまとめたい
    [SerializeField] int gamepadNumber = 0;

    // bullet prefab
    public GameObject bullet;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public float speed = 1000;

    // Use this for initialization
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    void Execute()
    {
        // z キーが押された時
        if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_X)))
        {
            LaserVoiceEffect();

            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * -speed;

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整
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
