using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateMove : MonoBehaviour
{
    // Start is called before the first frame update

    //�L�����N�^�[�̑����Ԃ��Ǘ�����t���O
    [SerializeField] public bool inJumping = false;
    [SerializeField] public bool onGround = true;

    //rigidbody�I�u�W�F�N�g�i�[�p�ϐ�
    [SerializeField] Rigidbody rb;

    //�ړ����x�̒�`
    float speed = 6f;

    //�_�b�V�����x�̒�`
    float sprintspeed = 9f;

    //�����]�����x�̒�`
    float angleSpeed = 200;

    //�ړ��̌W���i�[�p�ϐ�
    float v;
    float h;

    void Update()
    {
        //Shift+�㉺�L�[�Ń_�b�V���A�㉺�L�[�Œʏ�ړ�,����ȊO�͒�~
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
            v = Time.deltaTime * sprintspeed;
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
            v = -Time.deltaTime * sprintspeed;
        else if (Input.GetKey(KeyCode.DownArrow))
            v = Time.deltaTime * speed;
        else if (Input.GetKey(KeyCode.UpArrow))
            v = -Time.deltaTime * speed;
        else
            v = 0;

        //�ړ��̎��s
        //����͋󒆂ł̈ړ��������B���Ƃŋ����Ȃ����ĂȂ�����R�����g�A�E�g������
//        if (!inJumping)//�󒆂ł̈ړ����֎~
//        {
        transform.position += transform.forward * v;
        //        }

        //�n�ʂɂ��鎞�����W�����v�����Ȃ�
        if (onGround)
        {
            //�X�y�[�X�{�^���ŃW�����v����
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inJumping = true;
                onGround = false;

                //�W�����v�����邽�ߏ�����ɗ͂𔭐�
                rb.AddForce(transform.up * 300);

                //�O�����L�[�������Ȃ���̃W�����v�̎��ɂ͌�����ɗ͂𔭐�������
                if (Input.GetKey(KeyCode.DownArrow))
                    rb.AddForce(transform.forward * 180);

                //�������L�[�������Ȃ���̃W�����v�̎��ɂ͌�����ɗ͂𔭐�������
                else if (Input.GetKey(KeyCode.UpArrow))
                    rb.AddForce(transform.forward * -100);

            }
        }

        //���E�L�[�ŕ����]��
        if (Input.GetKey(KeyCode.RightArrow))
            h = Time.deltaTime * angleSpeed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            h = -Time.deltaTime * angleSpeed;
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