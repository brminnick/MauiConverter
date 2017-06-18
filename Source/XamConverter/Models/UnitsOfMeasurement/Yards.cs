using System;

namespace XamConverter
{
    public class Yards : UnitOfMeasurementModel
    {
        static readonly Lazy<Yards> _instanceHolder = 
            new Lazy<Yards>(() => new Yards());

        Yards() : base(UnitOfMeasurement.Length)
        {
        }

        public static Yards Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitInCentimeters)
        {
            return unitInCentimeters / 91.44;
        }

        public override double ConvertToBaseUnits(double unitInYards)
        {
            return unitInYards * 91.44;
        }
    }
}
