namespace XamConverter
{
    class Yards : UnitOfMeasurementModel
    {
        Yards() : base(UnitOfMeasurement.Length)
        {
        }

        public override double ConvertFromBaseUnits(double unitInMeters) => UnitConverters.MetersToInternationalFeet(unitInMeters) / 3;

        public override double ConvertToBaseUnits(double unitInYards) => UnitConverters.InternationalFeetToMeters(unitInYards * 3);
    }
}
