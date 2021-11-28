using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ハローワールド");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right;
    }
}
