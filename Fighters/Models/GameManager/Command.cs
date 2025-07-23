using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.GameManager
{
    public enum Command
    {
        Initial = 0,
        StartFight = 1,
        AddFighter = 2,
        ShowFighters = 3,
        Quit = 4,
    }
}
