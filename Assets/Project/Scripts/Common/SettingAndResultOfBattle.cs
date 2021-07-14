using System.Collections;
namespace GameScenes.SettingAndResultBattle
{ 
    public class BattleSetting
    {
        private static int numberOfWins = 3;
        public static void setNumberOfWins(int number) => numberOfWins = number;
        public static int getNumberOfWins() => numberOfWins;

    }

    /* 現在は参照していない。
     * win数を保持してreslut画面に表示する。
     */
    public class BattleResult
    {
        private static int winNumPlayer1 = 0;
        public static void setWinNumPlayer1(int number) => winNumPlayer1 = number;
        public static int getWinNumPlayer1() => winNumPlayer1;

        private static int winNumPlayer2 = 0;
        public static void setWinNumPlayer2(int number) => winNumPlayer2 = number;
        public static int getWinNumPlayer2() => winNumPlayer2;

        private static int winNumPlayer3 = 0;
        public static void setWinNumPlayer3(int number) => winNumPlayer3 = number;
        public static int getWinNumPlayer3() => winNumPlayer3;

        private static int winNumPlayer4 = 0;
        public static void setWinNumPlayer4(int number) => winNumPlayer4 = number;
        public static int getWinNumPlayer4() => winNumPlayer4;
    }
}