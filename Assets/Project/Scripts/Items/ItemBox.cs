using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Item
{
    public enum Items
    {
        Bomb,           // ”š’e
        LandMines,      // ’n—‹
    }

    public class ItemBox : MonoBehaviour
    {
        //itemBox prefab
        [SerializeField] GameObject itemBox;

        //‰¼
        [SerializeField] Image image;

        public static Dictionary<Items, Sprite> ItemTextureDict;

        private void Start()
        {
            ItemTextureDict = new Dictionary<Items, Sprite>()
            {
                { Items.Bomb, Resources.Load<Sprite>("Items/Bomb") },
            };
        }

        void OnCollisionEnter(Collision col)
        {
            HitPlayer(col);
        }

        void HitPlayer(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                var sprite = ItemTextureDict[Items.Bomb];
                Debug.Log(sprite);
                //image = this.GetComponent<Image>();
                image.sprite = sprite;
                Destroy(itemBox);
            }
        }
    }
}
