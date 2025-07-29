using CarFactory.Factories;
using CarFactory.Models.Cars;
using CarFactory.Models.CarShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Services
{
    public static class CarCreator
    {
        public static Car Create()
        {
            CarBuilder builder = new CarBuilder();

            ITransmission transmission = TransmissionFactory.MakeTransmission( ReadUserInput.ReadCarTransmission() );
            IEngine engine = EngineFactory.MakeEngine( ReadUserInput.ReadCarEngine() );
            CarColor color = ReadUserInput.ReadCarColor();
            CarShape shape = ReadUserInput.ReadCarShape();

            builder.WithEngine( engine )
                   .WithTransmission( transmission )
                   .WithCarShape( shape )
                   .WithCarColor( color );

            return builder.Build();
        }
    }
}