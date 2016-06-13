using System;
using FightingClub.Fighters;

namespace FightingClub
{
    class Program
    {
        static void Main()
        {
            PrintMenu();
        }

        //метод рисует главное меню
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("ИГРА БОЙЦОВСКИЙ КЛУБ\n");
            Console.WriteLine("1 - начать игру");
            Console.WriteLine("2 - правила");
            Console.WriteLine("3 - выход");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Game game = new Game();
                game.StartGame();
            }

            if (option == "2")
                PrintRules();

            if (option == "3")
                return;

            //рекурсия в действии.
            //если пользователь ввел значение отличное от "3", 
            //то мы всегда заново вызываем метод PrintMenu() из самого себя
            PrintMenu();
        }

        //метод выводит на консоль правила игры
        static void PrintRules()
        {
            Console.Clear();
            Console.WriteLine("В ИГРЕ ЕСТЬ ТРИ КЛАССА БОЙЦОВ:\n");
            new Warrior().ShowStats();
            new Dodger().ShowStats();
            new Mage().ShowStats();
            Console.WriteLine("У каждого бойца есть три характеристики - сила, ловкость и выносливость. " +
                              "Сила влияет на наносимый урон, ловкость влияет на шанс увернуться от удара противника, выносливость влияет на количество очкой жизней. " +
                              "Также у каждого бойца есть особое умение, которое он использует в бою. " +
                              string.Format("Перед началом боя игроки выбирают себе бойцов и распеределяют {0} очков умений среди трех характеристик, тем самым влияя на те или иные показатели бойца. ", Constants.pointsNumber) +
                              string.Format("+1 силы = +{0} урона, +1 ловкости = +{1}% увернуться от удара, +1 живучести = +{2} HP. ", Constants.damageMultiplier, Constants.dodgeMultiplier, Constants.hpMultiplier) +
                              "Бой состоит из раундов. В каждом раунде бойцы наносят друг другу прямые повреждения и один раз используют особое умение. " +
                              "Количество раундов зависит от очков жизней бойцов. Как только у кого-нибудь из бойцов заканчиваются жизни, бой останавливается.");
            Console.ReadLine();
        }
    }
}
