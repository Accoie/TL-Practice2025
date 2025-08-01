using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public interface IFighter
    {
        string Name { get; }
        public IRace Race { get; }
        public IArmor Armor { get; }
        public IWeapon Weapon { get; }

        public int GetCurrentHealth();
        public int GetMaxHealth();

        public int CalculateDamage();
        public int CalculateArmor();

        public bool CanWin( IFighter defencer );

        public int Fight( IFighter fighter );

        public void ResetHealth();

        public void TakeDamage( int damage );
    }
}