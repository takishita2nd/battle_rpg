namespace battle_rpg
{
    public class Charactor
    {
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
        public int doAttack(Charactor _target, bool critical)
        {
            int damage = this.Attack;
            if(critical == true) {
                damage = (int)(damage * 1.5);
            }
            _target.Hp -= damage;
            return damage;
        }

        /**
         * 命中判定
         * <param>  _target 攻撃対象
         * <return> true:命中
         */
        public bool isHit(Charactor _target)
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
        public bool isCritical()
        {
            bool critical = false;
            if(Common.roleJudge(this.criticalRate)) {
                critical = true;
            }
            return critical;
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
    }
}