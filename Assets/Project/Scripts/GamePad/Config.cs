using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プロコン設定値定義用ファイル
 * 
 * 注意)
 * MAXやMINは計測値です。
 * 
 */
namespace Gamepad.Config {
    public static class GamepadButtonConfig
    {
        //ADJUST FOR STICK LEAN
        public const float FAST_VALUE_FOR_STICK = 2.0f / 3.0f;
        public const float SLOW_VALUE_FOR_STICK = 1.0f / 10.0f;

        //LEFT_STICK
        public const string LEFT_STICK_HORI = "LeftHorizontal{0}";
        public const string LEFT_STICK_VER = "LeftVertical{0}";
        public const float LEFT_STICK_HORI_MAX = 0.7f;
        public const float LEFT_STICK_HORI_MIN = -0.7f;
        public const float LEFT_STICK_VER_MAX = 0.6f;
        public const float LEFT_STICK_VER_MIN = -0.9f;

        //RIGHT_STICK
        public const string RIGHT_STICK_HORI = "RightHorizontal{0}";
        public const string RIGHT_STICK_VER = "RightVertical{0}";
        public const float RIGHT_STICK_HORI_MAX = 0.7f;
        public const float RIGHT_STICK_HORI_MIN = -0.7f;
        public const float RIGHT_STICK_VER_MAX = 0.6f;
        public const float RIGHT_STICK_VER_MIN = -0.9f;

        //DAPD
        public const string DPAD_HORI = "DpadHorizontal{0}";
        public const string DPAD_VER = "DpadVertical{0}";
        public const float DPAD_HORI_MAX = 1.0f;
        public const float DPAD_HORI_MIN = -1.0f;
        public const float DPAD_VER_MAX = 1.0f;
        public const float DPAD_VER_MIN = -1.0f;

        //A, B, X, Y
        public const string BUTTON_A = "joystick{0} button 1";
        public const string BUTTON_B = "joystick{0} button 0";
        public const string BUTTON_X = "joystick{0} button 3";
        public const string BUTTON_Y = "joystick{0} button 2";

        //L, R
        public const string BUTTON_L = "joystick{0} button 4";
        public const string BUTTON_R = "joystick{0} button 5";

        //ZL, ZR
        public const string BUTTON_ZL = "joystick{0} button 6";
        public const string BUTTON_ZR = "joystick{0} button 7";

        //Z3, Z3
        public const string BUTTON_L3 = "joystick{0} button 10";
        public const string BUTTON_R3 = "joystick{0} button 11";

        //OPTIONS
        public const string BUTTON_MINUS = "joystick{0} button 8";
        public const string BUTTON_PULS = "joystick{0} button 9";
        public const string BUTTON_PHOTO = "joystick{0} button 13";
        public const string BUTTON_HOME = "joystick{0} button 12";

        public static string SetGamepadNumber(string gamepadKey, int gamepadNumber)
        {
            string gamepadNumberStr = "";
            if (gamepadNumber != 0)
            {
                gamepadNumberStr = $" {gamepadNumber}";
            }
            return string.Format(gamepadKey, gamepadNumberStr);
        }
    }

    public static class GamepadCameraConfig
    {
        //水平方向のカメラスピード
        public const float HORIZONTAL_CAMERA_SPEED = 2.0f;
        public const float HORIZONTAL_CAMERA_LOW_SPEED = HORIZONTAL_CAMERA_SPEED / 2.0f;

        //垂直方向のカメラスピード
        public const float VERTICAL_CAMERA_SPEED = 1.0f;
        public const float VERTICAL_CAMERA_LOW_SPEED = VERTICAL_CAMERA_SPEED / 2.0f;

        //垂直方向のカメラ回転限界値
        public const float VERTICAL_CAMERA_ANGLE_MIN_THRESHOLD = 10.0f;
        public const float VERTICAL_CAMERA_ANGLE_MAX_THRESHOLD = 340.0f;
        public const float VERTICAL_CAMERA_MIN_RATIING_ANGLE = VERTICAL_CAMERA_ANGLE_MIN_THRESHOLD - 5.0f;
        public const float VERTICAL_CAMERA_MAX_RATIING_ANGLE = VERTICAL_CAMERA_ANGLE_MAX_THRESHOLD + 5.0f;
    }

    public static class GamepadHotateConfig
    {
        //移動速度の定義
        public const float WALK_SPPED = 6f;

        //ダッシュ速度の定義
        public const float DASH_SPPED = 9f;

        //方向転換速度の定義
        public const float ANGLE_CHAGE_SPPED = 200f;
    }
}
