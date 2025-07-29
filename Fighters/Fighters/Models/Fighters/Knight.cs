using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Knight( string name, IArmor armor, IWeapon weapon, IRace race ) : BaseFighter( name, armor, weapon, race )
    {
        protected override int ClassHealth => 100;

        protected override int ClassDamage => 10;

        protected override double CritChance => 0.03;
    }
}