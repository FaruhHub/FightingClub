using System;
using FightingClub.Fighters;

namespace FightingClub
{
    //в этом классе определена логика игры
    public class Game
    {
        private Random random;
        private FightState fightState;

        private Fighter player1;
        private Fighter player2;

        //конструктор
        public Game()
        {
            random = new Random();
            fightState = FightState.NextRound;
        }

        //метод, в котором начинается игра
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("ИГРОК 1 СОЗДАЕТ БОЙЦА:");
            player1 = CreateFighter();
            Console.Clear();
            Console.WriteLine("ИГРОК 2 СОЗДАЕТ БОЙЦА:");
            player2 = CreateFighter();
            Console.Clear();
            StartFight();
        }

        //в этом методе создается новый боец
        private Fighter CreateFighter()
        {
            Fighter fighter;
            int points = Constants.pointsNumber;

            Console.WriteLine("Назовите своего бойца:");
            string name = Console.ReadLine();

            Console.WriteLine("\nВыберите класс героя:\n1: Воин\n2: Ловкач\n3: Маг");
            string fighterType = Console.ReadLine();
            switch (fighterType)
            {
                case "1":
                    fighter = new Warrior(name);
                    break;
                case "2":
                    fighter = new Dodger(name);
                    break;
                default:
                    fighter = new Mage(name);
                    break;
            }

            while (points > 0)
            {
                Console.Clear();
                fighter.ShowStats();
                Console.WriteLine("Распределите очки умений среди характеристик персонажа:");
                Console.WriteLine("+1 Силы:      +{0} к урону", Constants.damageMultiplier);
                Console.WriteLine("+1 Ловкости:  +{0}% увернуться от атаки", Constants.dodgeMultiplier);
                Console.WriteLine("+1 Живучести: +{0} HP", Constants.hpMultiplier);
                Console.WriteLine();
                Console.WriteLine("Осталось очков умений: {0}", points);
                Console.WriteLine("1: +1 Силы");
                Console.WriteLine("2: +1 Ловкости");
                Console.WriteLine("3: +1 Живучести");
                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strength += 1;
                        break;
                    case "2":
                        fighter.Agility += 1;
                        break;
                    default:
                        fighter.Vitality += 1;
                        break;
                }
                points -= 1;
            }
            fighter.IsDead += () => fightState = FightState.Stop;
            return fighter;
        }

        //в этом методе реализована логика битвы
        private void StartFight()
        {
            //отсчет начала битвы
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine("{0}...", i);
                Console.ReadLine();
            }

            int round = 1;
            while (fightState == FightState.NextRound)
            {
                Console.Clear();
                Console.WriteLine("РАУНД {0}", round);
                
                CalculateKick(player1, player2);
                CalculateKick(player2, player1);

                Console.WriteLine();
                Console.WriteLine("ИГРОК 1:");
                player1.ShowStats();
                Console.WriteLine();
                Console.WriteLine("ИГРОК 2:");
                player2.ShowStats();

                Console.ReadLine();
                round += 1;
            }
            Console.WriteLine("БОЙ ОКОНЧЕН!");
            Console.ReadLine();
        }

        //в этом методе расчитывается удар
        private void CalculateKick(Fighter agressor, Fighter victim)
        {
            if (victim.DodgeChance > random.Next(1, 101))
            {
                Console.WriteLine("{0} хотел ударить, но противник увернулся от удара!", agressor.Name);
            }
            else
            {
                victim.HP -= agressor.Kick();
                victim.HP -= agressor.UseUltimateAbility();
            }
        }
    }
}
