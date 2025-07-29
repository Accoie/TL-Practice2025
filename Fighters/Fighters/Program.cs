using Fighters.GameManager;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters;

public class Program
{
    public static void Main( string[] args )
    {
        GameEngine gameManager = new GameEngine();

        GameManagerOutput.PrintGreetingMessage();

        Command command = Command.Initial;

        while ( command != Command.Quit )
        {
            command = ConsoleUserInput.ReadUserCommand();

            CommandHandler.HandleCommand( gameManager, command );

            if ( command == Command.StartFight )
            {
                gameManager.ResetFighters();
            }
        }
    }
}