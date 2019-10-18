using System;

namespace XamConverter
{
    class Meters : UnitOfMeasurementModel
    {
        static readonly Lazy<Meters> _instanceHolder = new Lazy<Meters>(() => new Meters());

        Meters() : base(UnitOfMeasurement.Length)
        {
        }

        public static Meters Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInMeters) => valueInMeters;

        public override double ConvertToBaseUnits(double valueInMeters) => valueInMeters;
    }
}
