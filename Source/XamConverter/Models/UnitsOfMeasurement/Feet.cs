namespace XamConverter
{
    class Feet : UnitOfMeasurementModel
    {
        Feet() : base(UnitOfMeasurement.Length)
        {
        }

        public override double ConvertFromBaseUnits(double valueInMeters) => UnitConverters.MetersToInternationalFeet(valueInMeters);

        public override double ConvertToBaseUnits(double valueInFeet) => UnitConverters.InternationalFeetToMeters(valueInFeet);
    }
}
