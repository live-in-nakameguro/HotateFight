using Hotate.Dead;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadByFall : MonoBehaviour
{
    // �������S�������������I�u�W�F�N�g��
    [SerializeField] string GameObjectName;

    // ���S�����Y���W
    [SerializeField] float DeadPointY = -10;

    //GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
    [SerializeField] int gamepadNumber = 0;

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    private void Dead()
    {
        Vector3 tmp = GameObject.Find(GameObjectName).transform.position;
        if (tmp.y < DeadPointY)
        {
            HotateDeadController.IsHotateDeadDict[gamepadNumber] = true;
        }
    }
}
