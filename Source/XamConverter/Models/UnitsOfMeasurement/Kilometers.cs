using System;

namespace XamConverter
{
    class Kilometers : UnitOfMeasurementModel
    {
        Kilometers() : base(UnitOfMeasurement.Length)
        {
        }

        public override double ConvertFromBaseUnits(double valueInMeters) => valueInMeters / 1000;

        public override double ConvertToBaseUnits(double valueInKilometers) => valueInKilometers * 1000;
    }
}
