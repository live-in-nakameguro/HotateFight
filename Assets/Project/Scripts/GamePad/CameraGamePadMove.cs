using UnityEngine;
using System;
using Gamepad.Config;
using Common.Utils;
using Photon.Pun;

public class CameraGamePadMove: MonoBehaviourPunCallbacks
{
    //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
    [SerializeField] int gamepadNumber = 0;

    [SerializeField] Transform horizontalRotNode;
    [SerializeField] Transform verticalRotNode;
    [SerializeField] Transform dollyNode;

    void Update()
    {
        //自分の操作が他のユーザの操作に影響を与えないようにする
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            return;

        HorizontalMotion();
        VerticalMotion();
        //ズーム用の関数:コメントアウト理由はメソッド定義を参照
        //Zoom();
    }

    // 水平方向の回転
    private void HorizontalMotion()
    {
        float horizontalAngle = horizontalRotNode.localRotation.eulerAngles.y;
        if (HotateCameraUtils.isPressedCameraReset(gamepadNumber))
            //カメラリセット
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        else if (HotateCameraUtils.isPressedCameraLeftSpeedy(gamepadNumber))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (HotateCameraUtils.isPressedCameraRightSpeedy(gamepadNumber))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (HotateCameraUtils.isPressedCameraLeft(gamepadNumber))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));

        else if (HotateCameraUtils.isPressedCameraRight(gamepadNumber))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));
    
    }

    //上下の回転
    private void VerticalMotion()
    {
        float verticalAngle = verticalRotNode.rotation.eulerAngles.x;
        bool is_ratting = verticalAngle <= GamepadCameraConfig.VERTICAL_CAMERA_ANGLE_MIN_THRESHOLD || verticalAngle >= GamepadCameraConfig.VERTICAL_CAMERA_ANGLE_MAX_THRESHOLD;

        void UpOrDown(float speed, bool is_up)
        {
            float angele;

            if (is_ratting)
            {
                if (is_up) angele = verticalAngle - speed;
                else angele = verticalAngle + speed;
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(angele, 0, 0));
            }
            else
            {
                //画面を動かしすぎた時にガタガタさせるための設定
                if (is_up) angele = GamepadCameraConfig.VERTICAL_CAMERA_MAX_RATIING_ANGLE;
                else angele = GamepadCameraConfig.VERTICAL_CAMERA_MIN_RATIING_ANGLE;
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(angele, 0, 0));
            }
        }

        if (HotateCameraUtils.isPressedCameraUpSpeedy(gamepadNumber))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, true);

        else if (HotateCameraUtils.isPressedCameraDownSpeedy(gamepadNumber))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, false);

        else if (HotateCameraUtils.isPressedCameraUp(gamepadNumber))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_LOW_SPEED, true);

        else if (HotateCameraUtils.isPressedCameraDown(gamepadNumber))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, false);
    }

    /*ズームの設定
     * 
     * ゲームのシステムとして不要とのことなのでコメントアウト
     * 
     * もし実装するとしたらボタン配置を変更する必要あり。
     *(暫定的にキーボードに当てはめてる。)
     * ボタン候補としては十字キーの上と下
     * 
    /*
    private const float MAX_DISTANCE_CAMERA = 3;
    private const float MIN_DISTANCE_CAMERA = -1;
    public const float DELTA_DOLLY = 0.05f;

    private void Zoom()
    {
        if (Input.GetKey(KeyCode.X))
        {
            //キャラクターにカメラを近づけさせないための設定
            if (dollyNode.transform.localPosition.z < MAX_DISTANCE_CAMERA)
            {
                dollyNode.transform.localPosition += new Vector3(0, 0, DELTA_DOLLY);
            }
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            //キャラクターにカメラを遠ざけすぎないための設定
            if (dollyNode.transform.localPosition.z > MIN_DISTANCE_CAMERA)
            {
                dollyNode.transform.localPosition -= new Vector3(0, 0, DELTA_DOLLY);
            }
        }
    }
    */
}