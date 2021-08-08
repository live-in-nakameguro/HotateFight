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
    private bool isFirstJumping = false;
    private bool isSecondJumping = false;
    private bool onGround = true;

    //rigidbodyオブジェクト格納用変数
    [SerializeField] Rigidbody rb;

    //移動の係数格納用変数
    float v;
    float h;

    //ToDo: 左スティックの上下・左右を別のメソッド化します。
    void Update()
    {
        PrecventionRotation();

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

        //ジャンプ
        Jump();

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
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            onGround = true;
            isFirstJumping = false;
            isSecondJumping = false;
        }     
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            onGround = false;
            isFirstJumping = true;
            isSecondJumping = false;
        }
    }

    void Jump()
    {
        if (isSecondJumping) return;

        if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_B)))
        {
            onGround = false;
            if (!isFirstJumping)
            {
                isFirstJumping = true;
                rb.AddForce(transform.up * 300);
            }
            else
            {
                isSecondJumping = true;
                rb.AddForce(transform.up * 300);
            }
                
        }
    }

    void PrecventionRotation()
    {
        float current_x = transform.localEulerAngles.x;
        float current_y = transform.localEulerAngles.y;
        float current_z = transform.localEulerAngles.z;

        float plusminus_x = -1;
        float plusminus_z = -1;
        if (current_x >= 0) plusminus_x = 1;
        if (current_z >= 0) plusminus_z = 1;

        float abs_current_x = Mathf.Abs(current_x);
        float abs_current_z = Mathf.Abs(current_z);

        transform.rotation = Quaternion.Euler(plusminus_x * abs_current_x * ( 29/30 ), current_y, plusminus_z * abs_current_z * ( 29/30 ));
    }

    string SetGamepadNumber(string gamepadKey)
    {
        string gamepadNumberStr = "";
        if (gamepadNumber != 0) 
        {
            gamepadNumberStr = $" {gamepadNumber}";
        }
        return string.Format(gamepadKey, gamepadNumberStr);
    } 
}
