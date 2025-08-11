using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.ModelsFactories;
using Moq;

namespace Fighters.Tests.ModelsFactories
{
    public class ModelsFactoriesTests
    {
        private readonly Mock<IWeapon> _weaponMock;
        private readonly Mock<IArmor> _armorMock;
        private readonly Mock<IRace> _raceMock;

        public ModelsFactoriesTests()
        {
            _weaponMock = new Mock<IWeapon>();
            _armorMock = new Mock<IArmor>();
            _raceMock = new Mock<IRace>();
        }

        [Test]
        public void Build_Fighter()
        {
            FighterBuilder builder = new();

            builder.WithName( "sdf" )
                   .WithWeapon( _weaponMock.Object )
                   .WithArmor( _armorMock.Object )
                   .WithRace( _raceMock.Object )
                   .OfType( FighterType.Knight );

            IFighter fighterObj = builder.Build();

            Assert.That( fighterObj, Is.InstanceOf<Knight>() );
        }

        public void Create_Fighter_Accept_Empty_Name()
        {
            FighterBuilder builder = new();

            builder.WithName( string.Empty )
                   .WithWeapon( _weaponMock.Object )
                   .WithArmor( _armorMock.Object )
                   .WithRace( _raceMock.Object )
                   .OfType( FighterType.Knight );

            IFighter fighterObj = builder.Build();

            Assert.That( fighterObj, Is.InstanceOf<Knight>() );
        }
    }
}