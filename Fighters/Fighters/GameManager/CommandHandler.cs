using Fighters.Models.Fighters;

namespace Fighters.GameManager
{
    public class CommandHandler
    {
        public static void HandleCommand( GameEngine engine, Command command )
        {
            switch ( command )
            {
                case Command.StartFight:
                    engine.StartFight();
                    break;
                case Command.AddFighter:
                    AddFighter( engine );
                    break;
                case Command.RemoveFighter:
                    engine.RemoveFighter();
                    break;
                case Command.ShowFighters:
                    GameManagerOutput.ShowFighters( engine.Fighters );
                    break;
                case Command.Quit:
                    GameManagerOutput.PrintQuitMessage();
                    break;
                default:
                    throw new Exception( "Команда не поддерживается" );
            }
        }

        public static void AddFighter( GameEngine engine )
        {
            IFighter fighter = ConsoleUserInput.ReadFighterData();

            engine.AddFighter( fighter );
        }
    }
}