using System;

namespace XamConverter
{
    public class Kilograms : UnitOfMeasurementModel
    {
        static readonly Lazy<Kilograms> _instanceHolder = 
            new Lazy<Kilograms>(() => new Kilograms());

        Kilograms() : base(UnitOfMeasurement.Mass)
        {
        }

        public static Kilograms Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double numberInGrams)
        {
            return numberInGrams / 1000;
        }

        public override double ConvertToBaseUnits(double numberInKilograms)
        {
            return numberInKilograms * 1000;
        }
    }
}
