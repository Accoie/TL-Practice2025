using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.ModelsFactories;

namespace Fighters.GameManager
{
    public class ConsoleUserInput
    {
        public static T ReadEnum<T>( Action onInput, Action onError ) where T : struct
        {
            bool isParsed = false;

            T result = default;

            while ( !isParsed )
            {
                onInput.Invoke();

                string input = Console.ReadLine() ?? string.Empty;

                if ( string.IsNullOrEmpty( input ) )
                {
                    continue;
                }

                isParsed = Enum.TryParse( input, ignoreCase: true, out result );

                if ( !isParsed )
                {
                    onError.Invoke();
                }
            }

            return result;
        }

        public static (string? input, bool isCancel) ReadInputWithCancel()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey( intercept: true );

            if ( keyInfo.Key == ConsoleKey.Escape )
            {
                return (null, true);
            }

            string input = Console.ReadLine() ?? string.Empty;

            return (input, false);
        }

        public static Command ReadUserCommand()
        {
            GameManagerOutput.PrintCommandMenu();

            Command command = ReadEnum<Command>( GameManagerOutput.PrintEnterCommand, GameManagerOutput.PrintBadCommand );

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

            Weapon weapon = ReadEnum<Weapon>( GameManagerOutput.PrintEnterWeaponName, GameManagerOutput.PrintBadWeaponName );

            return WeaponFactory.CreateWeapon( weapon ); ;
        }

        private static IArmor ReadArmor()
        {
            GameManagerOutput.PrintArmorMenu();

            Armor armor = ReadEnum<Armor>( GameManagerOutput.PrintEnterArmorName, GameManagerOutput.PrintBadArmorName );

            return ArmorFactory.CreateArmor( armor );
        }

        private static IRace ReadRace()
        {
            GameManagerOutput.PrintRaceMenu();

            Race race = ReadEnum<Race>( GameManagerOutput.PrintEnterRaceName, GameManagerOutput.PrintBadRaceName );

            return RaceFactory.CreateRace( race );
        }

        private static FighterType ReadFighterType()
        {
            GameManagerOutput.PrintFighterTypeMenu();

            FighterType fighter = ReadEnum<FighterType>( GameManagerOutput.PrintEnterFighterType, GameManagerOutput.PrintBadFighterType );

            return fighter;
        }
    }
}