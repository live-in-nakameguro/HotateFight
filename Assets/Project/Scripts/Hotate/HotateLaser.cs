using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

public class HotateLaser : MonoBehaviour
{
    // SE
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    [SerializeField] GameObject HotateLaserObject;

    //ToDo どこかでまとめたい
    [SerializeField] int gamepadNumber = 0;

    //レーザースピード
    [SerializeField] float laserSpead = 0.1f;

    private bool isLaserExecute = false;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Execute();
    }

    void Execute()
    {
        if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_X)) & isLaserExecute == false)
        {
            isLaserExecute = true;
            HotateLaserObject.SetActive(true);
            LaserVoiceEffect();
        }

        if (isLaserExecute)
        {
            LaserMove();
        }
    }

    void LaserVoiceEffect()
    {
        audioSource.PlayOneShot(sound1);
    }

    void LaserMove()
    {
        HotateLaserObject.transform.position += transform.forward * -laserSpead * Time.deltaTime;
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