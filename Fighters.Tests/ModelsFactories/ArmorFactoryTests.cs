using Fighters.Models.Armors;
using Fighters.ModelsFactories;

namespace Fighters.Tests.ModelsFactories
{
    public class ArmorFactoryTests
    {
        [Test]
        public void Create_Armor()
        {
            IArmor armorObj = ArmorFactory.CreateArmor( Armor.Iron );

            Assert.That( armorObj, Is.InstanceOf<Iron>() );
        }
    }
}
