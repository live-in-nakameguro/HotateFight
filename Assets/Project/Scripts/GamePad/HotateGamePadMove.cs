using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;
using Common.Utils;
using Photon.Pun;

public class HotateGamePadMove : MonoBehaviourPunCallbacks
{
    //操作したいAnimationControllerを持ったGameObjectを割り当てる
    [SerializeField]  Animator _animator;

    //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
    [SerializeField] int gamepadNumber = 0;

    [SerializeField] GameObject horizontalRotNode;

    //キャラクターの操作状態を管理するフラグ
    private bool isFirstJumping = false;
    private bool isSecondJumping = false;
    private bool onGround = true;

    //rigidbodyオブジェクト格納用変数
    [SerializeField] Rigidbody rb;

    //カメラの位置がデフォルトにないときに利用する変数
    private static float cameraMinDeg = 0;
    private static float cameraMaxDeg = 360;
    private float cameraMidDeg = (cameraMinDeg + cameraMaxDeg) / 2f;

    //移動の係数格納用変数
    float v;
    float h;

    //FloorEfect
    float oldV;
    bool isEffectedFloor = false;
    string floorType = "Ground";
    int frameCount = 0;

    //上下・左右を別でメソッドで定義する。
    void Update()
    {
        //自分の操作が他のユーザの操作に影響を与えないようにする
        if (PhotonNetwork.IsConnected == true && photonView.IsMine == false)
            return;

        //カメラがデフォルト位置にないときの挙動
        PreventRotation();

        //ジャンプ
        Jump();

        //上下移動
        VerticalMovement();

        //水平移動
        HorizontalMovement();

    }

    //地面に接触したときにはonGroundをtrue、injumpingをfalseにする
    //ただし地面にGroundタグをつける必要がある
    //OnCollisionEnterは物体同士がぶつかった時に呼ばれる
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("Ground") || col.gameObject.tag == "Player")
        {
            onGround = true;
            isFirstJumping = false;
            isSecondJumping = false;
            if (col.gameObject.tag.Contains("Ground"))
            {
                floorType = col.gameObject.tag;
            }
        }     
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Contains("Ground") || col.gameObject.tag == "Player")
        {
            onGround = false;
            isFirstJumping = true;
            isSecondJumping = false;
        }
    }

    //カメラの位置がデフォルトにない際に、移動キーで直感的にカメラの位置を戻すメソッド
    private void ResetCameraHorizontalPosition()
    {
        float horizontalAngle = horizontalRotNode.transform.localEulerAngles.y;
        float h = 0;
        if (cameraMinDeg + 1 < horizontalAngle && horizontalAngle < cameraMidDeg)
        {
            horizontalRotNode.transform.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.VERTICAL_CAMERA_SPEED, 0));
            h = Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
        }

        else if (cameraMidDeg <= horizontalAngle && horizontalAngle < cameraMaxDeg - 1)
        {
            horizontalRotNode.transform.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.VERTICAL_CAMERA_SPEED, 0));
            h = -Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
        }
        else {
            horizontalRotNode.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        transform.Rotate(Vector3.up * h);

    }

    private void VerticalMovement()
    {
        //床による影響
        FloorEffects();

        //上下で移動
        if (HotateMovingUtils.isPressedDashDownMoving(gamepadNumber))
        {
            v = Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedDashUpMoving(gamepadNumber))
        {
            v = -Time.deltaTime * GamepadHotateConfig.DASH_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedDownMoving(gamepadNumber))
        {
            v = Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedUpMoving(gamepadNumber))
        {
            v = -Time.deltaTime * GamepadHotateConfig.WALK_SPPED;
            oldV = v;
            frameCount = 0;
            _animator.SetBool("Running", true);
            ResetCameraHorizontalPosition();
        }
        else
        {
            v = 0;
            isEffectedFloor = true;
            _animator.SetBool("Running", false);
        }

        //移動の実行
        transform.position += transform.forward * v;
    }

    private void HorizontalMovement()
    {
        if (HotateMovingUtils.isPressedRightMoving(gamepadNumber))
        {
            h = Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
            ResetCameraHorizontalPosition();
        }
        else if (HotateMovingUtils.isPressedLeftMoving(gamepadNumber))
        {
            h = -Time.deltaTime * GamepadHotateConfig.ANGLE_CHAGE_SPPED;
            ResetCameraHorizontalPosition();
        }
        else
            h = 0;

        //方向転換動作の実行
        transform.Rotate(Vector3.up * h);
    }

    void Jump()
    {
        if (isSecondJumping) return;

        if (HotateMovingUtils.isPressedJump(gamepadNumber))
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

    void PreventRotation()
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

    private void FloorEffects()
    {
        if (!isEffectedFloor) return;

        switch (floorType)
        {
            case "Ground/Ice":
                IceFloorEfect();
                break;
            default:
                break;
        }
    }

    private void IceFloorEfect()
    {
        transform.position += transform.forward * oldV;
        frameCount += 1;
        if (frameCount >= 300)
        {
            isEffectedFloor = false;
            oldV = 0;
            frameCount = 0;
        }

    }
}
