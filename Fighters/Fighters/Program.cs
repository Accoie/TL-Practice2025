using Fighters.GameManager;

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