using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScenes.SettingAndResultBattle;

namespace Item
{
    enum FigureType
    {
        Square,
        Circle,
    }

    public class CreateItemBox : MonoBehaviour
    {
        // ItemBoxを生成する範囲の図形
        [SerializeField] FigureType figureType;

        // 四角形の左下の座標
        [SerializeField] Vector3 squareLowerLeftPoint;
        // 四角形の右上の座標
        [SerializeField] Vector3 squareRightUpperPoint;

        // 円の中心
        [SerializeField] Vector3 circlePoint;
        // 半径
        [SerializeField] float radius;

        // ItemBoxを生成する高さ（Y座標）
        [SerializeField] float height;

        // InvokeでCreateを処理待ちしていることを判断するフラグ
        private bool isCreateInvoke = false;
        // ItemBoxを生成をする時間間隔
        [SerializeField] float createIntervalTime = 10.0f;
        // ItemBoxを一度に生成する個数
        [SerializeField] int createNum = 2;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!isCreateInvoke) {
                isCreateInvoke = true;
                Invoke(nameof(Create), createIntervalTime);
            }
        }

        void Create()
        {
            if (!ItemSetting.UseItem)
            {
                return;
            }

            GameObject itemBoxObject = Resources.Load<GameObject>("Items/Prefabs/ItemBox_Fall");
            for (int i = 0; i < createNum; i++) {
                Vector3 position = GetPosition();
                // ItemBoxの複製
                GameObject itemBox = Instantiate(itemBoxObject, position, new Quaternion(0, 0, 0, 0)) as GameObject;
            }

            isCreateInvoke = false;
        }

        private Vector3 GetPosition()
        {
            Vector3 position = new Vector3(0, 0, 0);
            switch (figureType)
            {
                case FigureType.Square:
                    position = GetPositionBySquare();
                    break;
                case FigureType.Circle:
                    position = GetPositionByCircle();
                    break;
                default:
                    break;
            }
            return position;
        }

        private Vector3 GetPositionBySquare()
        {
            float x = Random.Range(squareLowerLeftPoint.x, squareRightUpperPoint.x);
            float z = Random.Range(squareLowerLeftPoint.z, squareRightUpperPoint.z);
            return new Vector3(x, height, z);
        }

        private Vector3 GetPositionByCircle()
        {
            float deg = Random.Range(1.0f, 360.0f);
            // 角度からラジアン値に変換している。
            float angle = deg * Mathf.Deg2Rad;
            // 倍率をランダムにしないと、円周にのみItemboxが生成されてしまうための対応
            float magnification = Random.Range(0.0f, 1.0f);

            float x = radius * Mathf.Cos(angle) * magnification + circlePoint.x;
            float z = radius * Mathf.Sin(angle) * magnification + circlePoint.z;
            return new Vector3(x, height, z);
        }
    }
}
