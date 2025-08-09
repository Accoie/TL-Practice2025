using Fighters.Extensions;
using Fighters.Models.Fighters;

namespace Fighters.GameManager
{
    public class GameEngine
    {
        private List<IFighter> _fighterList = new();

        private const int MaxDraws = 20;

        public IReadOnlyList<IFighter> Fighters => _fighterList;

        public void AddFighter( IFighter fighter )
        {
            if ( string.IsNullOrEmpty( fighter.Name ) )
            {
                throw new ArgumentException( "Имя бойца не может быть пустым" );
            }

            _fighterList.Add( fighter );
        }

        public void RemoveFighter()
        {
            if ( _fighterList.Count == 0 )
            {
                throw new Exception( "Не хватает бойцов для удаления(нужен хотя бы 1)" );
            }

            GameManagerOutput.ShowFighters( _fighterList );

            GameManagerOutput.PrintEnterRemovedFighterOrCancel();

            if ( ConsoleUserInput.IsCancel() )
            {
                return;
            }

            string fighterName = ConsoleUserInput.ReadInputString();

            if ( string.IsNullOrEmpty( fighterName ) )
            {
                throw new ArgumentException( "Имя бойца не может быть пустым" );
            }

            IFighter? fighter = _fighterList.Find( x => x.Name == fighterName );

            if ( fighter == null )
            {
                throw new ArgumentException( "Боец не найден!" );
            }

            _fighterList.Remove( fighter );

            GameManagerOutput.PrintFighterRemoved( fighterName );
        }

        public IFighter? StartFight()
        {
            if ( _fighterList.Count < 2 )
            {
                throw new Exception( "Недостаточно бойцов для битвы (не может быть меньше 2)" );
            }

            List<InitiativeFighter> initiativeFighters = new();

            foreach ( IFighter fighter in _fighterList )
            {
                initiativeFighters.Add( new InitiativeFighter( initiative: 0, fighter ) );
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

                if ( !fighterSecond.IsAlive() )
                {
                    return fighterSecond;
                }

                int damageSecond = Attack( fighterSecond, fighterFirst );

                if ( damageFirst == 0 && damageSecond == 0 )
                {
                    countWithoutDamage++;
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
            return !fighterFirst.IsCanWin( fighterSecond )
                && !fighterSecond.IsCanWin( fighterFirst );
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
                    countDraws++;

                    GameManagerOutput.PrintNobodyDied();
                }

                if ( countDraws == MaxDraws )
                {
                    return null;
                }
            }

            return initiativeFighters[ 0 ]._fighter;
        }

        private static void CalculateInitiativeList( List<InitiativeFighter> initiativeFighters )
        {
            Random rnd = new();

            foreach ( InitiativeFighter init in initiativeFighters )
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