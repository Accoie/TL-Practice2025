using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Moq;

namespace Fighters.Tests.Models
{
    public class BaseFighterTests
    {
        private readonly Mock<IWeapon> _strongWeaponMock;
        private readonly Mock<IArmor> _strongArmorMock;
        private readonly Mock<IRace> _strongRaceMock;

        private readonly Mock<IWeapon> _weakWeaponMock;
        private readonly Mock<IArmor> _weakArmorMock;
        private readonly Mock<IRace> _weakRaceMock;

        private readonly BaseFighter _strongFighter;
        private readonly BaseFighter _weakFighter;

        public BaseFighterTests()
        {
            _strongWeaponMock = CreateWeaponMock( 100 );
            _strongArmorMock = CreateArmorMock( 100 );
            _strongRaceMock = CreateRaceMock( 100, 10, 10 );

            _weakWeaponMock = CreateWeaponMock( 1 );
            _weakArmorMock = CreateArmorMock( 1 );
            _weakRaceMock = CreateRaceMock( 1, 1, 1 );

            _strongFighter = new( "Strong", _strongArmorMock.Object, _strongWeaponMock.Object, _strongRaceMock.Object );
            _weakFighter = new( "Weak", _weakArmorMock.Object, _weakWeaponMock.Object, _weakRaceMock.Object );
        }

        public static Mock<IWeapon> CreateWeaponMock( int damage )
        {
            Mock<IWeapon> weaponMock = new();
            weaponMock.Setup( w => w.Damage ).Returns( damage );

            return weaponMock;
        }

        public static Mock<IArmor> CreateArmorMock( int armor )
        {
            Mock<IArmor> armorMock = new();
            armorMock.Setup( a => a.Armor ).Returns( armor );

            return armorMock;
        }

        public static Mock<IRace> CreateRaceMock( int health, int armor, int damage )
        {
            Mock<IRace> raceMock = new();

            raceMock.Setup( r => r.Health ).Returns( health );
            raceMock.Setup( r => r.Armor ).Returns( armor );
            raceMock.Setup( r => r.Damage ).Returns( damage );

            return raceMock;
        }
        [Test]
        public void BaseFighter__Create_Accepts_Empty_Name()
        {
            BaseFighter fighter = new( string.Empty, _strongArmorMock.Object, _strongWeaponMock.Object, _strongRaceMock.Object );

            Assert.That( fighter.Name, Is.EqualTo( string.Empty ) );
        }

        [Test]
        public void BaseFighter_TakeDamage_More_Than_Health_WillZero()
        {
            BaseFighter fighter = _strongFighter;
            int damage = fighter.MaxHealth + 1;

            fighter.TakeDamage( damage );

            Assert.That( fighter.Health, Is.EqualTo( 0 ) );
        }

        [Test]
        public void BaseFighter_CanWin_WeakFighter_Vs_StrongFighter_Not_Win()
        {
            bool isCanWin = _weakFighter.IsCanWin( _strongFighter );

            Assert.That( isCanWin, Is.False );
        }

        [Test]
        public void BaseFighter_Fight_Weakest_Weapon_Vs_Best_Armor_Will_No_Damage()
        {
            int damage = _weakFighter.Fight( _strongFighter );

            Assert.That( damage, Is.EqualTo( 0 ) );
        }
    }
}
