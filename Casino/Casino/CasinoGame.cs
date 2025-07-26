using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino;

public class CasinoGame(int balance)
{
    private int _balance = balance;

    public int Balance { get => _balance; }

    public void PlayGame()
    {
        double? bet = null;

        while (bet == null)
        {
            bet = ReadUserInput.ReadBet();
        }
        var balance = MakeBet( bet.Value );

        if ( _balance <= 0 || balance <= 0 )
        {
            Console.WriteLine( "Ooops... You don't have money!" );
            _balance = 0;
            return;
        }

        _balance = balance; 
    }

    public int MakeBet( double bet )
    {
        const double Multiplicator = 1.1;

        Random random = new Random();

        int number = random.Next( 1, 21 );

        int result = ( int )( bet * ( 1 + ( Multiplicator * number % 17 ) ) );

        return result;
    }
}
