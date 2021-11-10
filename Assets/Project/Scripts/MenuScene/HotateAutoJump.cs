using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateAutoJump : MonoBehaviour
{

    //キャラクターの操作状態を管理するフラグ
    [SerializeField] public bool inJumping = false;
    [SerializeField] public bool onGround = true;

    //rigidbodyオブジェクト格納用変数
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //地面にいる時しかジャンプさせない
        if (onGround)
        {
            inJumping = true;
            onGround = false;

                //ジャンプさせるため上方向に力を発生
            rb.AddForce(transform.up * 300);
        }
    }

    //地面に接触したときにはonGroundをtrue、injumpingをfalseにする
    //ただし地面にGroundタグをつける必要がある
    //OnCollisionEnterは物体同士がぶつかった時に呼ばれる
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("Ground"))
        {
            onGround = true;
            inJumping = false;

            //着地時にひっくり帰らないようにする方法。思い付きなので、他の実装案検討中
            float current_y = transform.localEulerAngles.y;
            transform.rotation = Quaternion.Euler(0.0f, current_y, 0.0f);
        }
    }

}
