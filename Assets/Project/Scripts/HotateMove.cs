using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateMove : MonoBehaviour
{
    // Start is called before the first frame update

    //キャラクターの操作状態を管理するフラグ
    [SerializeField] public bool inJumping = false;
    [SerializeField] public bool onGround = true;

    //rigidbodyオブジェクト格納用変数
    [SerializeField] Rigidbody rb;

    //移動速度の定義
    float speed = 6f;

    //ダッシュ速度の定義
    float sprintspeed = 9f;

    //方向転換速度の定義
    float angleSpeed = 200;

    //移動の係数格納用変数
    float v;
    float h;

    void Update()
    {
        //Shift+上下キーでダッシュ、上下キーで通常移動,それ以外は停止
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
            v = Time.deltaTime * sprintspeed;
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
            v = -Time.deltaTime * sprintspeed;
        else if (Input.GetKey(KeyCode.DownArrow))
            v = Time.deltaTime * speed;
        else if (Input.GetKey(KeyCode.UpArrow))
            v = -Time.deltaTime * speed;
        else
            v = 0;

        //移動の実行
        //今回は空中での移動を許す。あとで許さないってなったらコメントアウトを解除
//        if (!inJumping)//空中での移動を禁止
//        {
        transform.position += transform.forward * v;
        //        }

        //地面にいる時しかジャンプさせない
        if (onGround)
        {
            //スペースボタンでジャンプする
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inJumping = true;
                onGround = false;

                //ジャンプさせるため上方向に力を発生
                rb.AddForce(transform.up * 300);

                //前方向キーを押しながらのジャンプの時には後方向に力を発生させる
                if (Input.GetKey(KeyCode.DownArrow))
                    rb.AddForce(transform.forward * 180);

                //後ろ方向キーを押しながらのジャンプの時には後方向に力を発生させる
                else if (Input.GetKey(KeyCode.UpArrow))
                    rb.AddForce(transform.forward * -100);

            }
        }

        //左右キーで方向転換
        if (Input.GetKey(KeyCode.RightArrow))
            h = Time.deltaTime * angleSpeed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            h = -Time.deltaTime * angleSpeed;
        else
            h = 0;

        //方向転換動作の実行
        transform.Rotate(Vector3.up * h);

    }

    //地面に接触したときにはonGroundをtrue、injumpingをfalseにする
    //ただし地面にGroundタグをつける必要がある
    //OnCollisionEnterは物体同士がぶつかった時に呼ばれる
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = true;
            inJumping = false;

            //着地時にひっくり帰らないようにする方法。思い付きなので、他の実装案検討中
            float current_y = transform.localEulerAngles.y;
            transform.rotation = Quaternion.Euler(0.0f, current_y, 0.0f);
        }
    }
}