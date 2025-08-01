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

        protected virtual int ClassHealth => 10;

        protected virtual int ClassDamage => 10;

        protected virtual int ClassArmor => 10;

        protected virtual double CritChance => 0.03;

        protected int _currentHealth;

        private const int _maxBonus = 10;
        private const int _minBonus = -20;
        private const double _criticalMultiplier = 2;

        public BaseFighter( string name, IArmor armor, IWeapon weapon, IRace race )
        {
            Name = name;
            Race = race;
            Armor = armor;
            Weapon = weapon;
            _currentHealth = GetMaxHealth();
        }

        public virtual int Fight( IFighter fighter )
        {
            int damage = Math.Max( CalculateDamage() - fighter.CalculateArmor(), 0 );

            fighter.TakeDamage( damage );

            return damage;
        }

        public void TakeDamage( int damage )
        {
            int newHealth = _currentHealth - damage;

            if ( newHealth < 0 )
            {
                newHealth = 0;
            }

            _currentHealth = newHealth;
        }

        public void ResetHealth()
        {
            _currentHealth = GetMaxHealth();
        }

        public int GetCurrentHealth() => _currentHealth;

        public virtual int GetMaxHealth() => Race.Health + ClassHealth;

        public virtual int CalculateDamage()
        {
            double calculatedDamage = GetClearDamage()
                * ( IsCriticalDamage( CritChance ) ? _criticalMultiplier : 1 );

            double bonusDamage = CalculateBonusDamage( calculatedDamage );

            int resultDamage = ( int )( calculatedDamage + bonusDamage );

            return resultDamage;
        }

        public int CalculateArmor() => Armor.Armor + Race.Armor;

        public bool CanWin( IFighter defencer )
        {
            const double maxBonusMultiplier = _maxBonus / 100 + 1;

            double criticalDamage = GetClearDamage() * _criticalMultiplier;

            int maxDamage = ( int )( criticalDamage * ( maxBonusMultiplier ) );

            return defencer.CalculateArmor() >= maxDamage ? false : true;
        }

        private int GetClearDamage() => Race.Damage + ClassDamage + Weapon.Damage;

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