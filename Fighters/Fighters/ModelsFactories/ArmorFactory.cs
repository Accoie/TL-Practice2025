using Fighters.Models.Armors;

namespace Fighters.ModelsFactories
{
    public class ArmorFactory
    {
        public static IArmor CreateArmor( Armor armor )
        {
            switch ( armor )
            {
                case Armor.NoArmor:
                    return new NoArmor();
                case Armor.Leather:
                    return new Leather();
                case Armor.Gold:
                    return new Gold();
                case Armor.Diamond:
                    return new Diamond();
                case Armor.Iron:
                    return new Iron();
                default:
                    return new NoArmor();
            }
        }
    }
}