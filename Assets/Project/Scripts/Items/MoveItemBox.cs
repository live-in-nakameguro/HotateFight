using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Item
{
    enum MoveType
    {
        None,
        Fall,
    }

    public class MoveItemBox : MonoBehaviour
    {
        [SerializeField] MoveType moveType = MoveType.None;
        [SerializeField] float move_XSpeed = 1;
        [SerializeField] float move_YSpeed = 1;
        [SerializeField] float move_ZSpeed = 1;

        [SerializeField] bool isSpin = false;
        [SerializeField] float spin_YSpeed = 1;

        [SerializeField] bool useGroundStop = true;
        private bool isGround = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isGround)
            {
                return;
            }

            Move();

            if (isSpin)
            {
                SpinObject.YSpin(this.gameObject, spin_YSpeed);
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (useGroundStop)
            {
                IsEnterGround(other);
            }
        }

        private void IsEnterGround(Collider other)
        {
            if (other.gameObject.tag.Contains("Ground"))
            {
                isGround = true;
            }
        }

        private void Move()
        {
            switch (moveType)
            {
                case MoveType.None:
                    break;
                case MoveType.Fall:
                    Fall();
                    break;
                default:
                    break;
            }
        }

        private void Fall()
        {
            transform.Translate(0, -move_YSpeed, 0);
        }
    }
}
