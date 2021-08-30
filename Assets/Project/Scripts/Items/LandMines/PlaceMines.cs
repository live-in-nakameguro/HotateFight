using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class PlaceMines : MonoBehaviour
    {
        public static void Place(GameObject hotate, GameObject mine, Transform muzzle)
        {
            // AudioSource‚ªstatic‚Å‚È‚¢‚½‚ßA‰¹‚ğ‚±‚±‚Åo‚·‚±‚Æ‚ª‚Å‚«‚È‚¢B

            // ”š’e‚Ì•¡»
            GameObject bombs = Instantiate(mine, muzzle.position + muzzle.transform.forward * 5, muzzle.rotation) as GameObject;
        }
    }
}
