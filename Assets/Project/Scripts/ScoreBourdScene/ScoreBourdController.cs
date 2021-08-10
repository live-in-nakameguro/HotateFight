using Gamepad.Config;
using GameScenes.SettingAndResultBattle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScoreBourdScene
{
    public class ScoreBourdController : MonoBehaviour
    {
        public static Dictionary<int, bool> IsReadyDict;

        public static Dictionary<int, int> PlayerNumberOfWins = new Dictionary<int, int>()
        {
            { 1, 0},
            { 2, 0},
            { 3, 0},
            { 4, 0},
        };

        [SerializeField] GameObject Panel_1P;
        [SerializeField] GameObject Panel_2P;
        [SerializeField] GameObject Panel_3P;
        [SerializeField] GameObject Panel_4P;

        // �V�[���ړ����邽�тɌĂ΂��B
        static ScoreBourdController()
        {
            SceneManager.sceneLoaded += Init;
        }

        private static void Init(Scene loadingScene, LoadSceneMode loadSceneMode)
        {
            IsReadyDict = new Dictionary<int, bool>()
            {
                { 1, false},
                { 2, true}, // �f�o�b�O�̍ۂ́A������true�ɂ���΁A1�l�v���C�\
                { 3, false},
                { 4, false},
            };
        }

        // Start is called before the first frame update
        void Start()
        {
            Dictionary<int, GameObject> panelDict = new Dictionary<int, GameObject>()
            {
                { 1, Panel_1P},
                { 2, Panel_2P},
                { 3, Panel_3P},
                { 4, Panel_4P},
            };

            for (int i = 1; i <= BattleSetting.NumberOfPlayers; i++)
            {
                panelDict[i].SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {
            CheckAllReady();
        }

        void CheckAllReady()
        {
            int readyNum = 0;

            for (int i = 1; i <= BattleSetting.NumberOfPlayers; i++)
            {
                if (IsReadyDict[i])
                {
                    readyNum += 1;
                }
            }

            if (readyNum == BattleSetting.NumberOfPlayers)
            {
                if (IsGameEnd())
                {
                    InitPlayerNumberOfWins();
                    // �Q�[���I���̉�����
                    SceneManager.LoadScene("TitleScene");
                }
                else
                {
                    LoadScene();
                }
            }
        }

        bool IsGameEnd()
        {
            for (int i = 1; i <= BattleSetting.NumberOfPlayers; i++)
            {
                if (PlayerNumberOfWins[i] == BattleSetting.NumberOfWins)
                {
                    return true;
                }
            }
            return false;
        }

        void InitPlayerNumberOfWins()
        {
            for (int i = 1; i <= BattleSetting.NumberOfPlayers; i++)
            {
                PlayerNumberOfWins[i] = 0;
            }
        }

        // GameStartRule��gameStartButton()�̃R�s�y�B�Q�Ƃł��Ȃ������B
        void LoadScene()
        {
            if (BattleSetting.IsRondom)
            {
                var randomStageOnList = new List<string>();
                var randomStageOffList = new List<string>();
                // �����_���X�C�b�`��ON�̃X�e�[�W�𒊏o����B
                foreach (KeyValuePair<string, bool> pair in RandomStageSetting.RandomStageSettingDic)
                {
                    if (pair.Value) randomStageOnList.Add(pair.Key);
                    else randomStageOffList.Add(pair.Key);
                }

                // �����_���X�C�b�`�����ׂ�OFF�������ꍇ�A���ׂ�ON�̏ꍇ�Ƌ�����ς��Ȃ�����B
                if (randomStageOnList.Count == 0)
                    randomStageOnList = randomStageOffList;

                //�����_���ɃX�e�[�W��I��
                string selectedRandomStage = randomStageOnList[Random.Range(0, randomStageOnList.Count)];
                Debug.Log(selectedRandomStage);
                SceneManager.LoadScene(selectedRandomStage + "Scene");
            }
            else
            {
                //�����_�����I�t�̏ꍇ�A�X�e�[�W�Z���N�g��ʂɑJ��
                SceneManager.LoadScene("StageSelectScene");
            }
        }
    }
}
