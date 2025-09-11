using CarFactory.Models.Transmissions;

namespace CarFactory.Factories
{
    public class TransmissionFactory
    {
        public static ITransmission MakeTransmission( Transmission transmission )
        {
            switch ( transmission )
            {
                case Transmission.Manual:
                    return new Manual();
                case Transmission.Automatic:
                    return new Automatic();
                case Transmission.Robotic:
                    return new Robotic();
                default:
                    throw new Exception( "Unknown transmission!" );
            }
        }
    }
}