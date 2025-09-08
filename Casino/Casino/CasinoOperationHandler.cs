using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoOperation;

namespace Casino;

public class CasinoOperationHandler
{
    public static void HandleOperation( CasinoGame casino, Operation operation )
    {
        switch ( operation )
        {
            case Operation.Initial:
                return;
            case Operation.Play:
                {
                    casino.PlayGame();
                    break;
                }
            case Operation.CheckBalance:
                {
                    CasinoPrintInfo.PrintBalance( casino.Balance );
                    break;
                }
            case Operation.Exit:
                {
                    Console.WriteLine( "\nGoodbye!!!" );
                    break;
                }
            default:
                throw new Exception( $"Unsupported operation passed {operation}." );
        }
    }
}
