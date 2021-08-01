using Gamepad.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateShooting : MonoBehaviour
{
    // SE
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    //ToDo �ǂ����ł܂Ƃ߂���
    [SerializeField] int gamepadNumber = 0;

    // bullet prefab
    public GameObject bullet;

    // �e�۔��˓_
    public Transform muzzle;

    // �e�ۂ̑��x
    public float speed = 1000;

    // Use this for initialization
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    void Execute()
    {
        // z �L�[�������ꂽ��
        if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_X)))
        {
            LaserVoiceEffect();

            // �e�ۂ̕���
            GameObject bullets = Instantiate(bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * -speed;

            // Rigidbody�ɗ͂������Ĕ���
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // �e�ۂ̈ʒu�𒲐�
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
