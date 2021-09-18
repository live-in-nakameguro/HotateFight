using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class SpinObject : MonoBehaviour
    {
        public static void XSpin(GameObject gameObject, float xSpeed)
        {
            Transform myTransform = gameObject.transform;
            myTransform.Rotate(xSpeed, 0, 0);
        }

        public static void YSpin(GameObject gameObject, float ySpeed)
        {
            Transform myTransform = gameObject.transform;
            myTransform.Rotate(0, ySpeed, 0);
        }

        public static void ZSpin(GameObject gameObject, float zSpeed)
        {
            Transform myTransform = gameObject.transform;
            myTransform.Rotate(0, 0, zSpeed);
        }
    }
}
