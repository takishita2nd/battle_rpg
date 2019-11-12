using System;

namespace battle_rpg
{
    public class Battle
    {
        private Charactor yusha;
        private Charactor maou;
        private const String Statusformat = "{0}：HP{1} 攻撃力{2}";
        private const String AttackFormat = "{0}の攻撃！{1}に{2}のダメージ";
        private const String CriticalAttackFormat = "{0}の攻撃！クリティカルヒット！{1}に{2}のダメージ";
        private const String EvasionFormat = "{0}の攻撃！{1}は攻撃をかわした";
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
                int damage = 0;
                // HP表示
                Console.WriteLine(Statusformat, yusha.Name, yusha.Hp, yusha.Attack);
                Console.WriteLine(Statusformat, maou.Name, maou.Hp, maou.Attack);
                Console.WriteLine();

                // 勇者の攻撃
                if(yusha.isHit(maou)) {
                    if(yusha.isCritical()) {
                        damage = yusha.doAttack(maou, true);
                        Console.WriteLine(CriticalAttackFormat, yusha.Name, maou.Name, damage);
                    } else {
                        damage = yusha.doAttack(maou, false);
                        Console.WriteLine(AttackFormat, yusha.Name, maou.Name, damage);
                    }
                } else {
                    Console.WriteLine(EvasionFormat, yusha.Name, maou.Name);
                }

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
                if(yusha.isHit(maou)) {
                    if(yusha.isCritical()) {
                        damage = yusha.doAttack(yusha, true);
                        Console.WriteLine(CriticalAttackFormat, maou.Name, yusha.Name, damage);
                    } else {
                        damage = yusha.doAttack(yusha, false);
                        Console.WriteLine(AttackFormat, maou.Name, yusha.Name, damage);
                    }
                } else {
                    Console.WriteLine(EvasionFormat, maou.Name, yusha.Name);
                }

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