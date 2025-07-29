using CarFactory.Models.Transmissions;

namespace CarFactory.Factories
{
    public class TransmissionFactory
    {
        public static ITransmission MakeTransmission( Transmission transmission )
        {
            ITransmission result = transmission switch
            {
                Transmission.Manual => new Manual(),
                Transmission.Automatic => new Automatic(),
                Transmission.Robotic => new Robotic(),
                _ => throw new NotImplementedException(),
            };

            return result;
        }
    }
}