using System;
namespace XamConverter
{
    class Feet : UnitOfMeasurementModel
    {
        readonly static Lazy<Feet> _instanceHolder = new Lazy<Feet>(() => new Feet());

        Feet() : base(UnitOfMeasurement.Length)
        {
        }

        public static Feet Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInMeters) => valueInMeters * 3.2808399;

        public override double ConvertToBaseUnits(double valueInFeet) => valueInFeet / 3.2808399;
    }
}
