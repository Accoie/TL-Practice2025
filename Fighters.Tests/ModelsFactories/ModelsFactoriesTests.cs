using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.ModelsFactories;

namespace Fighters.Tests.ModelsFactories
{
    public class ModelsFactoriesTests
    {
        [Test]
        public void Create_Armor()
        {
            IArmor armorObj = ArmorFactory.CreateArmor( Armor.Iron );

            Assert.That( armorObj, Is.InstanceOf<Iron>() );
        }

        [Test]
        public void Create_Weapon()
        {
            IWeapon weaponObj = WeaponFactory.CreateWeapon( Weapon.LongSword );

            Assert.That( weaponObj, Is.InstanceOf<LongSword>() );
        }

        [Test]
        public void Create_Race()
        {
            IRace raceObj = RaceFactory.CreateRace( Race.Orc );

            Assert.That( raceObj, Is.InstanceOf<Orc>() );
        }

        [Test]
        public void Create_Fighter()
        {
            FighterBuilder builder = new();

            builder.WithName( "sdf" )
                   .WithWeapon( new Fists() )
                   .WithArmor( new Leather() )
                   .WithRace( new Orc() )
                   .OfType( FighterType.Knight );

            IFighter fighterObj = builder.Build();

            Assert.That( fighterObj, Is.InstanceOf<Knight>() );
        }

        public void Create_Fighter_Accept_Empty_Name()
        {
            FighterBuilder builder = new();

            builder.WithName( "" );
            builder.WithWeapon( new Fists() );
            builder.WithArmor( new Leather() );
            builder.WithRace( new Orc() );
            builder.OfType( FighterType.Knight );

            IFighter fighterObj = builder.Build();

            Assert.That( fighterObj, Is.InstanceOf<Knight>() );
        }
    }
}
