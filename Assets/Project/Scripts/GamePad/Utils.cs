using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

namespace Gamepad.Utils
{
    public class HotateGamepadUtils : MonoBehaviour
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
}