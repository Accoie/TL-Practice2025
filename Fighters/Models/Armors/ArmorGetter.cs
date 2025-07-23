using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Weapons;

namespace Fighters.Models.Armors
{
    public class ArmorGetter
    {

        public static IArmor ArmorFactory( Armor armor )
        {
            switch ( armor )
            {
                case Armor.noArmor:
                    return new NoArmor();
                case Armor.leather:
                    return new Leather();
                case Armor.gold:
                    return new Gold();
                case Armor.diamond:
                    return new Diamond();
                case Armor.iron:
                    return new Iron();
                default:
                    return new NoArmor();
            }

        }
    }
}
