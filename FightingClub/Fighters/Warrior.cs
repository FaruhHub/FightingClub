using System;

namespace FightingClub.Fighters
{
    public class Warrior : Fighter
    {
        public Warrior(string name = "имя должен выбрать игрок") : base(
            name, 
            "Безжалостный воин",
            "Ярость - Боль делает воина только сильнее. После удара воин впадает в ярость и трижды бьет противника щитом. Урон каждого удара равен показателю силы",
            5, 0, 5)
        {
            
        }

        public override int UseUltimateAbility()
        {
            int totalDamage = Strength*3;
            Console.WriteLine("{0} впадает в ярость! Он трижды бьет щитом и наносит {1} урона!", Name, totalDamage);
            return totalDamage;
        }
    }
}
