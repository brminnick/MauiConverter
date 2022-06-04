namespace XamConverter
{
    class Meters : UnitOfMeasurementModel
    {
        Meters() : base(UnitOfMeasurement.Length)
        {
        }

        public override double ConvertFromBaseUnits(double valueInMeters) => valueInMeters;

        public override double ConvertToBaseUnits(double valueInMeters) => valueInMeters;
    }
}
