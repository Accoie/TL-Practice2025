namespace Fighters.Models.Weapons
{
    public class LongSword : IWeapon
    {
        public string Name => "Длинный меч";

        public int Damage
        {
            get => 30;
        }
    }
}