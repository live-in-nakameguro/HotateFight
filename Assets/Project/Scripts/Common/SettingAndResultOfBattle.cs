using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScenes.SettingAndResultBattle
{ 
    public class BattleSetting
    {
        private static int numberOfPlayers = 2;
        private static int numberOfWins = 3;
        private static float hotateHP = 300.0f;
        private static bool isRondom = true; // Rondom or Select
        private static bool isItemsOn = true; // ON or OFF

        public static int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set { numberOfPlayers = value; }
        }

        public static int NumberOfWins
        {
            get { return numberOfWins; }
            set { numberOfWins = value; }
        }

        public static float HotateHP
        {
            get { return hotateHP; }
            set { hotateHP = value; }
        }

        public static bool IsRondom
        {
            get { return isRondom; }
            set { isRondom = value; }
        }

        public static bool IsItemsOn
        {
            get { return isItemsOn; }
            set { isItemsOn = value; }
        }
    }

    public class RandomStageSetting
    {
        public static Dictionary<string, bool> RandomStageSettingDic = new Dictionary<string, bool>()
            {
                //ToDo ���������X�e�[�W�̓R�����g�A�E�g���O�����ƁB 
                {"IceStage", true},
                //{"MagmaStage", true},
                //{"OceanStage", true},
                //{"MeadowStage", true},
                {"UniverseStage", true},
                {"DesertStage", true},
                //{"DarkStage", true},
                //{"CityStage", true}
            };
    }

    public class ItemSetting
    {
        public enum Items
        {
            None,
            Bomb,           // ���e
            LandMines,      // �n��
            StealthMode,    // ������
        }

        // false�̎��A�X�e�[�W�ɃA�C�e����\�����Ȃ�
        public static bool UseItem = true;

        public static Dictionary<Items, bool> RandomItemSettingDic = new Dictionary<Items, bool>()
            {
                { Items.None, false},
                { Items.Bomb, true},
                { Items.LandMines, true},
                { Items.StealthMode, true},
            };

        public static Dictionary<Items, Sprite> ItemTextureDict = new Dictionary<Items, Sprite>()
            {
                { Items.None, null},
                { Items.Bomb, Resources.Load<Sprite>("Items/Textures/Bomb")},
                { Items.LandMines, Resources.Load<Sprite>("Items/Textures/LandMines")},
                { Items.StealthMode, Resources.Load<Sprite>("Items/Textures/StealthMode")},
            };

        public static Dictionary<Items, GameObject> ItemPrefabDict = new Dictionary<Items, GameObject>()
            {
                { Items.None, null},
                { Items.Bomb, Resources.Load<GameObject>("Items/Prefabs/Bomb")},
                { Items.LandMines, Resources.Load<GameObject>("Items/Prefabs/LandMines")},
                { Items.StealthMode, null},
            };

        public static Dictionary<Items, AudioClip> ItemAudioClipDict = new Dictionary<Items, AudioClip>()
            {
                { Items.None, null},
                { Items.Bomb, Resources.Load<AudioClip>("Items/AudioClip/kazuki_freekick")},
                { Items.LandMines, null},
                { Items.StealthMode, null},
            };
    }

    /* ���݂͎Q�Ƃ��Ă��Ȃ��B
     * win����ێ�����reslut��ʂɕ\������B
     */
    public class BattleResult
    {
        private static int winNumPlayer1 = 0;
        public static int WinNumPlayer1
        {
            get { return winNumPlayer1; }
            set { winNumPlayer1 = value; }
        }

        private static int winNumPlayer2 = 0;
        public static int WinNumPlayer2
        {
            get { return winNumPlayer2; }
            set { winNumPlayer2 = value; }
        }
        private static int winNumPlayer3 = 0;
        public static int WinNumPlayer3
        {
            get { return winNumPlayer3; }
            set { winNumPlayer3 = value; }
        }
        private static int winNumPlayer4 = 0;
        public static int WinNumPlayer4
        {
            get { return winNumPlayer4; }
            set { winNumPlayer4 = value; }
        }
    }
}