using Fighters.Models.Armors;

namespace Fighters.ModelsFactories
{
    public class ArmorFactory
    {
        public static IArmor CreateArmor( Armor armor )
        {
            switch ( armor )
            {
                case Armor.noArmor:
                    return new NoArmor();
                case Armor.leather:
                    return new Leather();
                case Armor.gold:
                    return new Gold();
                case Armor.diamond:
                    return new Diamond();
                case Armor.iron:
                    return new Iron();
                default:
                    return new NoArmor();
            }
        }
    }
}