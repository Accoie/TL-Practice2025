using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class BaseFighter : IFighter
    {
        public string Name { get; private set; }
        public IRace Race { get; private set; }
        public IArmor Armor { get; private set; }
        public IWeapon Weapon { get; private set; }
        public int Health { get; private set; }
        public int FullArmor => Armor.Armor + Race.Armor;
        public int MaxHealth => Race.Health + ClassHealth;
        public int ClearDamage => Race.Damage + ClassDamage + Weapon.Damage;

        protected virtual int ClassHealth => 10;
        protected virtual int ClassDamage => 10;
        protected virtual int ClassArmor => 10;
        protected virtual double CritChance => 0.03;

        private const int _maxBonus = 10;
        private const int _minBonus = -20;
        private const double _criticalMultiplier = 2;

        public BaseFighter( string name, IArmor armor, IWeapon weapon, IRace race )
        {
            Name = name;
            Race = race;
            Armor = armor;
            Weapon = weapon;

            Health = MaxHealth;
        }

        public virtual int Fight( IFighter fighter )
        {
            int damage = Math.Max( CalculateDamage() - fighter.FullArmor, 0 );

            fighter.TakeDamage( damage );

            return damage;
        }

        public void TakeDamage( int damage )
        {
            int newHealth = Health - damage;

            if ( newHealth < 0 )
            {
                newHealth = 0;
            }

            Health = newHealth;
        }

        public void ResetHealth()
        {
            Health = MaxHealth;
        }

        public int CalculateDamage()
        {
            double calculatedDamage = ClearDamage
                * ( IsCriticalDamage( CritChance ) ? _criticalMultiplier : 1 );

            double bonusDamage = CalculateBonusDamage( calculatedDamage );

            int resultDamage = ( int )( calculatedDamage + bonusDamage );

            return resultDamage;
        }

        public bool CanWin( IFighter defencer )
        {
            const double maxBonusMultiplier = _maxBonus / 100 + 1;

            double criticalDamage = ClearDamage * _criticalMultiplier;

            int maxDamage = ( int )( criticalDamage * ( maxBonusMultiplier ) );

            return defencer.FullArmor >= maxDamage ? false : true;
        }

        private double CalculateBonusDamage( double calculatedDamage )
        {
            Random random = new();

            double bonusMultiplier = random.Next( _minBonus, _maxBonus ) / 100;
            double bonusDamage = calculatedDamage * bonusMultiplier;

            return bonusDamage;
        }

        private bool IsCriticalDamage( double critChance )
        {
            const double minRate = 0.5;

            Random random = new();
            int randomNumber = random.Next( 1, 10 );

            return critChance * randomNumber > minRate ? true : false;
        }
    }
}