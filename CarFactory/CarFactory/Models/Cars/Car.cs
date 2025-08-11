using CarFactory.Models.CarShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars
{
    public class Car : ICar
    {
        public IEngine Engine { get; private set; }

        public ITransmission Transmission { get; private set; }

        public CarShape CarShape { get; private set; }

        public CarColor CarColor { get; private set; }

        public int MaxSpeed => Engine.MaxSpeed;

        public int MaxGears => Transmission.Gears;

        public Car( IEngine engine, ITransmission transmission, CarShape carShape, CarColor carColor )
        {
            Engine = engine;
            Transmission = transmission;
            CarShape = carShape;
            CarColor = carColor;
        }
    }
}