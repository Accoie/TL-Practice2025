using CarFactory.Models.CarShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.Cars
{
    public interface ICar
    {
        public IEngine Engine { get; }

        public ITransmission Transmission { get; }

        public CarShape CarShape { get; }

        public CarColor CarColor { get; }

        public int MaxSpeed { get; }

        public int MaxGears { get; }
    }
}