using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.ModelsFactories;

namespace Fighters.GameManager
{
    public class ConsoleUserInput
    {
        public static string? ReadRemovedFighterName()
        {
            GameManagerOutput.PrintEnterRemovedFighterOrCancel();

            ConsoleKeyInfo keyInfo = Console.ReadKey( intercept: true );

            if ( keyInfo.Key == ConsoleKey.Escape )
            {
                return null;
            }

            return Console.ReadLine();
        }

        public static Command ReadUserCommand()
        {
            Command? command = null;

            while ( !command.HasValue )
            {
                GameManagerOutput.PrintCommandMenu();

                GameManagerOutput.PrintEnterCommand();

                string commandStr = Console.ReadLine() ?? string.Empty;

                if ( string.IsNullOrEmpty( commandStr ) )
                {
                    GameManagerOutput.PrintCommandNotEmpty();
                    continue;
                }

                command = TryParseCommand( commandStr );

                if ( !command.HasValue )
                {
                    GameManagerOutput.PrintCommandNotSupported( commandStr );
                }
            }

            return command.Value;
        }

        private static Command? TryParseCommand( string commandStr )
        {
            if ( !Enum.TryParse( commandStr, ignoreCase: true, out Command command ) )
            {
                return null;
            }

            return command;
        }

        public static IFighter ReadFighterData()
        {
            FighterBuilder _builder = new FighterBuilder();

            string name = ReadName();

            IWeapon weapon = ReadWeapon();

            IArmor armor = ReadArmor();

            IRace race = ReadRace();

            FighterType type = ReadFighterType();

            return _builder
                    .WithName( name )
                    .WithArmor( armor )
                    .WithWeapon( weapon )
                    .WithRace( race )
                    .OfType( type )
                    .Build();
        }

        private static string ReadName()
        {
            string name = string.Empty;

            while ( string.IsNullOrEmpty( name ) )
            {
                GameManagerOutput.PrintEnterFighterName();

                name = Console.ReadLine() ?? string.Empty;

                if ( string.IsNullOrEmpty( name ) )
                {
                    GameManagerOutput.PrintNameNotEmpty();
                }
            }

            return name;
        }

        private static IWeapon ReadWeapon()
        {
            GameManagerOutput.PrintWeaponMenu();

            Weapon weapon = Weapon.fists;

            bool isParsed = false;

            while ( !isParsed )
            {
                GameManagerOutput.PrintEnterWeaponName();

                string weaponStr = Console.ReadLine() ?? string.Empty;

                isParsed = Enum.TryParse( weaponStr, ignoreCase: true, out weapon );

                if ( !isParsed )
                {
                    GameManagerOutput.PrintBadWeaponName();
                }
            }

            return WeaponFactory.CreateWeapon( weapon ); ;
        }

        private static IArmor ReadArmor()
        {
            GameManagerOutput.PrintArmorMenu();

            Armor armor = Armor.noArmor;

            bool isParsed = false;

            while ( !isParsed )
            {
                GameManagerOutput.PrintEnterArmorName();

                string armorStr = Console.ReadLine() ?? string.Empty;

                isParsed = Enum.TryParse( armorStr, ignoreCase: true, out armor );

                if ( !isParsed )
                {
                    GameManagerOutput.PrintBadArmorName();
                }
            }

            return ArmorFactory.CreateArmor( armor );
        }

        private static IRace ReadRace()
        {
            GameManagerOutput.PrintRaceMenu();

            Race race = Race.human;

            bool isParsed = false;

            while ( !isParsed )
            {
                GameManagerOutput.PrintEnterRaceName();

                string raceStr = Console.ReadLine() ?? string.Empty;

                isParsed = Enum.TryParse( raceStr, ignoreCase: true, out race );

                if ( !isParsed )
                {
                    GameManagerOutput.PrintBadRaceName();
                }
            }

            return RaceFactory.CreateRace( race );
        }

        private static FighterType ReadFighterType()
        {
            GameManagerOutput.PrintFighterTypeMenu();

            GameManagerOutput.PrintEnterFighterType();

            FighterType fighter = FighterType.knight;

            bool isParsed = false;

            while ( !isParsed )
            {
                string fighterStr = Console.ReadLine() ?? string.Empty;

                isParsed = Enum.TryParse( fighterStr, ignoreCase: true, out fighter );

                if ( !isParsed )
                {
                    GameManagerOutput.PrintBadFighterType();
                }
            }

            return fighter;
        }
    }
}