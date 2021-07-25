using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGimmick : MonoBehaviour
{
    // ÉWÉÉÉìÉvÇÃçÇÇ≥
    [SerializeField] int JumpPower = 1000;

    void OnCollisionEnter(Collision col)
    {
        JumpObject(col);
    }

    void JumpObject(Collision col)
    {       
        if (col.gameObject.tag == "Player")
        {
            
        }
        col.rigidbody.AddForce(col.transform.up * JumpPower);
    }
}
