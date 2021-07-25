using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

public class HotateLaser : MonoBehaviour
{
    // SE
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    [SerializeField] GameObject HotateLaserObject;

    //ToDo ‚Ç‚±‚©‚Å‚Ü‚Æ‚ß‚½‚¢
    [SerializeField] int gamepadNumber = 0;

    private bool isLaserExecute = false;

    void Start()
    {
        //Component‚ðŽæ“¾
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