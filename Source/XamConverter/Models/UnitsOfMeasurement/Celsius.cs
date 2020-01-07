using System;
using Xamarin.Essentials;

namespace XamConverter
{
    class Celsius : UnitOfMeasurementModel
    {
        static readonly Lazy<Celsius> _instanceHolder = new Lazy<Celsius>(() => new Celsius());

        Celsius() : base(UnitOfMeasurement.Temperature)
        {
        }

        public static Celsius Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInKelvin) => UnitConverters.KelvinToCelsius(unitsInKelvin);

        public override double ConvertToBaseUnits(double unitsInCelsius) => UnitConverters.CelsiusToKelvin(unitsInCelsius);
    }
}
