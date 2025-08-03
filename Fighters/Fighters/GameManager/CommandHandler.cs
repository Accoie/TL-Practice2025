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
            if ( engine.Fighters.Count < 2 )
            {
                throw new Exception( "Недостаточно бойцов для битвы (не может быть меньше 2)" );
            }
            engine.StartFight();
        }

        public static void AddFighter( GameEngine engine )
        {
            IFighter fighter = ConsoleUserInput.ReadFighterData();
            engine.AddFighter( fighter );
        }

        public static void RemoveFighter( GameEngine engine )
        {
            if ( engine.Fighters.Count == 0 )
            {
                throw new Exception( "Не хватает бойцов для удаления(нужен хотя бы 1)" );
            }
            engine.RemoveFighter();
        }

        public static void ShowFighters( GameEngine engine )
        {
            if ( engine.Fighters.Count == 0 )
            {
                throw new Exception( "Нет бойцов" );
            }
            GameManagerOutput.ShowFighters( engine.Fighters );
        }

        public static void Quit()
        {
            GameManagerOutput.PrintQuitMessage();
        }
    }
}