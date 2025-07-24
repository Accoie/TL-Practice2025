using OrderManager;

class Program
{
    public void Main()
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
            catch ( InvalidOperationException e )
            {
                Console.WriteLine( e.Message );
            }
        }
    }

    private void HandleOperation( Operation operation )
    {
        switch ( operation )
        {
            case Operation.MakeOrder:
                MakeOrder();
                break;
            case Operation.Exit:
                Console.WriteLine( "До свидания!" );
                break;
            case Operation.Error:
                throw new InvalidOperationException( "Операция не поддерживается" );
            default:
                return;
        }
    }

    private void MakeOrder()
    {
        try
        {
            string productName = ReadUserInput.ReadProductName();
            int countProduct = ReadUserInput.ReadCountProduct();
            string clientName = ReadUserInput.ReadClientName();
            string address = ReadUserInput.ReadAddress();

            ConsolePrinter messagePrinter = new ConsolePrinter( productName, countProduct, address );

            messagePrinter.PrintApplyMessage();
        }
        catch ( FormatException e )
        {
            Console.WriteLine( e.Message );
        }
    }
}
