using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ShootingBomb : MonoBehaviour
    {
        public static void Shooting(GameObject hotate, GameObject bomb, Transform muzzle)
        {
            // AudioSource��static�łȂ����߁A���������ŏo�����Ƃ��ł��Ȃ��B

            // ���e�̑��x
            float speed = 10;

            // ���e�̕���
            GameObject bombs = Instantiate(bomb, muzzle.position + new Vector3(0, 1, 0), muzzle.rotation) as GameObject;

            // ���ʕ����ɔ��˂���
            var force = muzzle.transform.forward * -speed;

            // �Ε����˂���
            force += new Vector3(0,10,0);

            // ���e�I�u�W�F�N�g��Rigidbody�R���|�[�l���g�ւ̎Q�Ƃ��擾
            Rigidbody rb = bombs.GetComponent<Rigidbody>();

            // �͂������郁�\�b�h
            // ForceMode.Impulse�͌���
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
