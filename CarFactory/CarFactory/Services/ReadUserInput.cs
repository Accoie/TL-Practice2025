using Spectre.Console;
using CarFactory.Models.Engines;
using CarFactory.Models.CarShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Transmissions;

namespace CarFactory.Services
{
    public static class ReadUserInput
    {
        public static string ReadChoiceFromAnsiConsole( string title, params string[] choices )
        {
            string result = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( title )
                    .AddChoices( choices )
                    .HighlightStyle( Style.Parse( "red" ) )
            );

            return result;
        }

        public static CarColor ReadCarColor()
        {
            string carColorStr = ReadChoiceFromAnsiConsole( "Choose car color: ", [
                    CarColor.Red.ToString(),
                    CarColor.Blue.ToString(),
                    CarColor.Green.ToString()
                ] );

            Enum.TryParse( carColorStr, out CarColor result );

            return result;
        }
        public static Transmission ReadCarTransmission()
        {
            string transmissionStr = ReadChoiceFromAnsiConsole( "Choose transmission", [
                        Transmission.Automatic.ToString(),
                        Transmission.Manual.ToString(),
                        Transmission.Robotic.ToString(),
                    ] );

            Enum.TryParse( transmissionStr, out Transmission result );

            return result;
        }

        public static Engine ReadCarEngine()
        {
            string engineStr = ReadChoiceFromAnsiConsole( "Choose engine: ", [
                        Engine.Gasoline.ToString(),
                        Engine.Diesel.ToString(),
                        Engine.Wankel.ToString(),
                    ] );

            Enum.TryParse( engineStr, out Engine result );

            return result;
        }

        public static CarShape ReadCarShape()
        {
            string carShapeStr = ReadChoiceFromAnsiConsole( "Choose car shape: ", [
                        CarShape.Crossover.ToString(),
                        CarShape.Sedan.ToString(),
                        CarShape.Jeep.ToString(),
                    ] );

            Enum.TryParse( carShapeStr, out CarShape result );

            return result;
        }

        public static Operation ReadOperation()
        {
            string operationStr = ReadChoiceFromAnsiConsole( "Choose operation: ", [ Operation.CreateCar.ToString(), Operation.Exit.ToString() ] );

            Enum.TryParse( operationStr, out Operation result );

            return result;
        }
    }
}