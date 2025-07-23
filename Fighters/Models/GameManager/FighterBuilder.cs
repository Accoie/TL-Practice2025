using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using static Fighters.Models.Armors.ArmorGetter;
using static Fighters.Models.Races.RaceGetter;
using static Fighters.Models.Weapons.WeaponGetter;


namespace Fighters.Models.GameManager
{
    public class FighterBuilder
    {
        private string _name = "Без имени";
        private IArmor _armor = new NoArmor();
        private IWeapon _weapon = new Fists();
        private IRace _race = new Human();
        private FighterType _type = FighterType.knight;

        public FighterBuilder WithName( string name )
        {
            _name = name;
            return this;
        }

        public FighterBuilder WithArmor( IArmor armor )
        {
            _armor = armor;
            return this;
        }

        public FighterBuilder WithWeapon( IWeapon weapon )
        {
            _weapon = weapon;
            return this;
        }

        public FighterBuilder WithRace( IRace race )
        {
            _race = race;
            return this;
        }

        public FighterBuilder OfType( FighterType type )
        {
            _type = type;
            return this;
        }

        public IFighter Build()
        {
            switch ( _type )
            {
                case FighterType.knight:
                    return new Knight( _name, _armor, _weapon, _race );
                case FighterType.assasin:
                    return new Assasin( _name, _armor, _weapon, _race );
                default:
                    throw new ArgumentException( "Unknown fighter type" );
            }
        }
    }
}