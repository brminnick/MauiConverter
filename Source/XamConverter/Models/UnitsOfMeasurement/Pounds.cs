using System;
using Xamarin.Essentials;

namespace XamConverter
{
    class Pounds : UnitOfMeasurementModel
    {
        static readonly Lazy<Pounds> _instanceHolder = new Lazy<Pounds>(() => new Pounds());

        Pounds() : base(UnitOfMeasurement.Mass)
        {
        }

        public static Pounds Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInGrams) => UnitConverters.KilogramsToPounds(unitsInGrams / 1000);

        public override double ConvertToBaseUnits(double unitsInPounds) => UnitConverters.PoundsToKilograms(unitsInPounds) * 1000;
    }
}
