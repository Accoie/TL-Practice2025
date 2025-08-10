using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Tests.Models
{
    public class FighterTests
    {
        [Test]
        public void BaseFighter__Create_Accepts_Empty_Name()
        {
            BaseFighter fighter = new( "", new Leather(), new Fists(), new Orc() );

            Assert.That( fighter.Name, Is.EqualTo( "" ) );
        }

        [Test]
        public void BaseFighter_TakeDamage_More_Than_Health_WillZero()
        {
            BaseFighter fighter = new( "fighter", new Leather(), new Fists(), new Orc() );
            int damage = fighter.MaxHealth + 1;

            fighter.TakeDamage( damage );

            Assert.That( fighter.Health, Is.EqualTo( 0 ) );
        }

        [Test]
        public void BaseFighter_CanWin_Weakest_Weapon_Vs_Best_Armor_Not_Win()
        {
            BaseFighter fighterBestArmor = new( "fighter", new Diamond(), new Fists(), new Orc() );
            BaseFighter fighterWeakest = new( "fighter", new Leather(), new Fists(), new Orc() );

            bool isCanWin = fighterWeakest.IsCanWin( fighterBestArmor );

            Assert.That( isCanWin, Is.False );
        }

        [Test]
        public void BaseFighter_Fight_Weakest_Weapon_Vs_Best_Armor_Will_No_Damage()
        {
            BaseFighter fighterBestArmor = new( "fighter", new Diamond(), new Fists(), new Orc() );
            BaseFighter fighterWeakest = new( "fighter", new Leather(), new Fists(), new Orc() );

            int damage = fighterWeakest.Fight( fighterBestArmor );

            Assert.That( damage, Is.EqualTo( 0 ) );
        }
    }
}
