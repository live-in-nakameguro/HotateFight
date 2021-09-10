using GameScenes.SettingAndResultBattle;
using Hotate.Dead;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotate.Life
{
    public class HotateLife4 : MonoBehaviour
    {
        // ホタテのHP
        public static float hotateHP = BattleSetting.HotateHP;

        // ホタテがダメージを受けないフラグ
        [SerializeField] bool isInnvincible = false;

        // 死亡フラグ
        [SerializeField] bool isDead = false;

        //rigidbodyオブジェクト格納用変数
        [SerializeField] Rigidbody rb;

        // ダメージを受けた後の無敵時間（秒）
        private float invincibleTime = 0.0f;

        //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
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

        // 物体が当たっている場合、呼ばれ続ける。
        // 調査TODO：接触し続けているように見えるが、途中で非接触判定になってしまう。ダメージ床の実装に必要
        // ダメージ床を実装しないならば、OnCollisionEnterを使用する。
        void OnCollisionEnter(Collision col)
        {
            CollisionDamageTriger(col);
        }

        // IsTriggerにチェックが入っているColliderに接触した（すり抜けた）際に呼ばれる関数
        // IsTriggerにチェックを入れると、すり抜ける当たり判定を実装できる。
        // 実装理由：アイテムの爆発などで、ふっとばしが安定しない不具合の対応
        void OnTriggerEnter(Collider other)
        {
            ColliderDamageTriger(other);
        }

        /// <summary>
        /// ホタテを一定時間（invincibleTime秒間）無敵にする
        /// </summary>
        void StartInvincible()
        {
            isInnvincible = true;
            Debug.Log("無敵始め");
            Invoke(nameof(EndInvincible), invincibleTime);
        }

        /// <summary>
        /// ホタテの無敵を終了する（Invokeで使用）
        /// </summary>
        void EndInvincible()
        {
            isInnvincible = false;
            Debug.Log("無敵終わり");
        }

        /// <summary>
        /// ホタテの生死を判定する
        /// </summary>
        void DeadController()
        {
            if (!isDead)
            {
                if (hotateHP <= 0.0f)
                {
                    isDead = true;
                    Debug.Log("Dead");

                    // TODO：死亡時の挙動
                    HotateDeadController.IsHotateDeadDict[gamepadNumber] = true;
                }
            }
        }

        /// <summary>
        /// ホタテにダメージを与えるかを判断する
        /// </summary>
        /// <param name="col">ホタテに接触したCollision</param>
        void CollisionDamageTriger(Collision col)
        {
            // 無敵の場合、ダメージを受けない
            if (isInnvincible)
            {
                return;
            }

            // オブジェクトタグが「DamageSource」の場合、ダメージを受ける。
            if (col.gameObject.tag == "DamageSource")
            {
                CollisionCauseDamage(col);
            }
        }

        /// <summary>
        /// ホタテにダメージを与える
        /// </summary>
        /// <param name="col">ホタテに接触したCollision</param>
        void CollisionCauseDamage(Collision col)
        {
            // 接触したオブジェクトの持つコンポーネント（ここではスクリプト内のDamageクラス）を参照する。
            var damage = col.gameObject.GetComponent<Damage.Damage>();
            CauseDamage(damage);
        }

        /// <summary>
        /// ホタテにダメージを与えるかを判断する
        /// </summary>
        /// <param name="col">ホタテに接触したCollision</param>
        void ColliderDamageTriger(Collider other)
        {
            // 無敵の場合、ダメージを受けない
            if (isInnvincible)
            {
                return;
            }

            // オブジェクトタグが「DamageSource」の場合、ダメージを受ける。
            if (other.gameObject.tag == "DamageSource")
            {
                ColliderCauseDamage(other);
            }
        }

        /// <summary>
        /// ホタテにダメージを与える
        /// </summary>
        /// <param name="col">ホタテに接触したCollision</param>
        void ColliderCauseDamage(Collider other)
        {
            // 接触したオブジェクトの持つコンポーネント（ここではスクリプト内のDamageクラス）を参照する。
            var damage = other.gameObject.GetComponent<Damage.Damage>();
            CauseDamage(damage);
        }

        void CauseDamage(Damage.Damage damage)
        {
            invincibleTime = damage.invincibleTime;

            StartInvincible();

            // ホタテのHPを減らす。
            hotateHP -= damage.damageNum;
            damage.HotateMotion(rb, transform);

            Debug.Log("hotateHP：" + hotateHP);
        }
    }
}
