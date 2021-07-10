using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

public class HotateGamePadMove : MonoBehaviour
{
    //操作したいAnimationControllerを持ったGameObjectを割り当てる
    [SerializeField]  Animator _animator;

    //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
    [SerializeField] int gamepadNumber = 0;

    //キャラクターの操作状態を管理するフラグ
    [SerializeField] bool inJumping = false;
    [SerializeField] bool onGround = true;

    //rigidbodyオブジェクト格納用変数
    [SerializeField] Rigidbody rb;

    //移動の係数格納用変数
    float v;
    float h;

    //ToDo: 左スティックの上下・左右を別のメソッド化します。
    void Update()
    {
        //左スティックの左右で方向転換
        if (Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
        {
            v = Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            _animator.SetBool("Running", true);
        }
        else if (Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)) <= (GamepadButtonConfig.LEFT_STICK_VER_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
        {
            v = -Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            _animator.SetBool("Running", true);
        }
        else if (Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)) >= (GamepadButtonConfig.LEFT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
        {
            v = Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            _animator.SetBool("Running", true);
        }
        else if (Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)) <= (GamepadButtonConfig.LEFT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
        {
            v = -Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            _animator.SetBool("Running", true);
        }
        else
        {
            v = 0;
            _animator.SetBool("Running", false);
        }

        //移動の実行
        transform.position += transform.forward * v;

        //地面にいる時しかジャンプさせない
        if (onGround)
        {
            //スペースボタンでジャンプする
            //if (Input.GetKeyDown(GamepadButtonConfig.BUTTON_B))
            if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_B)))
            {
                inJumping = true;
                onGround = false;
                //ジャンプさせるため上方向に力を発生
                rb.AddForce(transform.up * 300);
            }
        }

        //左スティックの左右で方向転換
        if (Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)) >= (GamepadButtonConfig.LEFT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            h = Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;

        else if (Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)) <= (GamepadButtonConfig.LEFT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            h = -Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;

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

    string SetGamepadNumber(string gamepadKey)
    {
        string gamepadNumberStr = "";
        if (gamepadNumber != 0) 
        {
            gamepadNumberStr = $" {gamepadNumber}";
        }
        Debug.Log(string.Format(gamepadKey, gamepadNumberStr));
        return string.Format(gamepadKey, gamepadNumberStr);
    } 
}
