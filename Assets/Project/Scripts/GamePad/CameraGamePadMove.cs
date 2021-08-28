using UnityEngine;
using System;
using Gamepad.Config;
using Common.Utils;
using Photon.Pun;

public class CameraGamePadMove: MonoBehaviourPunCallbacks
{
    //GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
    [SerializeField] int gamepadNumber = 0;

    [SerializeField] Transform horizontalRotNode;
    [SerializeField] Transform verticalRotNode;
    [SerializeField] Transform dollyNode;

    void Update()
    {
        //�����̑��삪���̃��[�U�̑���ɉe����^���Ȃ��悤�ɂ���
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            return;

        HorizontalMotion();
        VerticalMotion();
        //�Y�[���p�̊֐�:�R�����g�A�E�g���R�̓��\�b�h��`���Q��
        //Zoom();
    }

    // ���������̉�]
    private void HorizontalMotion()
    {
        float horizontalAngle = horizontalRotNode.localRotation.eulerAngles.y;
        if (HotateCameraUtils.isPressedCameraReset(gamepadNumber))
            //�J�������Z�b�g
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        else if (HotateCameraUtils.isPressedCameraLeftSpeedy(gamepadNumber))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (HotateCameraUtils.isPressedCameraRightSpeedy(gamepadNumber))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (HotateCameraUtils.isPressedCameraLeft(gamepadNumber))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));

        else if (HotateCameraUtils.isPressedCameraRight(gamepadNumber))
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

        if (HotateCameraUtils.isPressedCameraUpSpeedy(gamepadNumber))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, true);

        else if (HotateCameraUtils.isPressedCameraDownSpeedy(gamepadNumber))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, false);

        else if (HotateCameraUtils.isPressedCameraUp(gamepadNumber))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_LOW_SPEED, true);

        else if (HotateCameraUtils.isPressedCameraDown(gamepadNumber))
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