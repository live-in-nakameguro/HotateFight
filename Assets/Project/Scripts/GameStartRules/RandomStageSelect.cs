using UnityEngine;
using GameScenes.SettingAndResultBattle;
using System.Collections.Generic;

public class RandomStageSelect : MonoBehaviour
{
    public string stageName;

    void Update()
    {
        CheckRandomStageSetting();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void CheckRandomStageSetting()
    {
        //False�̃X�e�[�W�̓O���[�A�E�g���邽�߂̎���
        if(RandomStageSetting.RandomStageSettingDic[stageName]) transform.GetChild(3).gameObject.SetActive(false);
        else transform.GetChild(3).gameObject.SetActive(true);

    }

}
