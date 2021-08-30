using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ExplosionBomb : MonoBehaviour
    {
        // SE
        [SerializeField] AudioClip bombSound;

        // �e�I�u�W�F�N�g�̎q���̔ԍ��i�ォ�琔����j
        private int childIndex = 0;

        // �q�I�u�W�F�N�g��\�����鎞��
        private float activeTime = 1.0f;

        private GameObject cloneBurningFields;

        private bool isExplosion = false;

        // Start is called before the first frame update
        void Start()
        {
            //Component���擾
            Invoke(nameof(DestroyBurningField), 10.0f);
        }

        void OnCollisionEnter(Collision col)
        {
            if (!isExplosion) {
                Explosion();
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="col">�z�^�e�ɐڐG����Collision</param>
        void Explosion()
        {
            isExplosion = true;
            var itemsSound = GameObject.Find("ItemsSound").GetComponent<AudioSource>();
            itemsSound.PlayOneShot(bombSound);
            GameObject burningField = Resources.Load<GameObject>("Items/Prefabs/BurningField");

            // �����̕���
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
