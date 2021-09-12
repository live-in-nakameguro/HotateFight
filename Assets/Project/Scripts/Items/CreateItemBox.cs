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
        // ItemBox�𐶐�����͈͂̐}�`
        [SerializeField] FigureType figureType;

        // �l�p�`�̍����̍��W
        [SerializeField] Vector3 squareLowerLeftPoint;
        // �l�p�`�̉E��̍��W
        [SerializeField] Vector3 squareRightUpperPoint;

        // �~�̒��S
        [SerializeField] Vector3 circlePoint;
        // ���a
        [SerializeField] float radius;

        // ItemBox�𐶐����鍂���iY���W�j
        [SerializeField] float height;

        // Invoke��Create�������҂����Ă��邱�Ƃ𔻒f����t���O
        private bool isCreateInvoke = false;
        // ItemBox�𐶐������鎞�ԊԊu
        [SerializeField] float createIntervalTime = 10.0f;
        // ItemBox����x�ɐ��������
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
                // ItemBox�̕���
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
            // �p�x���烉�W�A���l�ɕϊ����Ă���B
            float angle = deg * Mathf.Deg2Rad;
            // �{���������_���ɂ��Ȃ��ƁA�~���ɂ̂�Itembox����������Ă��܂����߂̑Ή�
            float magnification = Random.Range(0.0f, 1.0f);

            float x = radius * Mathf.Cos(angle) * magnification + circlePoint.x;
            float z = radius * Mathf.Sin(angle) * magnification + circlePoint.z;
            return new Vector3(x, height, z);
        }
    }
}
