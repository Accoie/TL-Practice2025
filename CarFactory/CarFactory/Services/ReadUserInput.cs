using Spectre.Console;
using CarFactory.Models.Engines;
using CarFactory.Models.CarShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Transmissions;

namespace CarFactory.Services
{
    public static class ReadUserInput
    {
        public static CarColor ReadCarColor()
        {
            string carColorStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( "Choose car color: " )
                    .AddChoices( [ CarColor.Red.ToString(), CarColor.Blue.ToString(), CarColor.Green.ToString() ] )
                    .HighlightStyle( Style.Parse( "red" ) )
            );

            Enum.TryParse( carColorStr, out CarColor result );

            return result;
        }
        public static Transmission ReadCarTransmission()
        {
            string transmissionStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( "Choose transmission: " )
                    .AddChoices( [
                        Transmission.Automatic.ToString(),
                        Transmission.Manual.ToString(),
                        Transmission.Robotic.ToString(),
                    ] )
                    .HighlightStyle( Style.Parse( "red" ) )
            );

            Enum.TryParse( transmissionStr, out Transmission result );

            return result;
        }

        public static Engine ReadCarEngine()
        {
            string engineStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( "Choose engine: " )
                    .AddChoices( [
                        Engine.Gasoline.ToString(),
                        Engine.Diesel.ToString(),
                        Engine.Wankel.ToString(),
                    ] )
                    .HighlightStyle( Style.Parse( "red" ) )
            );

            Enum.TryParse( engineStr, out Engine result );

            return result;
        }

        public static CarShape ReadCarShape()
        {
            string carShapeStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( "Choose car shape: " )
                    .AddChoices( [
                        CarShape.Crossover.ToString(),
                        CarShape.Sedan.ToString(),
                        CarShape.Jeep.ToString(),
                    ] )
                    .HighlightStyle( Style.Parse( "red" ) )
            );

            Enum.TryParse( carShapeStr, out CarShape result );

            return result;
        }

        public static Operation ReadOperation()
        {
            string operationStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title( "Choose operation: " )
                    .AddChoices( [ Operation.CreateCar.ToString(), Operation.Exit.ToString() ] )
                    .HighlightStyle( Style.Parse( "red" ) )
                );

            Enum.TryParse( operationStr, out Operation result );

            return result;
        }
    }
}