using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ExplosionBomb : MonoBehaviour
    {
        // SE
        [SerializeField] AudioClip bombSound;

        // 親オブジェクトの子供の番号（上から数える）
        private int childIndex = 0;

        // 子オブジェクトを表示する時間
        private float activeTime = 1.0f;

        private GameObject cloneBurningFields;

        private bool isExplosion = false;

        // Start is called before the first frame update
        void Start()
        {
            //Componentを取得
            Invoke(nameof(DestroyBurningField), 10.0f);
        }

        void OnCollisionEnter(Collision col)
        {
            if (!isExplosion) {
                Explosion();
            }
        }

        /// <summary>
        /// 爆発
        /// </summary>
        /// <param name="col">ホタテに接触したCollision</param>
        void Explosion()
        {
            isExplosion = true;
            var itemsSound = GameObject.Find("ItemsSound").GetComponent<AudioSource>();
            itemsSound.PlayOneShot(bombSound);
            GameObject burningField = Resources.Load<GameObject>("Items/Prefabs/BurningField");

            // 爆発の複製
            cloneBurningFields = Instantiate(burningField) as GameObject;
            cloneBurningFields.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
            Invoke(nameof(DestroyBurningField), 1.0f);
        }

        void DestroyBurningField()
        {
            if (cloneBurningFields != null) {
                Destroy(cloneBurningFields);
            }
            Destroy(gameObject);
        }
    }
}
