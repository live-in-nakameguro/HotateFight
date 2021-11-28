using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotate
{
    public class HotateColor : MonoBehaviour
    {
        [SerializeField] int gamepadNumber = 0;

        public static Dictionary<int, Color> HotateColorDict = new Dictionary<int, Color>()
            {
                { 1, new Color(0,0,0,255)},
                { 2, new Color(0,0,0,255)},
                { 3, new Color(0,0,0,255)},
                { 4, new Color(0,0,0,255)},
            };

        // Start is called before the first frame update
        void Start()
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = HotateColorDict[gamepadNumber];
            transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = HotateColorDict[gamepadNumber];
        }
    }
}
