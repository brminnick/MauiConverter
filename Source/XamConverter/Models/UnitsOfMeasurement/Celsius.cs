namespace XamConverter
{
    class Celsius : UnitOfMeasurementModel
    {
        Celsius() : base(UnitOfMeasurement.Temperature)
        {
        }

        public override double ConvertFromBaseUnits(double unitsInKelvin) => UnitConverters.KelvinToCelsius(unitsInKelvin);

        public override double ConvertToBaseUnits(double unitsInCelsius) => UnitConverters.CelsiusToKelvin(unitsInCelsius);
    }
}
