using CasinoOperation;

var casino = new Casino();
const string GameName = "#######---777CASINO777---#######";

PrintGameName( GameName );

Console.Write( "Please enter amount of money you'd like to lose: " );

string balanceStr = Console.ReadLine() ?? "";

bool isBalanceParsed = int.TryParse( balanceStr, out int balance );

if ( !isBalanceParsed )
{
    Console.WriteLine( $"Invalid balance value entered: {balanceStr}" );
    return;
}

if ( balance <= 0 )
{
    Console.WriteLine( "You are too poor to play XD" );
    return;
}

casino.ReadBalance( balance );

Operation? operation = Operation.Initial;

while ( operation != Operation.Exit )
{
    DisplayMenu();

    operation = Casino.ReadOperation();
    if ( !operation.HasValue )
    {
        return;
    }
    try
    {
        casino.HandleOperation( operation.Value );
    }
    catch ( Exception )
    {
        Console.WriteLine( "Please, write correct operation number (1-3)" );
    }

}
static void PrintGameName( string gameName )
{
    Console.WriteLine( gameName );
    Console.WriteLine();
}
static void DisplayMenu()
{
    Console.WriteLine( "Menu: Play(1)" );
    Console.WriteLine( "      Check balance(2)" );
    Console.WriteLine( "      Exit(3)" );
}


public class Casino
{
   
    public void ReadBalance( int balance )
    {
        if ( balance <= 0 )
        {
            throw new FormatException( "Balance cannot be less than 1" );
        }

        _balance = balance;
    }
    public static Operation? ReadOperation()
    {
        string operationStr = Console.ReadLine() ?? "";
        bool isParsed = Enum.TryParse( operationStr, out Operation operation );

        return isParsed ? operation : null;
    }

    public void HandleOperation( Operation operation )
    {
        switch ( operation )
        {
            case Operation.Initial:
                return;
            case Operation.Play:
                {
                    PlayGame();
                    break;
                }
            case Operation.CheckBalance:
                {
                    CheckBalance();
                    break;
                }

            case Operation.Exit:
                {
                    Console.WriteLine( "Goodbye!!!" );
                    break;
                }
            default:
                throw new Exception( $"Unsupported operation passed {operation}." );
        }
    }
    private void CheckBalance()
    {
        Console.WriteLine( $"Your balance: {_balance}" );
    }
    private void PlayGame()
    {
        Console.Write( "Please, write bet: " );
        string betStr = Console.ReadLine() ?? "";

        bool isBetParsed = double.TryParse( betStr, out double bet );

        if ( !isBetParsed )
        {
            Console.WriteLine( "Invalid bet! Example: 3.3" );
            return;
        }
        if ( bet <= 1 )
        {
            Console.WriteLine( "Bet must be more than 1!" );
            return;
        }
        if ( _balance <= 0 || MakeBet( bet ) <= 0 )
        {
            Console.WriteLine( "Ooops... You don't have money!" );
            return;
        }
    }
    public int MakeBet( double bet )
    {
        const int Multiplicator = 1;


        Random random = new Random();

        int number = random.Next( 1, 21 );

        int result = ( int )( bet * ( 1 + ( Multiplicator * number % 17 ) ) );
        _balance = result;
        return result;
    }


    int _balance;
}
