using System;
using Xamarin.Essentials;

namespace XamConverter
{
    class Ounces : UnitOfMeasurementModel
    {
        static readonly Lazy<Ounces> _instanceHolder = new Lazy<Ounces>(() => new Ounces());

        Ounces() : base(UnitOfMeasurement.Mass)
        {
        }

        public static Ounces Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double numberInGrams) => UnitConverters.KilogramsToPounds(numberInGrams / 1000) * 16;

        public override double ConvertToBaseUnits(double numberInOunces) => UnitConverters.PoundsToKilograms(numberInOunces / 16) * 1000;
    }
}
