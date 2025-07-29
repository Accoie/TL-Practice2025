using CarFactory.Models.Engines;

namespace CarFactory.Factories
{
    public static class EngineFactory
    {
        public static IEngine MakeEngine( Engine engine )
        {
            IEngine result = engine switch
            {
                Engine.Wankel => new Wankel(),
                Engine.Gasoline => new Gasoline(),
                Engine.Diesel => new Diesel(),
                _ => throw new NotImplementedException(),
            };

            return result;
        }
    }
}