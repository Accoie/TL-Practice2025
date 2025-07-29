using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Assasin( string name, IArmor armor, IWeapon weapon, IRace race ) : BaseFighter( name, armor, weapon, race )
    {
        protected override int ClassHealth => 10;

        protected override int ClassDamage => 30;

        protected override double CritChance => 0.06;
    }
}