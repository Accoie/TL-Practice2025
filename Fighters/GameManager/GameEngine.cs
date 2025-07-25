using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Extensions;
using Fighters.Models.Fighters;


namespace Fighters.GameManager
{
    public class GameEngine
    {
        List<IFighter> _fighterList = new List<IFighter>();

        public void HandleCommand( Command command )
        {
            switch ( command )
            {
                case Command.Initial:
                    return;
                case Command.StartFight:
                    if ( _fighterList.Count < 2 )
                    {
                        Console.WriteLine( "Недостаточно бойцов для битвы (не может быть меньше 2)" );
                        return;
                    }
                    StartFight();

                    break;
                case Command.AddFighter:
                    IFighter fighter = ConsoleUserInput.ReadFighterData();
                    AddFighter( fighter );
                    break;
                case Command.ShowFighters:
                    GameManagerLogger.ShowFighters( _fighterList );
                    break;
                case Command.Quit:
                    break;
            }

        }
        class InitiativeFighter( int priority, IFighter fighter )
        {
            public int _priority = priority;
            public IFighter _fighter = fighter;
        }
        private static void RemoveDeadFighters( List<InitiativeFighter> initiativeFighters )
        {
            initiativeFighters.RemoveAll( fighter => !fighter._fighter.IsAlive() );
        }

        private static void CalculatePriorityAndSort( List<InitiativeFighter> initiativeFighters )
        {
            Random rnd = new Random();

            foreach ( var init in initiativeFighters )
            {
                init._priority = rnd.Next( 1, 36 );
            }

            initiativeFighters.Sort( ( x, y ) => y._priority.CompareTo( x._priority ) );
        }

        public IFighter StartFight()
        {
            List<InitiativeFighter> initiativeFighters = new List<InitiativeFighter>();
            foreach ( var init in _fighterList )
            {
                initiativeFighters.Add( new InitiativeFighter( 0, init ) );
            }
            while ( initiativeFighters.Count != 1 )
            {
                CalculatePriorityAndSort( initiativeFighters );

                IFighter fighterFirst = initiativeFighters[ 0 ]._fighter;
                IFighter fighterSecond = initiativeFighters[ 1 ]._fighter;

                while ( fighterFirst.IsAlive() && fighterSecond.IsAlive() )
                {
                    int damage = fighterFirst.Fight( fighterSecond );

                    FightLog firstLog = new FightLog( fighterFirst.Name, fighterSecond.Name, damage, fighterSecond.GetCurrentHealth() );
                    GameManagerLogger.PrintFightLogs( firstLog );
                    if ( fighterSecond.IsAlive() )
                    {
                        damage = fighterSecond.Fight( fighterFirst );

                        FightLog secondLog = new FightLog( fighterSecond.Name, fighterFirst.Name, damage, fighterFirst.GetCurrentHealth() );
                        GameManagerLogger.PrintFightLogs( secondLog );
                    }
                }
                RemoveDeadFighters( initiativeFighters );
            }
            Console.WriteLine( $"Победитель: {initiativeFighters[ 0 ]._fighter.Name}!!!" );

            return initiativeFighters[ 0 ]._fighter;
        }
        public void AddFighter( IFighter fighter )
        {
            if ( string.IsNullOrEmpty( fighter.Name ) )
            {
                return;
            }

            _fighterList.Add( fighter );
        }

    }
}
