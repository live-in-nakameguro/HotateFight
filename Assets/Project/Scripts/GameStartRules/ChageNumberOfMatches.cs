using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameStartRule
{
    public class ChageNumberOfMatches : MonoBehaviour
    {
        public Text TextFrame;

        public static int numberOfMatches = 3;

        private int maxNumberOfMatches = 99;
        private int minNumberOfMatches = 1;

        public void countDownMatches()
        {
            numberOfMatches -= 1;
            if (numberOfMatches < minNumberOfMatches)
            {
                numberOfMatches = maxNumberOfMatches;
            }
            TextFrame.text = numberOfMatches.ToString();
        }

        public void countUpMatches()
        {
            numberOfMatches += 1;
            if (numberOfMatches > maxNumberOfMatches)
            {
                numberOfMatches = minNumberOfMatches;
            }
            TextFrame.text = numberOfMatches.ToString();
        }

    }
}
