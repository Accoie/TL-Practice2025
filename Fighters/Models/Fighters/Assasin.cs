using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Assasin( string name, IArmor armor, IWeapon weapon, IRace race ) : BaseFighter( name, armor, weapon, race )
    {

        private readonly int _classHealth = 50;
        private readonly int _classDamage = 10;
        private readonly double _critChance = 0.1;

        public override int GetMaxHealth()
        {
            return _race.Health + _classHealth;
        }

        public override int CalculateDamage()
        {
            double calculatedDamage = ( _race.Damage + _classDamage + _weapon.Damage )
                * ( IsCriticalDamage( _critChance ) ? _criticalMultiplier : 1 );
            Random random = new Random();

            double bonusMultiplier = random.NextDouble() * 0.3 - 0.2;
            double bonusDamage = calculatedDamage * bonusMultiplier;

            int resultDamage = ( int )( calculatedDamage + bonusDamage );

            return resultDamage;
        }
    }
}
