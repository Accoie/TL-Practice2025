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
                    if ( engine.Fighters.Count < 2 )
                    {
                        throw new Exception( "Недостаточно бойцов для битвы (не может быть меньше 2)" );
                    }
                    engine.StartFight();
                    break;
                case Command.AddFighter:
                    IFighter fighter = ConsoleUserInput.ReadFighterData();
                    engine.AddFighter( fighter );
                    break;
                case Command.RemoveFighter:
                    if ( engine.Fighters.Count == 0 )
                    {
                        throw new Exception( "Не хватает бойцов для удаления(нужен хотя бы 1)" );
                    }
                    engine.RemoveFighter();
                    break;
                case Command.ShowFighters:
                    if ( engine.Fighters.Count == 0 )
                    {
                        throw new Exception( "Нет бойцов" );
                    }
                    GameManagerOutput.ShowFighters( engine.Fighters );
                    break;
                case Command.Quit:
                    GameManagerOutput.PrintQuitMessage();
                    break;
                default:
                    throw new Exception( "Команда не поддерживается" );
            }
        }
    }
}