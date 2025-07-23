using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Races
{
    public class Orc : IRace
    {
        public string Name => "Орк";
        public int Damage => 10;
        public int Health => 150;
        public int Armor => 10;
    }
}
