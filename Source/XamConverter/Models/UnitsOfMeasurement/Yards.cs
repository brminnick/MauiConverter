using System;

namespace XamConverter
{
    class Yards : UnitOfMeasurementModel
    {
        static readonly Lazy<Yards> _instanceHolder = new Lazy<Yards>(() => new Yards());

        Yards() : base(UnitOfMeasurement.Length)
        {
        }

        public static Yards Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitInMeters) => unitInMeters * 1.0936;

        public override double ConvertToBaseUnits(double unitInYards) => unitInYards / 1.0936;
    }
}
