using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino;

public class CasinoPrintInfo
{
    const string GameName = "#######---777CASINO777---#######";

    public static void PrintBalance(int balance)
    {
        Console.WriteLine( $"Your balance: {balance}" );
        return;
    }
    public static void DisplayMenu()
    {
        Console.WriteLine( "Menu: Play(1)" );
        Console.WriteLine( "      Check balance(2)" );
        Console.WriteLine( "      Exit(3)" );
    }

    public static void PrintGameName()
    {
        Console.WriteLine( GameName );
        Console.WriteLine();
    }
}
