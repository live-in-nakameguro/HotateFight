using UnityEngine;

namespace Hotate.Life
{
    public class HotateLife : MonoBehaviour
    {
        // ホタテのHP
        [SerializeField] float hotateHP = 100.0f;

        // ホタテがダメージを受けないフラグ
        [SerializeField] bool isInnvincible = false;

        // 死亡フラグ
        [SerializeField] bool isDead = false;

        //rigidbodyオブジェクト格納用変数
        [SerializeField] Rigidbody rb;

        // ダメージを受けた後の無敵時間（秒）
        private float invincibleTime = 0.0f;

        // Invokerを使用しているかのフラグ
        bool isInvokeAlive = false;

        // Update is called once per frame
        void Update()
        {
            if (isInnvincible)
            {
                // Invokerを重複して呼び出さないため
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

                    // TODO：死亡時の挙動
                }
            }
        }

        // 物体が当たっている場合、呼ばれ続ける。
        // 調査TODO：接触し続けているように見えるが、途中で非接触判定になってしまう。ダメージ床の実装に必要
        // ダメージ床を実装しないならば、OnCollisionEnterを使用する。
        void OnCollisionStay(Collision col)
        {
            // 無敵の場合、ダメージを受けない
            if (isInnvincible)
            {
                return;
            }

            if (col.gameObject.tag == "DamageSource")
            {
                isInnvincible = true;

                // 接触したオブジェクトの持つコンポーネント（ここではスクリプト内のDamageクラス）を参照する。
                var damage = col.gameObject.GetComponent<Damage.Damage>();
                invincibleTime = damage.invincibleTime;

                // ホタテのHPを減らす
                hotateHP -= damage.damageNum;
                Debug.Log("hotateHP：" + hotateHP);
                Debug.Log("無敵始め");

                damage.HotateMotion(rb, transform);
            }
        }

        void EndInvincible()
        {
            isInnvincible = false;
            isInvokeAlive = false;
            Debug.Log("無敵終わり");
        }
    }
}
