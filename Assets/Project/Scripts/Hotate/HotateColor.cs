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
                { 1, new Color()},
                { 2, new Color()},
                { 3, new Color()},
                { 4, new Color()},
            };

        // Start is called before the first frame update
        void Start()
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].color = HotateColorDict[gamepadNumber];
            transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[1].color = HotateColorDict[gamepadNumber];
        }
    }
}
