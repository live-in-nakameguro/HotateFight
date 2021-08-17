using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

namespace Common.Utils
{
    public class HotateMovingUtils
    {
        public static bool isPressedDashUpMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER, gamepadNumber)) <= (GamepadButtonConfig.LEFT_STICK_VER_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                return true;

            return false;
        }

        public static bool isPressedDashDownMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
                return true;

            return false;
        }

        public static bool isPressedUpMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER, gamepadNumber)) <= (GamepadButtonConfig.LEFT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.W))
                return true;

            return false;
        }

        public static bool isPressedDownMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.S))
                return true;

            return false;
        }

        public static bool isPressedRightMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI, gamepadNumber)) >= (GamepadButtonConfig.LEFT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.D))
                return true;

            return false;
        }

        public static bool isPressedLeftMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI, gamepadNumber)) <= (GamepadButtonConfig.LEFT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.A))
                return true;

            return false;
        }

        public static bool isPressedJump(int gamepadNumber)
        {
            if (Input.GetKeyDown(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.BUTTON_B, gamepadNumber)))
                return true;

            if (gamepadNumber == 1 && Input.GetKeyDown(KeyCode.Space))
                return true;

            return false;
        }

    }

    public class HotateCameraUtils
    {
        public static bool isPressedCameraRightSpeedy(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_HORI, gamepadNumber)) <= (GamepadButtonConfig.RIGHT_STICK_HORI_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.J))
                return true;

            return false;
        }

        public static bool isPressedCameraLeftSpeedy(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_HORI, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.L))
                return true;

            return false;
        }

        public static bool isPressedCameraRight(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_HORI, gamepadNumber)) <= (GamepadButtonConfig.RIGHT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.J))
                return true;

            return false;
        }

        public static bool isPressedCameraLeft(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_HORI, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.L))
                return true;

            return false;
        }

        public static bool isPressedCameraReset(int gamepadNumber)
        {
            if (Input.GetKeyDown(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.BUTTON_R3, gamepadNumber)))
                return true;

            if (Input.GetKey(KeyCode.L) & Input.GetKey(KeyCode.J))
                return true;

            return false;
        }

        public static bool isPressedCameraUpSpeedy(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.I))
                return true;

            return false;
        }

        public static bool isPressedCameraDownSpeedy(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.K))
                return true;

            return false;
        }

        public static bool isPressedCameraUp(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.I))
                return true;

            return false;
        }

        public static bool isPressedCameraDown(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (gamepadNumber == 1 && Input.GetKey(KeyCode.K))
                return true;

            return false;
        }
    }

    /* �p���`,�r�[��,�A�C�e�����p�Ȃ�
     * �z�^�e�̃J������z�^�e�{�̂̈ړ��ȊO�̃A�N�V�������`����B
     */
    public class HotateActionsUtils
    {
        public static bool isPressedShooting(int gamepadNumber)
        {
            if ((Input.GetKeyDown(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.BUTTON_X, gamepadNumber))) || (gamepadNumber == 1 && Input.GetKeyDown(KeyCode.Y)))
                return true;

            return false;
        }

        public static bool isPressedPunch(int gamepadNumber)
        {
            if (Input.GetKeyDown(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.BUTTON_A, gamepadNumber)) || (gamepadNumber == 1 && Input.GetKeyDown(KeyCode.U)))
                return true;

            return false;
        }

        public static bool isPressedUsingItems(int gamepadNumber)
        {
            /*�A�C�e�����p�̃{�^����`����������B
             */
            return false;
        }
    }
}