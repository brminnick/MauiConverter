namespace XamConverter
{
    class Fahrenheit : UnitOfMeasurementModel
    {
        Fahrenheit() : base(UnitOfMeasurement.Temperature)
        {
        }

        public override double ConvertFromBaseUnits(double unitsInKelvin) => UnitConverters.CelsiusToFahrenheit(UnitConverters.KelvinToCelsius(unitsInKelvin));

        public override double ConvertToBaseUnits(double unitsInFahrenheit) => UnitConverters.CelsiusToKelvin(UnitConverters.FahrenheitToCelsius(unitsInFahrenheit));
    }
}
