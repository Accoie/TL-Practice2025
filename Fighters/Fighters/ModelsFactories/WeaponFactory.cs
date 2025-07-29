using Fighters.Models.Weapons;

namespace Fighters.ModelsFactories
{
    public class WeaponFactory
    {
        public static IWeapon CreateWeapon( Weapon weapon )
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