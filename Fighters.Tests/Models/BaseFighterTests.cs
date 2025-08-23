using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Moq;

namespace Fighters.Tests.Models
{
    public class BaseFighterTests
    {
        private readonly LongSword _strongWeapon = new();
        private readonly Diamond _strongArmor = new();
        private readonly Orc _strongRace = new();

        private readonly Fists _weakWeapon = new();
        private readonly NoArmor _weakArmor = new();
        private readonly Human _weakRace = new();

        private readonly BaseFighter _strongFighter;
        private readonly BaseFighter _weakFighter;

        public BaseFighterTests()
        {
            _strongFighter = new( "Strong", _strongArmor, _strongWeapon, _strongRace );
            _weakFighter = new( "Weak", _weakArmor, _weakWeapon, _weakRace );
        }

        [Test]
        public void Create_WithEmptyName_WillEqual()
        {
            // Arrange
            // (Initialization in constructor)

            // Act
            BaseFighter fighter = new( string.Empty, _strongArmor, _strongWeapon, _strongRace );

            // Assert
            Assert.That( fighter.Name, Is.EqualTo( string.Empty ) );
        }

        [Test]
        public void TakeDamage_MoreThanHealth_WillEqualZero()
        {
            // Arrange
            BaseFighter fighter = _strongFighter;
            int damage = fighter.MaxHealth + 1;

            // Act
            fighter.TakeDamage( damage );

            // Assert
            Assert.That( fighter.Health, Is.EqualTo( 0 ) );
        }

        [Test]
        public void IsCanWin_WeakFighterVsStrongFighter_WeakWillLose()
        {
            // Arrange
            // (Test data is already created in test class fields)

            // Act
            bool isCanWin = _weakFighter.IsCanWin( _strongFighter );

            // Assert
            Assert.That( isCanWin, Is.False );
        }

        [Test]
        public void Fight_WeakFighterVsStrong_DamageWillEqualZero()
        {
            // Arrange
            // (Test data is already created in test class fields)

            // Act
            int damage = _weakFighter.Fight( _strongFighter );

            // Assert
            Assert.That( damage, Is.EqualTo( 0 ) );
        }
    }
}