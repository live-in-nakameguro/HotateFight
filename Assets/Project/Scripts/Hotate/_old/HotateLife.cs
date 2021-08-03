using UnityEngine;

namespace Hotate.Life
{
    public class HotateLife : MonoBehaviour
    {
        // �z�^�e��HP
        [SerializeField] float hotateHP = 100.0f;

        // �z�^�e���_���[�W���󂯂Ȃ��t���O
        [SerializeField] bool isInnvincible = false;

        // ���S�t���O
        [SerializeField] bool isDead = false;

        //rigidbody�I�u�W�F�N�g�i�[�p�ϐ�
        [SerializeField] Rigidbody rb;

        // �_���[�W���󂯂���̖��G���ԁi�b�j
        private float invincibleTime = 0.0f;

        // Update is called once per frame
        void Update()
        {
            DeadController();
        }

        // ���̂��������Ă���ꍇ�A�Ă΂ꑱ����B
        // ����TODO�F�ڐG�������Ă���悤�Ɍ����邪�A�r���Ŕ�ڐG����ɂȂ��Ă��܂��B�_���[�W���̎����ɕK�v
        // �_���[�W�����������Ȃ��Ȃ�΁AOnCollisionEnter���g�p����B
        void OnCollisionEnter(Collision col)
        {
            DamageTriger(col);
        }

        /// <summary>
        /// �z�^�e����莞�ԁiinvincibleTime�b�ԁj���G�ɂ���
        /// </summary>
        void StartInvincible()
        {
            isInnvincible = true;
            Debug.Log("���G�n��");
            Invoke(nameof(EndInvincible), invincibleTime);
        }

        /// <summary>
        /// �z�^�e�̖��G���I������iInvoke�Ŏg�p�j
        /// </summary>
        void EndInvincible()
        {
            isInnvincible = false;
            Debug.Log("���G�I���");
        }

        /// <summary>
        /// �z�^�e�̐����𔻒肷��
        /// </summary>
        void DeadController()
        {
            if (!isDead)
            {
                if (hotateHP <= 0.0f)
                {
                    isDead = true;
                    Debug.Log("Dead");

                    // TODO�F���S���̋���
                }
            }
        }

        /// <summary>
        /// �z�^�e�Ƀ_���[�W��^���邩�𔻒f����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void DamageTriger(Collision col)
        {
            // ���G�̏ꍇ�A�_���[�W���󂯂Ȃ�
            if (isInnvincible)
            {
                return;
            }

            // �I�u�W�F�N�g�^�O���uDamageSource�v�̏ꍇ�A�_���[�W���󂯂�B
            if (col.gameObject.tag == "DamageSource")
            {
                CauseDamage(col);
            }
        }

        /// <summary>
        /// �z�^�e�Ƀ_���[�W��^����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void CauseDamage(Collision col)
        {
            // �ڐG�����I�u�W�F�N�g�̎��R���|�[�l���g�i�����ł̓X�N���v�g����Damage�N���X�j���Q�Ƃ���B
            var damage = col.gameObject.GetComponent<Damage.Damage>();
            invincibleTime = damage.invincibleTime;

            StartInvincible();

            // �z�^�e��HP�����炷�B
            hotateHP -= damage.damageNum;
            damage.HotateMotion(rb, transform);

            Debug.Log("hotateHP�F" + hotateHP);
        }
    }
}
