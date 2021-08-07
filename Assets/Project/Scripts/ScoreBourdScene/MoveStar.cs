using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStar : MonoBehaviour
{
    [SerializeField] GameObject moveObject;
    [SerializeField] GameObject goalPoint;

    Vector3 move_Position;
    Vector3 toGoPoint;

    float moveSpeed = 1.0f; //移動速度　

    void Start()
    {
        toGoPoint = goalPoint.transform.position;      //目的地に設置したオブジェクトの座標
        move_Position = new Vector3(toGoPoint.x, toGoPoint.y, toGoPoint.z);
        moveObject.transform.position = move_Position;
    }

    void Update()
    {
        if (move_Position.x > toGoPoint.x)
        {
            move_Position.x -= moveSpeed;
            moveObject.transform.position = move_Position;
        }
    }
}
