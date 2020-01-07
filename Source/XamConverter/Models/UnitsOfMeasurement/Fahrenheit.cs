using System;
using Xamarin.Essentials;

namespace XamConverter
{
    class Fahrenheit : UnitOfMeasurementModel
    {
        static readonly Lazy<Fahrenheit> _instanceHolder = new Lazy<Fahrenheit>(() => new Fahrenheit());

        Fahrenheit() : base(UnitOfMeasurement.Temperature)
        {
        }

        public static Fahrenheit Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInKelvin) => UnitConverters.CelsiusToFahrenheit(UnitConverters.KelvinToCelsius(unitsInKelvin));

        public override double ConvertToBaseUnits(double unitsInFahrenheit) => UnitConverters.CelsiusToKelvin(UnitConverters.FahrenheitToCelsius(unitsInFahrenheit));
    }
}
