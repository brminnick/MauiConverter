using System;

namespace XamConverter
{
    class Kilograms : UnitOfMeasurementModel
    {
        Kilograms() : base(UnitOfMeasurement.Mass)
        {
        }

        public override double ConvertFromBaseUnits(double numberInGrams) => numberInGrams / 1000;

        public override double ConvertToBaseUnits(double numberInKilograms) => numberInKilograms * 1000;
    }
}
