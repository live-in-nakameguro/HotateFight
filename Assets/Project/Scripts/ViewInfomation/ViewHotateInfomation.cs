using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hotate.Life;

public class ViewHotateInfomation : MonoBehaviour
{
    public Text TextFrame;

    [SerializeField] int gamepadNumber = 0;

    private void Update()
    {
        Dictionary<int, float> hotateHPDict = new Dictionary<int, float>()
            {
                { 1, HotateLife1.hotateHP},
                { 2, HotateLife2.hotateHP},
            };

        //�V�[���ɕϐ���n���邩�̃e�X�g�����邽�߂̉��̕����ł��B
        TextFrame.text = "HP: " + hotateHPDict[gamepadNumber].ToString();
    }
}
