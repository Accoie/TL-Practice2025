using CarFactory.Models.Cars;
using CarFactory.Models.CarShapes;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Transmissions;

namespace CarFactory.Services
{
    public class CarBuilder
    {
        IEngine _engine = new Gasoline();
        ITransmission _transmission = new Manual();
        CarShape _carShape = CarShape.Sedan;
        CarColor _carColor = CarColor.Red;


        public CarBuilder WithEngine( IEngine engine )
        {
            _engine = engine;

            return this;
        }

        public CarBuilder WithTransmission( ITransmission transmission )
        {
            _transmission = transmission;

            return this;
        }

        public CarBuilder WithCarShape( CarShape carShape )
        {
            _carShape = carShape;

            return this;
        }

        public CarBuilder WithCarColor( CarColor carColor )
        {
            _carColor = carColor;

            return this;
        }

        public Car Build()
        {
            return new Car( _engine, _transmission, _carShape, _carColor );
        }
    }
}