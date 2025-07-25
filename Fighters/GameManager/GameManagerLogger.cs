using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Fighters;

namespace Fighters.GameManager
{
    public class FightLog( string damagerName, string defencerName, int damage, int healthCurrent )
    {
        public string DamagerName => damagerName;
        public string DefencerName => defencerName;
        public int Damage => damage;
        public int HealthCurrent => healthCurrent;
    }
    public class GameManagerLogger
    {
        public static void ShowFighters( in List<IFighter> fighters )
        {
            Console.WriteLine( "Список бойцов:" );
            foreach ( var fighter in fighters )
            {
                int count = 1;
                Console.WriteLine( $"{count++}. {fighter.Name}" );
            }
        }

        public static void PrintFightLogs( FightLog logs )
        {
            Console.WriteLine( $"{logs.DamagerName} нанес {logs.DefencerName} {logs.Damage} урона, оставив {logs.HealthCurrent} здоровья" );
        }

    }
}
