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

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedDashDownMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedUpMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER, gamepadNumber)) <= (GamepadButtonConfig.LEFT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.W) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedDownMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.S) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedRightMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI, gamepadNumber)) >= (GamepadButtonConfig.LEFT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.D) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedLeftMoving(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI, gamepadNumber)) <= (GamepadButtonConfig.LEFT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.A) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedJump(int gamepadNumber)
        {
            if (Input.GetKeyDown(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.BUTTON_B, gamepadNumber)))
                return true;

            if (Input.GetKeyDown(KeyCode.Space) && gamepadNumber == 1)
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

            if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.LeftShift) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedCameraLeftSpeedy(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_HORI, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.LeftShift) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedCameraRight(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_HORI, gamepadNumber)) <= (GamepadButtonConfig.RIGHT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.L) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedCameraLeft(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_HORI, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.J) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedCameraReset(int gamepadNumber)
        {
            if (Input.GetKeyDown(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.BUTTON_R3, gamepadNumber)))
                return true;

            if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.J))
                return true;

            return false;
        }

        public static bool isPressedCameraUpSpeedy(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.LeftShift) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedCameraDownSpeedy(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.LeftShift) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedCameraUp(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.I) && gamepadNumber == 1)
                return true;

            return false;
        }

        public static bool isPressedCameraDown(int gamepadNumber)
        {
            if (Input.GetAxis(GamepadButtonConfig.SetGamepadNumber(GamepadButtonConfig.RIGHT_STICK_VER, gamepadNumber)) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
                return true;

            if (Input.GetKey(KeyCode.K) && gamepadNumber == 1)
                return true;

            return false;
        }

    }
}