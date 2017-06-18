using System;

namespace XamConverter
{
    public class Celsius : UnitOfMeasurementModel
    {
        static readonly Lazy<Celsius> _instanceHolder = 
            new Lazy<Celsius>(() => new Celsius());

        Celsius() : base(UnitOfMeasurement.Temperature)
        {
        }

        public static Celsius Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInCelsius)
        {
            return unitsInCelsius;
        }

        public override double ConvertToBaseUnits(double unitsInCelsius)
        {
            return unitsInCelsius;
        }
    }
}
