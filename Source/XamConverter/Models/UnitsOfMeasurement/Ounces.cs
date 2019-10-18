using System;

namespace XamConverter
{
    class Ounces : UnitOfMeasurementModel
    {
        static readonly Lazy<Ounces> _instanceHolder = new Lazy<Ounces>(() => new Ounces());

        Ounces() : base(UnitOfMeasurement.Mass)
        {
        }

        public static Ounces Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double numberInGrams) => numberInGrams / 28.35;

        public override double ConvertToBaseUnits(double numberInOunces) => numberInOunces * 28.35;
    }
}
