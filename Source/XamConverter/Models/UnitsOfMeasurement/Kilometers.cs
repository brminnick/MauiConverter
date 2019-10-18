using System;

namespace XamConverter
{
    class Kilometers : UnitOfMeasurementModel
    {
        static readonly Lazy<Kilometers> _instanceHolder = new Lazy<Kilometers>(() => new Kilometers());

        Kilometers() : base(UnitOfMeasurement.Length)
        {
        }

        public static Kilometers Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInMeters) => valueInMeters / 1000;

        public override double ConvertToBaseUnits(double valueInKilometers) => valueInKilometers * 1000;
    }
}
