using CarFactory.Models.Engines;

namespace CarFactory.Factories
{
    public static class EngineFactory
    {
        public static IEngine MakeEngine( Engine engine )
        {
            switch ( engine )
            {
                case Engine.Wankel:
                    return new Wankel();
                case Engine.Gasoline:
                    return new Gasoline();
                case Engine.Diesel:
                    return new Diesel();
                default:
                    throw new Exception( "Unknown engine!" );
            }
        }
    }
}