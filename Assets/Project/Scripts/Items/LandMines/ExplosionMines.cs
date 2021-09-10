using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMines : MonoBehaviour
{
    // SE
    [SerializeField] AudioClip explosionSound;

    private GameObject cloneBurningFields;

    private bool isExplosion = false;

    void Start()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        //キャラクターがat_mine_LOD0に接触した時の処理
        if (col.gameObject.tag == "Player") 
        { 
            if (!isExplosion)
            {
                Exprosion();
            }
        }
    }

    void Exprosion()
    {
        isExplosion = true;
        Invoke(nameof(MineDisappeard), 0.2f);
    }

    //0,2秒後に消滅させる処理。
    void MineDisappeard()
    {
        var itemsSound = GameObject.Find("ItemsSound").GetComponent<AudioSource>();
        itemsSound.PlayOneShot(explosionSound);
        GameObject burningField = Resources.Load<GameObject>("Items/Prefabs/BurningField_ForLandMines");

        // 爆発の複製
        cloneBurningFields = Instantiate(burningField) as GameObject;
        cloneBurningFields.transform.position = gameObject.transform.position;

        gameObject.SetActive(false);
        Invoke(nameof(DestroyBurningField), 1.0f);
    }

    void DestroyBurningField()
    {
        if (cloneBurningFields != null)
        {
            Destroy(cloneBurningFields);
        }
        Destroy(gameObject);
    }

}
