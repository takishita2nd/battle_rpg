using System;

namespace battle_rpg
{
    public class Battle
    {
        private Charactor yusha;
        private Charactor maou;
        private const String DieFormat = "{0}は倒れた。";
        public Battle()
        {
            yusha = new Charactor("勇者", 300, 15);
            maou = new Charactor("魔王", 400, 9);
        }

        public void execute()
        {
            bool nowBattle = true;
            while(nowBattle) {
                // HP表示
                Console.WriteLine(yusha.showStatus());
                Console.WriteLine(maou.showStatus());
                Console.WriteLine();

                // 勇者の攻撃
                Console.WriteLine(yusha.doAttack(maou));

                // 魔王死亡判定
                if(maou.isDie()) {
                    Console.WriteLine();
                    Console.WriteLine(DieFormat, maou.Name);
                    nowBattle = false;
                    Console.WriteLine("世界に平和が訪れた。");
                }

                if(nowBattle == false) {
                    return;
                }

                // 魔王の攻撃
                Console.WriteLine(maou.doAttack(yusha));

                // 勇者死亡判定
                if(yusha.isDie()) {
                    Console.WriteLine();
                    Console.WriteLine(DieFormat, yusha.Name);
                    nowBattle = false;
                    Console.WriteLine("世界は征服された。");
                }
                Console.WriteLine();
            }
        }
    } 
}