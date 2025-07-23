
namespace Fighters.Models.Weapons
{
    public class LongSword : IWeapon
    {
        public string Name => "Длинный меч";
        public int Damage
        {
            get => 30;
        }
        public int Weight
        {
            get => 6;
        }

    }
}
