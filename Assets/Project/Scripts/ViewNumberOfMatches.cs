using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScenes.GameStartRule;

public class ViewNumberOfMatches : MonoBehaviour
{
    public Text TextFrame;

    private void Start()
    {
        //�V�[���ɕϐ���n���邩�̃e�X�g�����邽�߂̉��̕����ł��B
        TextFrame.text = "Round: " + GameStartRule.numberOfMatches.ToString();
    }
    
}
