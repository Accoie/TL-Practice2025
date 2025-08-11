namespace Fighters.Models.Weapons
{
    public class Sword : IWeapon
    {
        public string Name => "Меч";

        public int Damage
        {
            get => 15;
        }
    }
}