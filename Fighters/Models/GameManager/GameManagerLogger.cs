using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Fighters;

namespace Fighters.Models.GameManager
{
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

    }
}
