using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Weapons
{
    public class Sword : IWeapon
    {
        public string Name => "Меч";
        public int Damage
        {
            get => 15;
        }
        public int Weight
        {
            get => 3;
        }

    }
}
