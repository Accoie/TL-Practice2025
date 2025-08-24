using Fighters.GameManager;

namespace Fighters;

public class Program
{
    public static void Main( string[] args )
    {
        GameEngine gameManager = new();

        GameManagerOutput.PrintGreetingMessage();

        Command command = new();

        while ( command != Command.Quit )
        {
            try
            {
                command = ConsoleUserInput.ReadUserCommand();

                CommandHandler.HandleCommand( gameManager, command );

                if ( command == Command.StartFight )
                {
                    gameManager.ResetFighters();
                }
            }
            catch ( Exception ex )
            {
                GameManagerOutput.PrintExceptionMessage( ex.Message );
            }
        }
    }
}