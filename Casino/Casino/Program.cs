using Casino;
using CasinoOperation;

class Program
{
    public static void Main()
    {
        CasinoPrintInfo.PrintGameName();

        int balance = ReadUserInput.ReadBalance();
        CasinoGame casinoGame = new CasinoGame(balance);

        Operation operation = Operation.Initial;

        while ( operation != Operation.Exit )
        {
            CasinoPrintInfo.DisplayMenu();
            
            try
            {
                operation = ReadUserInput.ReadOperation();
                CasinoOperationHandler.HandleOperation( casinoGame, operation );
            }
            catch ( Exception e)
            {
                Console.WriteLine( e.Message );
            }
        }
    }
}
