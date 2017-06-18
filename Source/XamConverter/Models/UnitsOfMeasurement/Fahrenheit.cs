using System;

namespace XamConverter
{
    public class Fahrenheit : UnitOfMeasurementModel
    {
        static readonly Lazy<Fahrenheit> _instanceHolder = 
            new Lazy<Fahrenheit>(() => new Fahrenheit());

        Fahrenheit() : base(UnitOfMeasurement.Temperature)
        {
        }

        public static Fahrenheit Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInCelsius)
        {
            return unitsInCelsius * 9 / 5 + 32;
        }

        public override double ConvertToBaseUnits(double unitsInFahrenheit)
        {
            return (unitsInFahrenheit - 32) * 5 / 9;
        }
    }
}
