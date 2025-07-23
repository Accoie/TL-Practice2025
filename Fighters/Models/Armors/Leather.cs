using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Armors
{
    public class Leather : IArmor
    {
        public string Name => "Кожа";
        public int Armor => 15;
    }
}
