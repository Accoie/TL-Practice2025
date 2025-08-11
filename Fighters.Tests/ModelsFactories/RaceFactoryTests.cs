using Fighters.Models.Races;
using Fighters.ModelsFactories;

namespace Fighters.Tests.ModelsFactories
{
    public class RaceFactoryTests
    {
        [Test]
        public void Create_Race()
        {
            IRace raceObj = RaceFactory.CreateRace( Race.Orc );

            Assert.That( raceObj, Is.InstanceOf<Orc>() );
        }
    }
}
