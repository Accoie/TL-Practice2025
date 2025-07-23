using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Armors;

namespace Fighters.Models.Races
{
    public class RaceGetter
    {
        public static IRace RaceFactory( Race race )
        {
            switch ( race )
            {
                case Race.human:
                    return new Human();
                case Race.orc:
                    return new Orc();
                default:
                    return new Human();
            }
        }
    }
}
