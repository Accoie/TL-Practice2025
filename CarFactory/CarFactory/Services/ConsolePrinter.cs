using CarFactory.Models.Cars;
using Spectre.Console;

namespace CarFactory.Services
{
    public static class ConsolePrinter
    {
        public static void PrintGreetingMessage()
        {
            AnsiConsole.Write( new FigletText( "CAR   FACTORY" )
                        .Color( Color.Red ) );
        }

        public static void PrintCar( ICar car )
        {
            AnsiConsole.Markup( "[#FF5733]Car Configuration[/]\n" );

            var table = new Table()
                .Border( TableBorder.Rounded )
                .BorderColor( Color.FromHex( "#FF5733" ) )
                .AddColumn( "" )
                .AddColumn( "" ).HideHeaders();

            table.AddRow( "Engine:", car.Engine.ToString() );
            table.AddRow( "Transmission:", car.Transmission.ToString() );
            table.AddRow( "Color:", car.CarColor.ToString() );
            table.AddRow( "Shape:", car.CarShape.ToString() );
            table.AddRow( "Max Speed:", car.MaxSpeed.ToString() );
            table.AddRow( "Max Gears:", car.MaxGears.ToString() );

            AnsiConsole.Write( table );
        }

        public static void PrintGoodbyeMessage()
        {
            AnsiConsole.Write( new FigletText( "GOODBYE!" )
                       .Color( Color.Red ) );
        }
    }
}