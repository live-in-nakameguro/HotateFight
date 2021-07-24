using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

public class HotatePunch : MonoBehaviour
{
    // SE
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    [SerializeField] GameObject hotate_arm;

    //ToDo ‚Ç‚±‚©‚Å‚Ü‚Æ‚ß‚½‚¢
    [SerializeField] int gamepadNumber = 0;

    private float punch_speed = 2.0f;

    private bool punch_execute_flg = false;
    private bool punch_down_end_flg = false;

    private int frame_count = 0;

    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Execute();
        if (punch_execute_flg)
        {
            PunchDown();
            PunchUp();
        }
    }

    void Execute()
    {
        if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_A)) & punch_execute_flg == false)
        {
            punch_execute_flg = true;
            hotate_arm.SetActive(true);
        }
    }

    void PunchDown()
    {
        if (punch_down_end_flg == false)
        {
            hotate_arm.transform.Rotate(-punch_speed, 0.0f, 0.0f);
            frame_count += 1;
            if (frame_count >= 25)
            {
                PunchVoiceEffect();
                punch_down_end_flg = true;
                frame_count = 0;
            }
        }
    }

    void PunchUp()
    {
        if(punch_down_end_flg == true)
        {
            hotate_arm.transform.Rotate(punch_speed, 0.0f, 0.0f);
            frame_count += 1;
            if (frame_count >= 25)
            {
                punch_down_end_flg = false;
                punch_execute_flg = false;
                hotate_arm.SetActive(false);
                frame_count = 0;
            }
        }
    }

    void PunchVoiceEffect()
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