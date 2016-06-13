using System;

namespace FightingClub.Fighters
{
    //класс определяет общую базовую сущность "Боец"
    public abstract class Fighter
    {
        protected Random random; //генератор случайных чисел

        public delegate void IsDeadDelegate();
        public event IsDeadDelegate IsDead; //событие "Боец мертв"

        public string Name { get; private set; }
        public string ClassDescription { get; private set; }
        public string UltimateAbilityDescription { get; private set; }

        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                Damage = value*Constants.damageMultiplier;
            }
        }
        public int Damage { get; private set; }

        private int agility;
        public int Agility
        {
            get { return agility; }
            set
            {
                agility = value;
                DodgeChance = value*Constants.dodgeMultiplier;
            }
        }
        public int DodgeChance { get; private set; }

        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                HP = value*Constants.hpMultiplier;
            }
        }

        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp < 0)
                {
                    hp = 0;
                    IsDead();
                }
            }
        }

        //конструктор
        protected Fighter(string name, string classDescription, string ultimateAbilityDescription, int strength, int agility, int vitality)
        {
            random = new Random();
            Name = name;
            ClassDescription = classDescription;
            UltimateAbilityDescription = ultimateAbilityDescription;
            Strength = strength;
            Agility = agility;
            Vitality = vitality;
        }

        //метод рассчитывает кол-во нанесенного урона
        public int Kick()
        {
            int totalDamage = random.Next(Damage - Constants.damageVariety, Damage + Constants.damageVariety + 1);
            Console.WriteLine("{0} ударил и нанес {1} урона!", Name, totalDamage);
            return totalDamage;
        }

        //абстрактный метод "Использовать особое умение".
        //должен быть переопределен в классах-наследниках
        public abstract int UseUltimateAbility();

        //метод выводит на консоль информацию о бойце
        public virtual void ShowStats()
        {
            Console.WriteLine("Имя: {0}\nКласс: {1}\nСила: {2}\t\tЛовкость: {3}\t\tЖивучесть: {4}\nУрон: {5}\tШанс увернуться: {6}%\tHP: {7}\nУмение: {8}", Name, ClassDescription, Strength, Agility, Vitality, Damage, DodgeChance, HP, UltimateAbilityDescription);
            Console.WriteLine();
        }
    }
}
