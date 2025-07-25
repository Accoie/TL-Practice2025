using Fighters.GameManager;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters;


public class Program
{
    const string Drawing = @"
                ###   =
               #####  ==
               #O#O#  ==
               ##0##  ===
                 #    ===
               #####  ===
              ####### ===          
             ######### |
            ##  ###  ##|
            ##  ###   ##    FIGHTER GAME!
            ## #####  ##
             #######   |
               #####   | 
                ###    | 
               ## ##   | 
              ##   ##  | 
             ##     ## | 
            **       **|";
    public static void Main( string[] args )
    {
        GameEngine gameManager = new GameEngine();

        Console.WriteLine( Drawing );
        Command command = Command.Initial;
        while ( command != Command.Quit )
        {
            PrintMenu();
            Console.Write( "\nВведите команду: " );
            string commandStr = Console.ReadLine() ?? string.Empty;
            try
            {
                command = TryParseCommand( commandStr );
                gameManager.HandleCommand( command );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.Message );
            }
        }

    }

    public static void StartFight()
    {

    }
    public static void PrintMenu()
    {
        string indent = "               ";
        Console.WriteLine( "Список команд: play - Запустить сражение " +
            $"\n{indent}add-fighter - Добавить бойца" +
            $"\n{indent}show-fighters - Список бойцов" +
            $"\n{indent}quit - Выйти из игры"
        );

    }
    private static Command TryParseCommand( string commandStr )
    {
        IReadOnlyDictionary<string, Command> commandDictionary = new Dictionary<string, Command> {
            { "play", Command.StartFight},
            { "add-fighter", Command.AddFighter },
            { "show-fighters", Command.ShowFighters },
            { "quit", Command.Quit },
        };

        if ( !commandDictionary.TryGetValue( commandStr, out var command ) )
        {
            throw new Exception( $"Команда \"{commandStr}\" не поддерживается." );
        }

        return command;
    }
}