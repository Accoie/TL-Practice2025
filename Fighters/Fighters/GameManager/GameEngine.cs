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
        private List<IFighter> _fighterList = new List<IFighter>();

        public List<IFighter> Fighters => _fighterList;

        public void AddFighter( IFighter fighter )
        {
            if ( string.IsNullOrEmpty( fighter.Name ) )
            {
                return;
            }

            _fighterList.Add( fighter );
        }

        public void RemoveFighter()
        {
            if ( _fighterList.Count == 0 )
            {
                GameManagerOutput.PrintNotEnoughFighter();

                return;
            }

            GameManagerOutput.ShowFighters( _fighterList );

            string? fighterName = ConsoleUserInput.ReadRemovedFighterName();

            if ( string.IsNullOrEmpty( fighterName ) )
            {
                return;
            }

            IFighter? fighter = _fighterList.Find( x => x.Name == fighterName );

            if ( fighter == null )
            {
                GameManagerOutput.PrintFighterNotFound( fighterName );
                return;
            }

            _fighterList.Remove( fighter );

            GameManagerOutput.PrintFighterRemoved( fighterName );
        }

        public IFighter? StartFight()
        {
            List<InitiativeFighter> initiativeFighters = new List<InitiativeFighter>();

            foreach ( var init in _fighterList )
            {
                initiativeFighters.Add( new InitiativeFighter( 0, init ) );
            }

            IFighter? winner = Fight( initiativeFighters );

            GameManagerOutput.PrintWinner( winner );

            return winner;
        }

        public void ResetFighters()
        {
            foreach ( IFighter fighter in _fighterList )
            {
                fighter.ResetHealth();
            }
        }

        private static void RemoveDeadFighters( List<InitiativeFighter> initiativeFighters )
        {
            initiativeFighters.RemoveAll( fighter => !fighter._fighter.IsAlive() );
        }

        private static void CalculateInitiativeAndSort( List<InitiativeFighter> initiativeFighters )
        {
            Random rnd = new Random();

            foreach ( var init in initiativeFighters )
            {
                init._initiative = rnd.Next( 1, 36 );
            }

            initiativeFighters.Sort( ( x, y ) => y._initiative.CompareTo( x._initiative ) );
        }

        private static IFighter? StartDuelAndGetDeadFighter( IFighter fighterFirst, IFighter fighterSecond )
        {
            if ( IsDraw( fighterFirst, fighterSecond ) )
            {
                return null;
            }

            while ( fighterFirst.IsAlive() && fighterSecond.IsAlive() )
            {
                Attack( fighterFirst, fighterSecond );

                if ( fighterSecond.IsAlive() )
                {
                    Attack( fighterSecond, fighterFirst );
                }
            }

            return !fighterFirst.IsAlive() ? fighterFirst : fighterSecond;
        }

        private static bool IsDraw( IFighter fighterFirst, IFighter fighterSecond )
        {
            return !fighterFirst.CanWin( fighterSecond )
                && !fighterSecond.CanWin( fighterFirst );
        }

        private static void Attack( IFighter damager, IFighter defencer )
        {
            int damage = damager.Fight( defencer );

            FightLog firstLog = new FightLog( damager, defencer, damage );

            GameManagerOutput.PrintFightLogs( firstLog );
        }

        private static IFighter? Fight( List<InitiativeFighter> initiativeFighters )
        {
            const int maxDraws = 20;

            int countDraws = 0;

            while ( initiativeFighters.Count != 1 )
            {
                CalculateInitiativeAndSort( initiativeFighters );

                IFighter fighterFirst = initiativeFighters[ 0 ]._fighter;
                IFighter fighterSecond = initiativeFighters[ 1 ]._fighter;

                IFighter? deadFighter = StartDuelAndGetDeadFighter( fighterFirst, fighterSecond );

                if ( deadFighter != null )
                {
                    GameManagerOutput.PrintDied( deadFighter.Name );

                    RemoveDeadFighters( initiativeFighters );
                }
                else
                {
                    if ( countDraws++ == maxDraws )
                    {
                        return null;
                    }

                    GameManagerOutput.PrintNobodyDied();
                }
            }

            return initiativeFighters[ 0 ]._fighter;
        }

        private class InitiativeFighter( int initiative, IFighter fighter )
        {
            public int _initiative = initiative;
            public IFighter _fighter = fighter;
        }
    }
}