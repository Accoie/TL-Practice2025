using Fighters.Extensions;
using Fighters.Models.Fighters;

namespace Fighters.GameManager
{
    public class GameEngine
    {
        private List<IFighter> _fighterList = new();

        const int MaxDraws = 20;

        public IReadOnlyList<IFighter> Fighters => _fighterList;

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
            List<InitiativeFighter> initiativeFighters = new();

            foreach ( IFighter fighter in _fighterList )
            {
                initiativeFighters.Add( new InitiativeFighter( 0, fighter ) );
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

        private static IFighter? StartDuelAndGetDeadFighter( IFighter fighterFirst, IFighter fighterSecond )
        {
            const int maxCountWithoutDamage = 5;

            if ( IsDraw( fighterFirst, fighterSecond ) )
            {
                return null;
            }

            int countWithoutDamage = 0;

            while ( fighterFirst.IsAlive() && fighterSecond.IsAlive() )
            {
                int damageFirst = Attack( fighterFirst, fighterSecond );

                if ( fighterSecond.IsAlive() )
                {
                    int damageSecond = Attack( fighterSecond, fighterFirst );

                    if ( damageFirst == 0 && damageSecond == 0 )
                    {
                        countWithoutDamage++;
                    }
                }
                if ( countWithoutDamage == maxCountWithoutDamage )
                {
                    return null;
                }
            }

            return !fighterFirst.IsAlive() ? fighterFirst : fighterSecond;
        }

        private static bool IsDraw( IFighter fighterFirst, IFighter fighterSecond )
        {
            return !fighterFirst.CanWin( fighterSecond )
                && !fighterSecond.CanWin( fighterFirst );
        }

        private static int Attack( IFighter damager, IFighter defencer )
        {
            int damage = damager.Fight( defencer );

            FightLog firstLog = new FightLog( damager, defencer, damage );

            GameManagerOutput.PrintFightLogs( firstLog );

            return damage;
        }

        private static IFighter? Fight( List<InitiativeFighter> initiativeFighters )
        {
            int countDraws = 0;

            while ( initiativeFighters.Count != 1 )
            {
                CalculateInitiativeList( initiativeFighters );

                SortInitiative( initiativeFighters );

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
                    if ( countDraws++ == MaxDraws )
                    {
                        return null;
                    }

                    GameManagerOutput.PrintNobodyDied();
                }
            }

            return initiativeFighters[ 0 ]._fighter;
        }

        private static void CalculateInitiativeList( List<InitiativeFighter> initiativeFighters )
        {
            Random rnd = new();

            foreach ( var init in initiativeFighters )
            {
                init._initiative = rnd.Next( 1, 36 );
            }
        }

        private static void SortInitiative( IReadOnlyList<InitiativeFighter> initiativeFighters )
        {
            initiativeFighters = initiativeFighters.OrderByDescending( x => x._initiative ).ToList();
        }

        private class InitiativeFighter( int initiative, IFighter fighter )
        {
            public int _initiative = initiative;
            public IFighter _fighter = fighter;
        }
    }
}