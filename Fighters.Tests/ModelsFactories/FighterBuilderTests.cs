using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.ModelsFactories;
using Moq;

namespace Fighters.Tests.ModelsFactories
{
    public class FighterBuilderTests
    {
        private readonly Mock<IWeapon> _weaponMock;
        private readonly Mock<IArmor> _armorMock;
        private readonly Mock<IRace> _raceMock;

        public FighterBuilderTests()
        {
            _weaponMock = new Mock<IWeapon>();
            _armorMock = new Mock<IArmor>();
            _raceMock = new Mock<IRace>();
        }

        [Test]
        public void Build_Fighter()
        {
            // Arrange
            string fighterName = "sdf";

            // Act
            IFighter fighterObj = CreateFighter( fighterName );

            // Assert
            Assert.That( fighterObj, Is.InstanceOf<Knight>() );
        }

        [Test]
        public void Build_FighterWithEmptyName()
        {
            // Arrange
            string emptyName = string.Empty;

            // Act
            IFighter fighterObj = CreateFighter( emptyName );

            // Assert
            Assert.That( fighterObj, Is.InstanceOf<Knight>() );
        }

        private IFighter CreateFighter( string name )
        {
            FighterBuilder builder = new();

            builder.WithName( name )
                   .WithWeapon( _weaponMock.Object )
                   .WithArmor( _armorMock.Object )
                   .WithRace( _raceMock.Object )
                   .OfType( FighterType.Knight );

            return builder.Build();
        }
    }
}