using UnityEngine;
using System;

public class CameraMotion : MonoBehaviour
{

    public Transform horizontalRotNode;
    public Transform verticalRotNode;
    public Transform dollyNode;

    public const float DELTA_ANGLE = 1.0f;
    public const float DELTA_DOLLY = 0.05f;

    // ToDo 設定画面等を作成して自由にいじれるようにする 
    public const float HORIZONTAL_CAMERA_SPEED = 3;

    private float count_to_restore_default_camera_position = 0;
    private const float FRAME_TO_RESTORE_DEFAULT_CAMERA_POSITION = 150;

    private const float MAX_DISTANCE_CAMERA = 3;
    private const float MIN_DISTANCE_CAMERA = -1;

    void Update()
    {
        HorizontalMotion();
        VerticalMotion();
        Zoom();
    }

    // 水平方向の回転
    // あてはめてるキーは暫定対応
    private void HorizontalMotion()
    {
        float horizontalAngle = horizontalRotNode.localRotation.eulerAngles.y;

        if (Input.GetKey(KeyCode.U))
        {
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + HORIZONTAL_CAMERA_SPEED * DELTA_ANGLE, 0));
            return;
        }
        else if (Input.GetKey(KeyCode.I))
        {
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - HORIZONTAL_CAMERA_SPEED * DELTA_ANGLE, 0));
            return;
        }
        //カメラリセットボタンの追加
        else if (Input.GetKey(KeyCode.Y))
        {
            horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            return;
        }
        //一定のフレーム処理後( FRAME_TO_RESTORE_DEFAULT_CAMERA_POSITION )ポジションをもとに戻す。
        //なくてもいい気がしたのでコメントアウト→代わりにカメラリセットボタンを実装
        //if (count_to_restore_default_camera_position < FRAME_TO_RESTORE_DEFAULT_CAMERA_POSITION)
        //{
        //    count_to_restore_default_camera_position += 1;
        //    return;
        //}

            //if (0 < horizontalAngle && horizontalAngle < 180)
            //{
            //    horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle - 5 * DELTA_ANGLE, 0));
            //}
            //else if (180 < horizontalAngle && horizontalAngle < 360)
            //{
            //    horizontalRotNode.localRotation = Quaternion.Euler(new Vector3(0, horizontalAngle + 5 * DELTA_ANGLE, 0));
            //}
            //else
            //{
            //    count_to_restore_default_camera_position = 0;
            //}
    }

    //上下の回転
    // あてはめてるキーは暫定対応
    private void VerticalMotion()
    {
        float verticalAngle = verticalRotNode.rotation.eulerAngles.x;

        if (Input.GetKey(KeyCode.O))
        {
            if (verticalAngle <= 10 || verticalAngle >= 340)
            {
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(verticalAngle + DELTA_ANGLE, 0, 0));
            }
            else
            {
                //画面を動かしすぎた時にガタガタさせるための設定 他にいい方法あるかも
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(5, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.P))
        {
            if (verticalAngle <= 10 || verticalAngle >= 340)
            {
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(verticalAngle - DELTA_ANGLE, 0, 0));
            }
            else
            {
                //画面を動かしすぎた時にガタガタさせるための設定 他にいい方法あるかも
                verticalRotNode.localRotation = Quaternion.Euler(new Vector3(345, 0, 0));
            }
        }
    }

    //拡大縮小
    private void Zoom()
    {
        if (Input.GetKey(KeyCode.X))
        {
            //キャラクターにカメラを近づけさせないための設定
            if ( dollyNode.transform.localPosition.z < MAX_DISTANCE_CAMERA)
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
}