using System.Collections;
namespace GameScenes.SettingAndResultBattle
{ 
    public class BattleSetting
    {
        private static int numberOfWins = 3;
        private static float hotateHP = 100.0f;

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

    }

    /* 現在は参照していない。
     * win数を保持してreslut画面に表示する。
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