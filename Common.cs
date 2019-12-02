using System;

namespace battle_rpg
{
    public static class Common
    {
        public static Random r = new Random();
        public static bool roleJudge(int rate)
        {
            bool judge = false;
            int value = r.Next(0, 100);
            if(value < rate) {
                judge = true;
            }
            return judge;
        }
    }
}