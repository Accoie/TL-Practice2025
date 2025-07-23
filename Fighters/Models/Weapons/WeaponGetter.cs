using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Weapons
{
    public class WeaponGetter
    {

        public static IWeapon WeaponFactory( Weapon weapon )
        {
            switch ( weapon )
            {
                case Weapon.fists:
                    return new Fists();
                case Weapon.sword:
                    return new Sword();
                case Weapon.longSword:
                    return new LongSword();
                default:
                    return new Fists();
            }

        }
    }
}
