using System;

namespace XamConverter
{
    public class Kilometers : UnitOfMeasurementModel
    {
        static readonly Lazy<Kilometers> _instanceHolder =
            new Lazy<Kilometers>(() => new Kilometers());

        Kilometers() : base(UnitOfMeasurement.Length)
        {
        }

        public static Kilometers Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInKilometers)
        {
            return valueInKilometers / 100000;
        }

        public override double ConvertToBaseUnits(double valueInBaseUnit)
        {
            return valueInBaseUnit * 100000;
        }
    }
}
