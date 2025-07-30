using Fighters.Models.Races;

namespace Fighters.ModelsFactories
{
    public class RaceFactory
    {
        public static IRace CreateRace( Race race )
        {
            switch ( race )
            {
                case Race.human:
                    return new Human();
                case Race.orc:
                    return new Orc();
                default:
                    return new Human();
            }
        }
    }
}