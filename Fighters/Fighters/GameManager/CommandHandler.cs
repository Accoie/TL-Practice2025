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
                    StartFight( engine );
                    break;
                case Command.AddFighter:
                    AddFighter( engine );
                    break;
                case Command.RemoveFighter:
                    RemoveFighter( engine );
                    break;
                case Command.ShowFighters:
                    ShowFighters( engine );
                    break;
                case Command.Quit:
                    Quit();
                    break;
                default:
                    throw new Exception( "Команда не поддерживается" );
            }
        }

        public static void StartFight( GameEngine engine )
        {
            engine.StartFight();
        }

        public static void AddFighter( GameEngine engine )
        {
            IFighter fighter = ConsoleUserInput.ReadFighterData();

            engine.AddFighter( fighter );
        }

        public static void RemoveFighter( GameEngine engine )
        {
            engine.RemoveFighter();
        }

        public static void ShowFighters( GameEngine engine )
        {
            GameManagerOutput.ShowFighters( engine.Fighters );
        }

        public static void Quit()
        {
            GameManagerOutput.PrintQuitMessage();
        }
    }
}