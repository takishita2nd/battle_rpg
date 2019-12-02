using System;

namespace battle_rpg
{
    public class Charactor
    {
        private const String StatusFormat = "{0}：HP{1} 攻撃力{2}";
        private const String AttackFormat = "{0}の攻撃！{1}に{2}のダメージ";
        private const String CriticalAttackFormat = "{0}の攻撃！クリティカルヒット！{1}に{2}のダメージ";
        private const String EvasionFormat = "{0}の攻撃！{1}は攻撃をかわした";
        public string Name {get;}
        public int Hp {get; set;}
        public int Attack {get;}
        public int evasionRate { get;}
        public int criticalRate { get;}

        public Charactor(string _name, int _hp, int _attack)
        {
            this.Name = _name;
            this.Hp = _hp;
            this.Attack = _attack;
            this.evasionRate = 5;
            this.criticalRate = 5;
        }

        /**
         * ターゲットを攻撃
         * <param>  _target 攻撃対象
         * <return> 与えたダメージ
         */
        public String doAttack(Charactor _target)
        {
            String message = String.Empty;
            if(isHit(_target)) {
                int damage = this.Attack;
                if(isCritical()) {
                    damage = (int)(damage * 1.5);
                    message = String.Format(CriticalAttackFormat, this.Name, _target.Name, damage);
                } else {
                    message = String.Format(AttackFormat, this.Name, _target.Name, damage);
                }
                _target.Hp -= damage;
            } else {
                message = String.Format(EvasionFormat, this.Name, _target.Name);
            }

            return message;
        }

        /**
         * 命中判定
         * <param>  _target 攻撃対象
         * <return> true:命中
         */
        private bool isHit(Charactor _target)
        {
            bool hit = true;
            if(Common.roleJudge(_target.evasionRate)) {
                hit = false;
            }
            return hit;
        }

        /**
         * クリティカル判定
         * <return> true:クリティカル
         */
        private bool isCritical()
        {
            return Common.roleJudge(this.criticalRate);
        }

        /**
         * 死亡判定
         * <return> true:死亡
         */
        public bool isDie()
        {
            bool die = false;
            if(this.Hp <= 0) {
                die = true;
            }
            return die;
        }

        public String showStatus()
        {
            return String.Format(StatusFormat, this.Name, this.Hp, this.Attack);
        }
    }
}