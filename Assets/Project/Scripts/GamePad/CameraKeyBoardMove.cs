using UnityEngine;
using System;
using Gamepad.Config;

public class CameraKeyBoardMove: MonoBehaviour
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

        if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.LeftShift))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.LeftShift))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));
        
        else if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.J))
            //�J�������Z�b�g
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        else if (Input.GetKey(KeyCode.L))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));

        else if (Input.GetKey(KeyCode.J))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));
        
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

        if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.LeftShift))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, true);

        else if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.LeftShift))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, false);

        else if (Input.GetKey(KeyCode.I))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_LOW_SPEED, true);

        else if (Input.GetKey(KeyCode.K))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_LOW_SPEED, false);
    }

}