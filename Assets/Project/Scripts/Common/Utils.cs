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

    /* パンチ,ビーム,アイテム利用など
     * ホタテのカメラやホタテ本体の移動以外のアクションを定義する。
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
            /*アイテム利用のボタン定義を実装する。
             */
            return false;
        }
    }

    public class MaterialUtils
    {
        public enum Mode
        {
            Opaque,
            Cutout,
            Fade,
            Transparent,
        }

        // 以下の実装を参考に実装（コピー）
        // [【Unity】標準シェーダーのレンダリングモードをスクリプトから切り替える]
        // https://tyfkda.github.io/blog/2018/08/29/unity-render-mode.html
        // [Standard material shader ignoring SetFloat property "_Mode"?]
        // https://forum.unity.com/threads/standard-material-shader-ignoring-setfloat-property-_mode.344557/#post-2229980
        public static void SetBlendMode(Material material, Mode blendMode)
        {
            material.SetFloat("_Mode", (float)blendMode);

            switch (blendMode)
            {
                case Mode.Opaque:
                    material.SetOverrideTag("RenderType", "");
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt("_ZWrite", 1);
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = -1;
                    break;
                case Mode.Cutout:
                    material.SetOverrideTag("RenderType", "TransparentCutout");
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt("_ZWrite", 1);
                    material.EnableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = 2450;
                    break;
                case Mode.Fade:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.EnableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = 3000;
                    break;
                case Mode.Transparent:
                    material.SetOverrideTag("RenderType", "Transparent");
                    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt("_ZWrite", 0);
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = 3000;
                    break;
            }
        }
    }
}