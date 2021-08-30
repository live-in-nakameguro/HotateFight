using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotate.Damage.Items
{
    public class DamagedByBomb : Damage
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void HotateMotion(Rigidbody rb, Transform transform)  //override‚ð•t—^
        {
            rb.AddForce(transform.up * 900);
        }
    }
}
