using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

public class HotateGamePadMove : MonoBehaviour
{
    //���삵����AnimationController��������GameObject�����蓖�Ă�
    [SerializeField]  Animator _animator;

    //�L�����N�^�[�̑����Ԃ��Ǘ�����t���O
    [SerializeField] bool inJumping = false;
    [SerializeField] bool onGround = true;

    //rigidbody�I�u�W�F�N�g�i�[�p�ϐ�
    [SerializeField] Rigidbody rb;

    //�ړ��̌W���i�[�p�ϐ�
    float v;
    float h;

    //ToDo: ���X�e�B�b�N�̏㉺�E���E��ʂ̃��\�b�h�����܂��B
    void Update()
    {
        //���X�e�B�b�N�̍��E�ŕ����]��
        if (Input.GetAxis(GamepadButtonConfig.LEFT_STICK_VER) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
        {
            v = Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            _animator.SetBool("Running", true);
        }
        else if (Input.GetAxis(GamepadButtonConfig.LEFT_STICK_VER) <= (GamepadButtonConfig.LEFT_STICK_VER_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
        {
            v = -Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            _animator.SetBool("Running", true);
        }
        else if (Input.GetAxis(GamepadButtonConfig.LEFT_STICK_VER) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
        {
            v = Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            _animator.SetBool("Running", true);
        }
        else if (Input.GetAxis(GamepadButtonConfig.LEFT_STICK_VER) <= (GamepadButtonConfig.LEFT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
        {
            v = -Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            _animator.SetBool("Running", true);
        }
        else
        {
            v = 0;
            _animator.SetBool("Running", false);
        }

        //�ړ��̎��s
        transform.position += transform.forward * v;

        //�n�ʂɂ��鎞�����W�����v�����Ȃ�
        if (onGround)
        {
            //�X�y�[�X�{�^���ŃW�����v����
            if (Input.GetKeyDown(GamepadButtonConfig.BUTTON_B))
            {
                inJumping = true;
                onGround = false;
                //�W�����v�����邽�ߏ�����ɗ͂𔭐�
                rb.AddForce(transform.up * 300);
            }
        }

        //���X�e�B�b�N�̍��E�ŕ����]��
        if (Input.GetAxis(GamepadButtonConfig.LEFT_STICK_HORI) >= (GamepadButtonConfig.LEFT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            h = Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;

        else if (Input.GetAxis(GamepadButtonConfig.LEFT_STICK_HORI) <= (GamepadButtonConfig.LEFT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            h = -Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;

        else
            h = 0;

        //�����]������̎��s
        transform.Rotate(Vector3.up * h);
    }

    //�n�ʂɐڐG�����Ƃ��ɂ�onGround��true�Ainjumping��false�ɂ���
    //�������n�ʂ�Ground�^�O������K�v������
    //OnCollisionEnter�͕��̓��m���Ԃ��������ɌĂ΂��
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = true;
            inJumping = false;

            //���n���ɂЂ�����A��Ȃ��悤�ɂ�����@�B�v���t���Ȃ̂ŁA���̎����Č�����
            float current_y = transform.localEulerAngles.y;
            transform.rotation = Quaternion.Euler(0.0f, current_y, 0.0f);
        }
    }
}