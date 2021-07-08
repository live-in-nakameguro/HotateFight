using UnityEngine;
using System;
using Gamepad.Config;

public class CameraGamePadMove: MonoBehaviour
{

    [SerializeField] Transform horizontalRotNode;
    [SerializeField] Transform verticalRotNode;
    [SerializeField] Transform dollyNode;

    void Update()
    {
        HorizontalMotion();
        VerticalMotion();
        //�Y�[���p�̊֐�:�R�����g�A�E�g���R�̓��\�b�h��`���Q��
        //Zoom();
    }

    // ���������̉�]
    private void HorizontalMotion()
    {
        float horizontalAngle = horizontalRotNode.localRotation.eulerAngles.y;

        if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) <= (GamepadButtonConfig.RIGHT_STICK_HORI_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) <= (GamepadButtonConfig.RIGHT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));
        
        else if (Input.GetKeyDown(GamepadButtonConfig.BUTTON_R3))
            //�J�������Z�b�g
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    //�㉺�̉�]
    private void VerticalMotion()
    {
        float verticalAngle = verticalRotNode.rotation.eulerAngles.x;
        bool is_ratting = verticalAngle <= GamepadCameraConfig.VERTICAL_CAMERA_ANGLE_MIN_THRESHOLD || verticalAngle >= GamepadCameraConfig.VERTICAL_CAMERA_ANGLE_MAX_THRESHOLD;

        void UpOrDown(float speed, bool is_up)
        {
            float angele;

            if (is_ratting)
            {
                if (is_up) angele = verticalAngle - speed;
                else angele = verticalAngle + speed;
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(angele, 0, 0));
            }
            else
            {
                //��ʂ𓮂������������ɃK�^�K�^�����邽�߂̐ݒ�
                if (is_up) angele = GamepadCameraConfig.VERTICAL_CAMERA_MAX_RATIING_ANGLE;
                else angele = GamepadCameraConfig.VERTICAL_CAMERA_MIN_RATIING_ANGLE;
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(angele, 0, 0));
            }
        }

        if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, true);

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, false);

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_LOW_SPEED, true);

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, false);
    }

    /*�Y�[���̐ݒ�
     * 
     * �Q�[���̃V�X�e���Ƃ��ĕs�v�Ƃ̂��ƂȂ̂ŃR�����g�A�E�g
     * 
     * ������������Ƃ�����{�^���z�u��ύX����K�v����B
     *(�b��I�ɃL�[�{�[�h�ɓ��Ă͂߂Ă�B)
     * �{�^�����Ƃ��Ă͏\���L�[�̏�Ɖ�
     * 
    /*
    private const float MAX_DISTANCE_CAMERA = 3;
    private const float MIN_DISTANCE_CAMERA = -1;
    public const float DELTA_DOLLY = 0.05f;

    private void Zoom()
    {
        if (Input.GetKey(KeyCode.X))
        {
            //�L�����N�^�[�ɃJ�������߂Â������Ȃ����߂̐ݒ�
            if (dollyNode.transform.localPosition.z < MAX_DISTANCE_CAMERA)
            {
                dollyNode.transform.localPosition += new Vector3(0, 0, DELTA_DOLLY);
            }
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            //�L�����N�^�[�ɃJ�����������������Ȃ����߂̐ݒ�
            if (dollyNode.transform.localPosition.z > MIN_DISTANCE_CAMERA)
            {
                dollyNode.transform.localPosition -= new Vector3(0, 0, DELTA_DOLLY);
            }
        }
    }
    */
}