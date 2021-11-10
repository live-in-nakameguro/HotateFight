using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;
using Common.Utils;
using Photon.Pun;

public class HotateGamePadMove : MonoBehaviourPunCallbacks
{
    //���삵����AnimationController��������GameObject�����蓖�Ă�
    [SerializeField]  Animator _animator;

    //GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
    [SerializeField] int gamepadNumber = 0;

    [SerializeField] GameObject horizontalRotNode;

    //�L�����N�^�[�̑����Ԃ��Ǘ�����t���O
    private bool isFirstJumping = false;
    private bool isSecondJumping = false;
    private bool onGround = true;

    //rigidbody�I�u�W�F�N�g�i�[�p�ϐ�
    [SerializeField] Rigidbody rb;

    //�J�����̈ʒu���f�t�H���g�ɂȂ��Ƃ��ɗ��p����ϐ�
    private static float cameraMinDeg = 0;
    private static float cameraMaxDeg = 360;
    private float cameraMidDeg = (cameraMinDeg + cameraMaxDeg) / 2f;

    //�ړ��̌W���i�[�p�ϐ�
    float v;
    float h;

    //FloorEfect
    float oldV;
    bool isEffectedFloor = false;
    string floorType = "Ground";
    int frameCount = 0;

    //�㉺�E���E��ʂŃ��\�b�h�Œ�`����B
    void Update()
    {
        //�����̑��삪���̃��[�U�̑���ɉe����^���Ȃ��悤�ɂ���
        if (PhotonNetwork.IsConnected == true && photonView.IsMine == false)
            return;

        //�J�������f�t�H���g�ʒu�ɂȂ��Ƃ��̋���
        PreventRotation();

        //�W�����v
        Jump();

        //�㉺�ړ�
        VerticalMovement();

        //�����ړ�
        HorizontalMovement();

    }

    //�n�ʂɐڐG�����Ƃ��ɂ�onGround��true�Ainjumping��false�ɂ���
    //�������n�ʂ�Ground�^�O������K�v������
    //OnCollisionEnter�͕��̓��m���Ԃ��������ɌĂ΂��
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("Ground") || col.gameObject.tag == "Player")
        {
            onGround = true;
            isFirstJumping = false;
            isSecondJumping = false;
            if (col.gameObject.tag.Contains("Ground"))
            {
                floorType = col.gameObject.tag;
            }
        }     
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Contains("Ground") || col.gameObject.tag == "Player")
        {
            onGround = false;
            isFirstJumping = true;
            isSecondJumping = false;
        }
    }

    //�J�����̈ʒu���f�t�H���g�ɂȂ��ۂɁA�ړ��L�[�Œ����I�ɃJ�����̈ʒu��߂����\�b�h
    private void ResetCameraHorizontalPosition()
    {
        float horizontalAngle = horizontalRotNode.transform.localEulerAngles.y;
        float h = 0;
        if (cameraMinDeg + 1 < horizontalAngle && horizontalAngle < cameraMidDeg)
        {
            horizontalRotNode.transform.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.VERTICAL_CAMERA_SPEED, 0));
            h = Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
        }

        else if (cameraMidDeg <= horizontalAngle && horizontalAngle < cameraMaxDeg - 1)
        {
            horizontalRotNode.transform.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.VERTICAL_CAMERA_SPEED, 0));
            h = -Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
        }
        else {
            horizontalRotNode.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        transform.Rotate(Vector3.up * h);

    }

    private void VerticalMovement()
    {
        //���ɂ��e��
        FloorEffects();

        //�㉺�ňړ�
        if (HotateMovingUtils.isPressedDashDownMoving(gamepadNumber))
        {
            v = Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedDashUpMoving(gamepadNumber))
        {
            v = -Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedDownMoving(gamepadNumber))
        {
            v = Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedUpMoving(gamepadNumber))
        {
            v = -Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else
        {
            v = 0;
            isEffectedFloor = true;
            _animator.SetBool("Running", false);
        }

        //�ړ��̎��s
        transform.position += transform.forward * v;
    }

    private void HorizontalMovement()
    {
        if (HotateMovingUtils.isPressedRightMoving(gamepadNumber))
        {
            h = Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedLeftMoving(gamepadNumber))
        {
            h = -Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
            ResetCameraHorizontalPosition();
        }
        else
            h = 0;

        //�����]������̎��s
        transform.Rotate(Vector3.up * h);
    }

    void Jump()
    {
        if (isSecondJumping) return;

        if (HotateMovingUtils.isPressedJump(gamepadNumber))
        {
            onGround = false;
            if (!isFirstJumping)
            {
                isFirstJumping = true;
                rb.AddForce(transform.up * 300);
            }
            else
            {
                isSecondJumping = true;
                rb.AddForce(transform.up * 300);
            }
                
        }
    }

    void PreventRotation()
    {
        float current_x = transform.localEulerAngles.x;
        float current_y = transform.localEulerAngles.y;
        float current_z = transform.localEulerAngles.z;

        float plusminus_x = -1;
        float plusminus_z = -1;
        if (current_x >= 0) plusminus_x = 1;
        if (current_z >= 0) plusminus_z = 1;

        float abs_current_x = Mathf.Abs(current_x);
        float abs_current_z = Mathf.Abs(current_z);

        transform.rotation = Quaternion.Euler(plusminus_x * abs_current_x * ( 29/30 ), current_y, plusminus_z * abs_current_z * ( 29/30 ));
    }

    private void FloorEffects()
    {
        if (!isEffectedFloor) return;

        switch (floorType)
        {
            case "Ground/Ice":
                IceFloorEfect();
                break;
            default:
                break;
        }
    }

    private void IceFloorEfect()
    {
        transform.position += transform.forward * oldV;
        frameCount += 1;
        if (frameCount >= 300)
        {
            isEffectedFloor = false;
            oldV = 0;
            frameCount = 0;
        }

    }
}
