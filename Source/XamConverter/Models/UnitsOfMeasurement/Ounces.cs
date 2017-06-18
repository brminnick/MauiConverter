using System;

namespace XamConverter
{
    public class Ounces : UnitOfMeasurementModel
    {
        static readonly Lazy<Ounces> _instanceHolder = 
            new Lazy<Ounces>(() => new Ounces());

        Ounces() : base(UnitOfMeasurement.Mass)
        {
        }

        public static Ounces Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double numberInGrams)
        {
            return numberInGrams / 28.35;
        }

        public override double ConvertToBaseUnits(double numberInOunces)
        {
            return numberInOunces * 28.35;
        }
    }
}
