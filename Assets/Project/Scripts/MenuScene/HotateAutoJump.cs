using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateAutoJump : MonoBehaviour
{

    //�L�����N�^�[�̑����Ԃ��Ǘ�����t���O
    [SerializeField] public bool inJumping = false;
    [SerializeField] public bool onGround = true;

    //rigidbody�I�u�W�F�N�g�i�[�p�ϐ�
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�n�ʂɂ��鎞�����W�����v�����Ȃ�
        if (onGround)
        {
            inJumping = true;
            onGround = false;

                //�W�����v�����邽�ߏ�����ɗ͂𔭐�
            rb.AddForce(transform.up * 300);
        }
    }

    //�n�ʂɐڐG�����Ƃ��ɂ�onGround��true�Ainjumping��false�ɂ���
    //�������n�ʂ�Ground�^�O������K�v������
    //OnCollisionEnter�͕��̓��m���Ԃ��������ɌĂ΂��
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("Ground"))
        {
            onGround = true;
            inJumping = false;

            //���n���ɂЂ�����A��Ȃ��悤�ɂ�����@�B�v���t���Ȃ̂ŁA���̎����Č�����
            float current_y = transform.localEulerAngles.y;
            transform.rotation = Quaternion.Euler(0.0f, current_y, 0.0f);
        }
    }

}
