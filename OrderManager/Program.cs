using OrderManager;

class Program
{
    public static void Main()
    {
        Operation operation = Operation.MakeOrder;

        while ( operation != Operation.Exit )
        {
            ConsolePrinter.PrintMenu();
            operation = ReadUserInput.ReadOperation();
            try
            {
                HandleOperation( operation );
            }
            catch ( FormatException e )
            {
                Console.WriteLine( e.Message );
            }
            catch ( InvalidOperationException e )
            {
                Console.WriteLine( e.Message );
            }
        }
    }

    private static void HandleOperation( Operation operation )
    {
        switch ( operation )
        {
            case Operation.MakeOrder:
                MakeOrder();
                break;
            case Operation.Exit:
                Console.WriteLine( "До свидания!" );
                break;
            default:
                throw new InvalidOperationException( "Операция не поддерживается" );
        }
    }

    private static void MakeOrder()
    {
        string productName = ReadUserInput.ReadProductName();
        int countProduct = ReadUserInput.ReadCountProduct();
        string clientName = ReadUserInput.ReadClientName();
        string address = ReadUserInput.ReadAddress();

        ConsolePrinter messagePrinter = new ConsolePrinter( productName, countProduct, address );

        messagePrinter.PrintApplyMessage();
    }
}
