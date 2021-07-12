using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameStartRule;

public class ViewNumberOfMatches : MonoBehaviour
{
    public Text TextFrame;

    private void Start()
    {
        TextFrame.text = "Round: " + ChageNumberOfMatches.numberOfMatches.ToString();
    }
    
}
