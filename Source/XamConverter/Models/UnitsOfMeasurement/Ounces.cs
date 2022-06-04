namespace XamConverter
{
    class Ounces : UnitOfMeasurementModel
    {
        Ounces() : base(UnitOfMeasurement.Mass)
        {
        }

        public override double ConvertFromBaseUnits(double numberInGrams) => UnitConverters.KilogramsToPounds(numberInGrams / 1000) * 16;

        public override double ConvertToBaseUnits(double numberInOunces) => UnitConverters.PoundsToKilograms(numberInOunces / 16) * 1000;
    }
}
