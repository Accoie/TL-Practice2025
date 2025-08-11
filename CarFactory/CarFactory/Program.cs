using CarFactory.Models.Cars;
using CarFactory.Services;

class Program
{
    public static void Main()
    {
        ConsolePrinter.PrintGreetingMessage();

        Operation operation = Operation.Initial;

        while ( operation != Operation.Exit )
        {
            try
            {
                operation = ReadUserInput.ReadOperation();

                if ( operation == Operation.Exit )
                {
                    ConsolePrinter.PrintGoodbyeMessage();
                    return;
                }

                Car car = CarCreator.Create();

                ConsolePrinter.PrintCar( car );
            }
            catch ( Exception ex )
            {
                ConsolePrinter.PrintMessage( ex.Message );
            }
        }
    }
}