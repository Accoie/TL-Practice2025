using Fighters.Models.Fighters;

public class FightLog( IFighter damager, IFighter defencer, int damage )
{
    public string DamagerName => damager.Name;

    public string DefencerName => defencer.Name;

    public int Damage => damage;

    public string WeaponName => damager.Weapon.Name;

    public int CurrentHealth => defencer.Health;
}