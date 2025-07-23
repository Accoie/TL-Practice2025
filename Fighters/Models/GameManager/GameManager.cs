using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Fighters;


namespace Fighters.Models.GameManager
{
    public class GameManager
    {
        List<IFighter> _fighterList = new List<IFighter>();

        public void HandleCommand( Command command )
        {
            switch ( command )
            {
                case Command.Initial:
                    return;
                case Command.StartFight:
                    StartFight();
                    break;
                case Command.AddFighter:
                    AddFighter();
                    break;
                case Command.ShowFighters:
                    GameManagerLogger.ShowFighters( _fighterList );
                    break;
                case Command.Quit:
                    break;
            }

        }
        private void StartFight()
        {
        }
        public void AddFighter()
        {
            IFighter fighter = ConsoleUserInput.ReadFighterData();

            _fighterList.Add( fighter );
        }

    }
}
