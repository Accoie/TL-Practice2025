using Fighters.Models.Weapons;

namespace Fighters.ModelsFactories
{
    public class WeaponFactory
    {
        public static IWeapon CreateWeapon( Weapon weapon )
        {
            switch ( weapon )
            {
                case Weapon.Fists:
                    return new Fists();
                case Weapon.Sword:
                    return new Sword();
                case Weapon.LongSword:
                    return new LongSword();
                default:
                    return new Fists();
            }
        }
    }
}