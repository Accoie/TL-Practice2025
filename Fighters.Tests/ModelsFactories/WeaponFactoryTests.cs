using Fighters.Models.Weapons;
using Fighters.ModelsFactories;

namespace Fighters.Tests.ModelsFactories
{
    public class WeaponFactoryTests
    {
        [Test]
        public void Create_Weapon()
        {
            IWeapon weaponObj = WeaponFactory.CreateWeapon( Weapon.LongSword );

            Assert.That( weaponObj, Is.InstanceOf<LongSword>() );
        }
    }
}
