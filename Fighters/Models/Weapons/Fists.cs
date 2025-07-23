namespace Fighters.Models.Weapons
{
    public class Fists : IWeapon
    {
        public string Name => "Кулаки";
        public int Damage
        {
            get => 1;
        }
        public int Weight
        {
            get => 0;
        }

    }
}