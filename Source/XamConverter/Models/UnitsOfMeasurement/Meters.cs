using System;

namespace XamConverter
{
    public class Meters : UnitOfMeasurementModel
    {
        static readonly Lazy<Meters> _instanceHolder = 
            new Lazy<Meters>(() => new Meters());

        Meters() : base(UnitOfMeasurement.Length)
        {
        }

        public static Meters Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInMeters)
        {
            return valueInMeters / 100;
        }

        public override double ConvertToBaseUnits(double valueInBaseUnit)
        {
            return valueInBaseUnit * 100;
        }
    }
}
