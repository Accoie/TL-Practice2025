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
        private readonly Mock<IWeapon> _weaponMock = new Mock<IWeapon>();
        private readonly Mock<IArmor> _armorMock = new Mock<IArmor>();
        private readonly Mock<IRace> _raceMock = new Mock<IRace>();

        [Test]
        public void CreateFighter_FighterWithEmptyName_WillCreated()
        {
            // Arrange
            string emptyName = string.Empty;

            // Act
            IFighter fighterObj = CreateFighter( emptyName );

            // Assert
            Assert.That( fighterObj, Is.InstanceOf<Knight>() );
        }

        [Test]
        public void OfType_WithKnightType_ReturnsKnightInstance()
        {
            // Arrange
            FighterBuilder builder = new FighterBuilder();

            // Act
            builder.WithName( "TestKnight" )
                   .WithWeapon( _weaponMock.Object )
                   .WithArmor( _armorMock.Object )
                   .WithRace( _raceMock.Object )
                   .OfType( FighterType.Knight );

            IFighter result = builder.Build();

            // Assert
            Assert.That( result, Is.InstanceOf<Knight>() );
            Assert.That( result.Name, Is.EqualTo( "TestKnight" ) );
        }

        [Test]
        public void OfType_WithAssasinType_ReturnsAssasinInstance()
        {
            // Arrange
            FighterBuilder builder = new();

            // Act
            builder.WithName( "TestAssasin" )
                   .WithWeapon( _weaponMock.Object )
                   .WithArmor( _armorMock.Object )
                   .WithRace( _raceMock.Object )
                   .OfType( FighterType.Assasin );

            IFighter result = builder.Build();

            // Assert
            Assert.That( result, Is.InstanceOf<Assasin>() );
            Assert.That( result.Name, Is.EqualTo( "TestAssasin" ) );
        }

        private IFighter CreateFighter( string name )
        {
            //Arrange
            FighterBuilder builder = new();

            //Act
            builder.WithName( name )
                   .WithWeapon( _weaponMock.Object )
                   .WithArmor( _armorMock.Object )
                   .WithRace( _raceMock.Object )
                   .OfType( FighterType.Knight );

            //Assert
            return builder.Build();
        }
    }
}