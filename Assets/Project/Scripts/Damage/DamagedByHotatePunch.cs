using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Hotate.Damage
{
    public class DamagedByHotatePunch : Damage
    {
        // SE
        [SerializeField] AudioClip sound1;
        AudioSource audioSource;

        void Start()
        {
            //Component‚ðŽæ“¾
            audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision col)
        {
            HotatePunchTriger(col);
        }

        void HotatePunchTriger(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                HotatePunchEffect(col);
            }
        }

        void HotatePunchEffect(Collision col)
        {
            audioSource.PlayOneShot(sound1);
        }

        public override void HotateMotion(Rigidbody rb, Transform transform)  //override‚ð•t—^
        {
            rb.AddForce(transform.up * 600);
        }
    }
}
