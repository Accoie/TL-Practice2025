using Fighters.Models.Races;

namespace Fighters.ModelsFactories
{
    public class RaceFactory
    {
        public static IRace CreateRace( Race race )
        {
            switch ( race )
            {
                case Race.Human:
                    return new Human();
                case Race.Orc:
                    return new Orc();
                default:
                    return new Human();
            }
        }
    }
}