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
        //�L�����N�^�[��at_mine_LOD0�ɐڐG�������̏���
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

    //0,2�b��ɏ��ł����鏈���B
    void MineDisappeard()
    {
        var itemsSound = GameObject.Find("ItemsSound").GetComponent<AudioSource>();
        itemsSound.PlayOneShot(explosionSound);
        GameObject burningField = Resources.Load<GameObject>("Items/Prefabs/BurningField_ForLandMines");

        // �����̕���
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
