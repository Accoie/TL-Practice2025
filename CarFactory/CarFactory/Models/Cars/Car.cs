using CarFactory.Models.CarShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Transmissions;

namespace CarFactory.Models.Cars
{
    public class Car( IEngine engine, ITransmission transmission, CarShape carShape, CarColor carColor ) : ICar
    {
        IEngine _engine = engine;
        ITransmission _transmission = transmission;
        CarShape _carShape = carShape;
        CarColor _carColor = carColor;

        public IEngine Engine => _engine;

        public ITransmission Transmission => _transmission;

        public CarShape CarShape => _carShape;

        public CarColor CarColor => _carColor;
    }
}