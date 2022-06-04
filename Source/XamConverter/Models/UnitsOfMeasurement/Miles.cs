namespace XamConverter
{
    class Miles : UnitOfMeasurementModel
    {
        Miles() : base(UnitOfMeasurement.Length)
        {
        }

        public override double ConvertFromBaseUnits(double valueInMeters) => UnitConverters.KilometersToMiles(valueInMeters / 1000);

        public override double ConvertToBaseUnits(double valueInMilies) => UnitConverters.MilesToKilometers(valueInMilies) * 1000;
    }
}
