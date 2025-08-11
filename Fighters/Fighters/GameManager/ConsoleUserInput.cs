using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.ModelsFactories;
using Fighters.Extensions;

namespace Fighters.GameManager
{
    public static class ConsoleUserInput
    {
        public static bool IsCancel()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey( intercept: true );

            return keyInfo.Key == ConsoleKey.Escape ? true : false;
        }

        public static string ReadInputString()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public static Command ReadUserCommand()
        {
            GameManagerOutput.PrintCommandMenu();

            Command command = ConsoleUserInputExtensions.ReadEnum<Command>( GameManagerOutput.PrintEnterCommand, GameManagerOutput.PrintBadCommand );

            return command;
        }

        public static IFighter ReadFighterData()
        {
            FighterBuilder _builder = new();

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

            Weapon weapon = ConsoleUserInputExtensions.ReadEnum<Weapon>( GameManagerOutput.PrintEnterWeaponName, GameManagerOutput.PrintBadWeaponName );

            return WeaponFactory.CreateWeapon( weapon ); ;
        }

        private static IArmor ReadArmor()
        {
            GameManagerOutput.PrintArmorMenu();

            Armor armor = ConsoleUserInputExtensions.ReadEnum<Armor>( GameManagerOutput.PrintEnterArmorName, GameManagerOutput.PrintBadArmorName );

            return ArmorFactory.CreateArmor( armor );
        }

        private static IRace ReadRace()
        {
            GameManagerOutput.PrintRaceMenu();

            Race race = ConsoleUserInputExtensions.ReadEnum<Race>( GameManagerOutput.PrintEnterRaceName, GameManagerOutput.PrintBadRaceName );

            return RaceFactory.CreateRace( race );
        }

        private static FighterType ReadFighterType()
        {
            GameManagerOutput.PrintFighterTypeMenu();

            FighterType fighter = ConsoleUserInputExtensions.ReadEnum<FighterType>( GameManagerOutput.PrintEnterFighterType, GameManagerOutput.PrintBadFighterType );

            return fighter;
        }
    }
}