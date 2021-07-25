using Hotate.Dead;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadByFall : MonoBehaviour
{
    // 落下死亡判定を持たせるオブジェクト名
    [SerializeField] string GameObjectName;

    // 死亡判定のY座標
    [SerializeField] float DeadPointY = -10;

    //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
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
