using System;

namespace FightingClub.Fighters
{
    public class Dodger : Fighter
    {
        public Dodger(string name = "имя должен выбрать игрок")
            : base(
            name, 
            "Изворотливый ловкач",
            "Ловкость рук - Есть 25% шанс запутать противника и незаметно ударить второй рукой. Такой удар считается критическим попаданием (x3)",
            3, 4, 3)
        {
            
        }

        public override int UseUltimateAbility()
        {
            int chance = random.Next(1, 101);
            if (chance <= 25)
            {
                int totalDamage = Damage*3;
                Console.WriteLine("{0} изловчился и ударил второй рукой! Этот удар оказался критическим и нанес {1} урона!", Name, totalDamage);
                return totalDamage;
            }
            Console.WriteLine("{0} попытался незаметно ударить второй рукой, но противник это заметил и увернулся!", Name);
            return 0;
        }
    }
}
