using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*�v���R���ݒ�l��`�p�t�@�C��
 * 
 * ����)
 * MAX��MIN�͌v���l�ł��B
 * 
 */
namespace Gamepad.Config {
    public static class GamepadButtonConfig
    {
        //ADJUST FOR STICK LEAN
        public const float FAST_VALUE_FOR_STICK = 2.0f / 3.0f;
        public const float SLOW_VALUE_FOR_STICK = 1.0f / 10.0f;

        //LEFT_STICK
        public const string LEFT_STICK_HORI = "LeftHorizontal";
        public const string LEFT_STICK_VER = "LeftVertical";
        public const float LEFT_STICK_HORI_MAX = 0.7f;
        public const float LEFT_STICK_HORI_MIN = -0.7f;
        public const float LEFT_STICK_VER_MAX = 0.6f;
        public const float LEFT_STICK_VER_MIN = -0.9f;

        //RIGHT_STICK
        public const string RIGHT_STICK_HORI = "RightHorizontal";
        public const string RIGHT_STICK_VER = "RightVertical";
        public const float RIGHT_STICK_HORI_MAX = 0.7f;
        public const float RIGHT_STICK_HORI_MIN = -0.7f;
        public const float RIGHT_STICK_VER_MAX = 0.6f;
        public const float RIGHT_STICK_VER_MIN = -0.9f;

        //DAPD
        public const string DPAD_HORI = "DpadHorizontal";
        public const string DPAD_VER = "DpadVertical";
        public const float DPAD_HORI_MAX = 1.0f;
        public const float DPAD_HORI_MIN = -1.0f;
        public const float DPAD_VER_MAX = 1.0f;
        public const float DPAD_VER_MIN = -1.0f;

        //A, B, X, Y
        public const string BUTTON_A = "joystick button 1";
        public const string BUTTON_B = "joystick button 0";
        public const string BUTTON_X = "joystick button 3";
        public const string BUTTON_Y = "joystick button 2";

        //L, R
        public const string BUTTON_L = "joystick button 4";
        public const string BUTTON_R = "joystick button 5";

        //ZL, ZR
        public const string BUTTON_ZL = "joystick button 6";
        public const string BUTTON_ZR = "joystick button 7";

        //Z3, Z3
        public const string BUTTON_L3 = "joystick button 10";
        public const string BUTTON_R3 = "joystick button 11";

        //OPTIONS
        public const string BUTTON_MINUS = "joystick button 8";
        public const string BUTTON_PULS = "joystick button 9";
        public const string BUTTON_PHOTO = "joystick button 13";
        public const string BUTTON_HOME = "joystick button 12";
    }

    public static class GamepadCameraConfig
    {
        //���������̃J�����X�s�[�h
        public const float HORIZONTAL_CAMERA_SPEED = 3.0f;
        public const float HORIZONTAL_CAMERA_LOW_SPEED = HORIZONTAL_CAMERA_SPEED / 2.0f;

        //���������̃J�����X�s�[�h
        public const float VERTICAL_CAMERA_SPEED = 1.0f;
        public const float VERTICAL_CAMERA_LOW_SPEED = VERTICAL_CAMERA_SPEED / 2.0f;

        //���������̃J������]���E�l
        public const float VERTICAL_CAMERA_ANGLE_MIN_THRESHOLD = 10.0f;
        public const float VERTICAL_CAMERA_ANGLE_MAX_THRESHOLD = 340.0f;
        public const float VERTICAL_CAMERA_MIN_RATIING_ANGLE = VERTICAL_CAMERA_ANGLE_MIN_THRESHOLD - 5.0f;
        public const float VERTICAL_CAMERA_MAX_RATIING_ANGLE = VERTICAL_CAMERA_ANGLE_MAX_THRESHOLD + 5.0f;
    }

    public static class GamepadHotateConfig
    {
        //�ړ����x�̒�`
        public const float WALK_SPPED = 6f;

        //�_�b�V�����x�̒�`
        public const float DASH_SPPED = 9f;

        //�����]�����x�̒�`
        public const float ANGLE_CHAGE_SPPED = 200f;
    }
}