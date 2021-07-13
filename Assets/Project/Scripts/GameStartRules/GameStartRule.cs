using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScenes.Config;

namespace GameScenes.GameStartRule
{
    public class GameStartRule : MonoBehaviour
    {
        public Text TextFrame;

        public static int numberOfMatches = GameStartRuleConfig.NUMBER_OF_MATCHES;

        public void countDownMatches()
        {
            numberOfMatches -= 1;
            if (numberOfMatches < GameStartRuleConfig.MIN_NUMBER_OF_MATCHES)
            {
                numberOfMatches = GameStartRuleConfig.MAX_NUMBER_OF_MATCHES;
            }
            TextFrame.text = numberOfMatches.ToString();
        }

        public void countUpMatches()
        {
            numberOfMatches += 1;
            if (numberOfMatches > GameStartRuleConfig.MAX_NUMBER_OF_MATCHES)
            {
                numberOfMatches = GameStartRuleConfig.MIN_NUMBER_OF_MATCHES;
            }
            TextFrame.text = numberOfMatches.ToString();
        }

    }
}
