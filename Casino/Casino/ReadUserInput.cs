using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoOperation;
using System.Globalization;

namespace Casino;

public class ReadUserInput
{
    public static double? ReadBet()
    {
        Console.Write( "Please, write bet: " );
        string betStr = Console.ReadLine() ?? string.Empty;

        bool isBetParsed = double.TryParse( betStr,
            new CultureInfo( "en-US" ),
            out double bet );

        if ( !isBetParsed )
        {
            Console.WriteLine( "Invalid bet! Example: 3.3" );
            return null;
        }
        if ( bet <= 1 )
        {
            Console.WriteLine( "Bet must be more than 1!" );
            return null;
        }

        return bet;
    }

    public static int ReadBalance()
    {
        bool isBalanceParsed = false;
        int balance = 0;
        
        while ( !isBalanceParsed )
        {
            Console.Write( "Please enter amount of money you'd like to lose: " );

            string balanceStr = Console.ReadLine() ?? string.Empty;

            isBalanceParsed = int.TryParse( balanceStr, out balance );

            if ( !isBalanceParsed )
            {
                Console.WriteLine( $"Invalid balance value entered: {balanceStr}" );
            }
            if ( balance <= 0 )
            {
                Console.WriteLine( "Balance cannot be less than 1" );
            }
        }

        return balance;
    }

    public static Operation ReadOperation()
    {
        string operationStr = Console.ReadLine() ?? string.Empty;
        if ( string.IsNullOrEmpty( operationStr ) )
        {
            throw new Exception( "Operation cannot be empty!" );
        }

        bool isParsed = Enum.TryParse( operationStr, out Operation operation );
        if ( !isParsed )
        {
            throw new Exception( "Unsupport operation!" );
        }

        return operation;
    }
}
