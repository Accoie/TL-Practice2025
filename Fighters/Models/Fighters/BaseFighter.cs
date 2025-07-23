using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class BaseFighter : IFighter
    {

        protected readonly IRace _race;
        protected IArmor _armor;
        protected IWeapon _weapon;

        protected int _currentHealth;
        protected double _criticalMultiplier = 2;
        public string Name { get; private set; }

        public BaseFighter( string name, IArmor armor, IWeapon weapon, IRace race )
        {
            Name = name;
            _race = race;
            _armor = armor;
            _weapon = weapon;

            _currentHealth = GetMaxHealth();
        }
        public virtual int Fight( IFighter fighter )
        {
            int damage = CalculateDamage() - fighter.CalculateArmor();
            fighter.TakeDamage( damage );

            return damage;
        }
        public int GetCurrentHealth() => _currentHealth;

        public virtual int GetMaxHealth() => _race.Health;

        public virtual int CalculateDamage() => _weapon.Damage + _race.Damage;

        public int CalculateArmor() => _armor.Armor + _race.Armor;

        public void SetArmor( IArmor armor )
        {
            _armor = armor;
        }

        public void SetWeapon( IWeapon weapon )
        {
            _weapon = weapon;
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
        // кол-во повторений превышает 20 это оишбка(1), вернуть назад информацию определенную, завершится ли у нас когда нибудь бой или нет(решение зацикленности).
        // сделать инициативу(бросок костей, у кого больше вывпало тот и ходит)
        protected bool IsCriticalDamage( double critChance )
        {
            const double minRate = 0.5;

            Random random = new Random();
            int randomNumber = random.Next( 1, 10 );

            return critChance * randomNumber > minRate ? true : false;
        }
    }
}
