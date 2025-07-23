namespace Fighters.Models.Weapons
{
    public interface IWeapon
    {
        string Name { get; }
        public int Damage { get; }
        public int Weight { get; } // in kg

    }
}