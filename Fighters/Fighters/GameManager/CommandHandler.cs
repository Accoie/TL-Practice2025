using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Fighters;

namespace Fighters.GameManager
{
    public class CommandHandler
    {
        public static void HandleCommand( GameEngine engine, Command command )
        {
            switch ( command )
            {
                case Command.Initial:
                    return;
                case Command.StartFight:
                    if ( engine.Fighters.Count < 2 )
                    {
                        GameManagerOutput.PrintNotEnoughFightersForFight();
                        return;
                    }
                    engine.StartFight();

                    break;
                case Command.AddFighter:
                    IFighter fighter = ConsoleUserInput.ReadFighterData();

                    engine.AddFighter( fighter );
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
            }
        }
    }
}