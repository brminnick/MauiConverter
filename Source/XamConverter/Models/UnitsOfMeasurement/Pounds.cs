namespace XamConverter
{
    class Pounds : UnitOfMeasurementModel
    {
        Pounds() : base(UnitOfMeasurement.Mass)
        {
        }

        public override double ConvertFromBaseUnits(double unitsInGrams) => UnitConverters.KilogramsToPounds(unitsInGrams / 1000);

        public override double ConvertToBaseUnits(double unitsInPounds) => UnitConverters.PoundsToKilograms(unitsInPounds) * 1000;
    }
}
