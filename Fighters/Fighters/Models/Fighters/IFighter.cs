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
        public int MaxHealth { get; }
        public int Health { get; }
        public int FullArmor { get; }
        public int ClearDamage { get; }
        public int CalculateDamage();

        public bool IsCanWin( IFighter defencer );

        public int Fight( IFighter fighter );

        public void ResetHealth();

        public void TakeDamage( int damage );
    }
}