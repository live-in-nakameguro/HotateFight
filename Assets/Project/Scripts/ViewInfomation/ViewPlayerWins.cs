using ScoreBourdScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewPlayerWins : MonoBehaviour
{
    [SerializeField] int gamepadNumber = 0;

    public Text TextFrame;

    // Start is called before the first frame update
    void Start()
    {
        TextFrame.text = ScoreBourdController.PlayerNumberOfWins[gamepadNumber].ToString();
    }
}
