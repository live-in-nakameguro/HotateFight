using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotate.Damage
{
    // ���g�p
    public enum DamageTypes
    {   
        // ���I�����̐ݒ�
        NoType,
        // �e�X�g�ō쐬��������
        Explosion,
        // �e�X�g�ō쐬�����_���[�W��
        Floor
    }

    public class Damage : MonoBehaviour
    {
        // �_���[�W�l
        public float damageNum = 20.0f;

        // �_���[�W���󂯂���̖��G���ԁi�b�j
        public float invincibleTime = 3.0f;

        // ���g�p
        // �I�u�W�F�N�g�̎��
        public DamageTypes damageType = DamageTypes.NoType;

        /// <summary>
        /// �_���[�W���󂯂��ۂ̃z�^�e�̋���
        /// </summary>
        /// <param name="rb">�z�^�e��Rigidbody</param>
        /// <param name="transform">�z�^�e��Transform</param>
        public virtual void HotateMotion(Rigidbody rb, Transform transform)  //virtual��t�^
        {
            Debug.Log("���[�V�����ݒ�Ȃ�");
        }
    }
}
