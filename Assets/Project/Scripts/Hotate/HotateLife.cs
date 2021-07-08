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

        // Invoker���g�p���Ă��邩�̃t���O
        bool isInvokeAlive = false;

        // Update is called once per frame
        void Update()
        {
            if (isInnvincible)
            {
                // Invoker���d�����ČĂяo���Ȃ�����
                if (!isInvokeAlive) {
                    isInvokeAlive = true;
                    Invoke(nameof(EndInvincible), invincibleTime);
                }
            }

            if (!isDead) {
                if (hotateHP <= 0.0f)
                {
                    isDead = true;
                    Debug.Log("Dead");

                    // TODO�F���S���̋���
                }
            }
        }

        // ���̂��������Ă���ꍇ�A�Ă΂ꑱ����B
        // ����TODO�F�ڐG�������Ă���悤�Ɍ����邪�A�r���Ŕ�ڐG����ɂȂ��Ă��܂��B�_���[�W���̎����ɕK�v
        // �_���[�W�����������Ȃ��Ȃ�΁AOnCollisionEnter���g�p����B
        void OnCollisionStay(Collision col)
        {
            // ���G�̏ꍇ�A�_���[�W���󂯂Ȃ�
            if (isInnvincible)
            {
                return;
            }

            if (col.gameObject.tag == "DamageSource")
            {
                isInnvincible = true;

                // �ڐG�����I�u�W�F�N�g�̎��R���|�[�l���g�i�����ł̓X�N���v�g����Damage�N���X�j���Q�Ƃ���B
                var damage = col.gameObject.GetComponent<Damage.Damage>();
                invincibleTime = damage.invincibleTime;

                // �z�^�e��HP�����炷
                hotateHP -= damage.damageNum;
                Debug.Log("hotateHP�F" + hotateHP);
                Debug.Log("���G�n��");

                damage.HotateMotion(rb, transform);
            }
        }

        void EndInvincible()
        {
            isInnvincible = false;
            isInvokeAlive = false;
            Debug.Log("���G�I���");
        }
    }
}
