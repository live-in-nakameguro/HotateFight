using GameScenes.SettingAndResultBattle;
using Hotate.Dead;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotate.Life
{
    public class HotateLife4 : MonoBehaviour
    {
        // �z�^�e��HP
        public static float hotateHP = BattleSetting.HotateHP;

        // �z�^�e���_���[�W���󂯂Ȃ��t���O
        [SerializeField] bool isInnvincible = false;

        // ���S�t���O
        [SerializeField] bool isDead = false;

        //rigidbody�I�u�W�F�N�g�i�[�p�ϐ�
        [SerializeField] Rigidbody rb;

        // �_���[�W���󂯂���̖��G���ԁi�b�j
        private float invincibleTime = 0.0f;

        //GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
        [SerializeField] int gamepadNumber = 4;

        static HotateLife4()
        {
            SceneManager.sceneLoaded += Init;
        }

        private static void Init(Scene loadingScene, LoadSceneMode loadSceneMode)
        {
            hotateHP = BattleSetting.HotateHP;
        }

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
            CollisionDamageTriger(col);
        }

        // IsTrigger�Ƀ`�F�b�N�������Ă���Collider�ɐڐG�����i���蔲�����j�ۂɌĂ΂��֐�
        // IsTrigger�Ƀ`�F�b�N������ƁA���蔲���铖���蔻��������ł���B
        // �������R�F�A�C�e���̔����ȂǂŁA�ӂ��Ƃ΂������肵�Ȃ��s��̑Ή�
        void OnTriggerEnter(Collider other)
        {
            ColliderDamageTriger(other);
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
                    HotateDeadController.IsHotateDeadDict[gamepadNumber] = true;
                }
            }
        }

        /// <summary>
        /// �z�^�e�Ƀ_���[�W��^���邩�𔻒f����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void CollisionDamageTriger(Collision col)
        {
            // ���G�̏ꍇ�A�_���[�W���󂯂Ȃ�
            if (isInnvincible)
            {
                return;
            }

            // �I�u�W�F�N�g�^�O���uDamageSource�v�̏ꍇ�A�_���[�W���󂯂�B
            if (col.gameObject.tag == "DamageSource")
            {
                CollisionCauseDamage(col);
            }
        }

        /// <summary>
        /// �z�^�e�Ƀ_���[�W��^����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void CollisionCauseDamage(Collision col)
        {
            // �ڐG�����I�u�W�F�N�g�̎��R���|�[�l���g�i�����ł̓X�N���v�g����Damage�N���X�j���Q�Ƃ���B
            var damage = col.gameObject.GetComponent<Damage.Damage>();
            CauseDamage(damage);
        }

        /// <summary>
        /// �z�^�e�Ƀ_���[�W��^���邩�𔻒f����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void ColliderDamageTriger(Collider other)
        {
            // ���G�̏ꍇ�A�_���[�W���󂯂Ȃ�
            if (isInnvincible)
            {
                return;
            }

            // �I�u�W�F�N�g�^�O���uDamageSource�v�̏ꍇ�A�_���[�W���󂯂�B
            if (other.gameObject.tag == "DamageSource")
            {
                ColliderCauseDamage(other);
            }
        }

        /// <summary>
        /// �z�^�e�Ƀ_���[�W��^����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void ColliderCauseDamage(Collider other)
        {
            // �ڐG�����I�u�W�F�N�g�̎��R���|�[�l���g�i�����ł̓X�N���v�g����Damage�N���X�j���Q�Ƃ���B
            var damage = other.gameObject.GetComponent<Damage.Damage>();
            CauseDamage(damage);
        }

        void CauseDamage(Damage.Damage damage)
        {
            invincibleTime = damage.invincibleTime;

            StartInvincible();

            // �z�^�e��HP�����炷�B
            hotateHP -= damage.damageNum;
            damage.HotateMotion(rb, transform);

            Debug.Log("hotateHP�F" + hotateHP);
        }
    }
}
