using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotate.Dead
{
    public class HotateDeadController : MonoBehaviour
    {
        // TODO �v���C���[�̐l����ݒ肷��
        [SerializeField] int PlayerNum = 2;

        public static Dictionary<int, bool> IsHotateDeadDict;

        // �V�[���ړ����邽�тɌĂ΂��B
        static HotateDeadController()
        {
            SceneManager.sceneLoaded += Init;
        }

        private static void Init(Scene loadingScene, LoadSceneMode loadSceneMode)
        {
            IsHotateDeadDict = new Dictionary<int, bool>()
            {
                { 1, false},
                { 2, false},
                { 3, false},
                { 4, false},
            };
        }

        void Update()
        {
            DeadCheck();
        }

        private void DeadCheck()
        {
            int deadNum = 0;

            for (int i = 1; i <= PlayerNum; i++)
            {
                if (IsHotateDeadDict[i])
                {
                    deadNum += 1;
                }
            }

            // 1�l���������c�����ꍇ
            if (deadNum == PlayerNum - 1)
            {
                // TODO �r�����щ�ʂ�\������B

                // ���̏���
                SceneManager.LoadScene("TitleScene");
            }

            // ���ł��ɂȂ����ꍇ
            if (deadNum == PlayerNum)
            {
                // TODO �ǂ�����H
            }
        }
    }
}
