using UnityEngine;
using System;
using Gamepad.Config;

public class CameraGamePadMove: MonoBehaviour
{

    [SerializeField] Transform horizontalRotNode;
    [SerializeField] Transform verticalRotNode;
    [SerializeField] Transform dollyNode;

    void Update()
    {
        HorizontalMotion();
        VerticalMotion();
        //ズーム用の関数:コメントアウト理由はメソッド定義を参照
        //Zoom();
    }

    // 水平方向の回転
    private void HorizontalMotion()
    {
        float horizontalAngle = horizontalRotNode.localRotation.eulerAngles.y;

        if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) <= (GamepadButtonConfig.RIGHT_STICK_HORI_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_SPEED, 0));

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) >= (GamepadButtonConfig.RIGHT_STICK_HORI_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_HORI) <= (GamepadButtonConfig.RIGHT_STICK_HORI_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - GamepadCameraConfig.HORIZONTAL_CAMERA_LOW_SPEED, 0));
        
        else if (Input.GetKeyDown(GamepadButtonConfig.BUTTON_R3))
            //カメラリセット
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
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

        if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, true);

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.FAST_VALUE_FOR_STICK))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_SPEED, false);

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) >= (GamepadButtonConfig.RIGHT_STICK_VER_MAX * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
            UpOrDown(GamepadCameraConfig.VERTICAL_CAMERA_LOW_SPEED, true);

        else if (Input.GetAxis(GamepadButtonConfig.RIGHT_STICK_VER) <= (GamepadButtonConfig.RIGHT_STICK_VER_MIN * GamepadButtonConfig.SLOW_VALUE_FOR_STICK))
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