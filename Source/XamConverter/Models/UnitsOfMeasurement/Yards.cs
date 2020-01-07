using System;
using Xamarin.Essentials;

namespace XamConverter
{
    class Yards : UnitOfMeasurementModel
    {
        static readonly Lazy<Yards> _instanceHolder = new Lazy<Yards>(() => new Yards());

        Yards() : base(UnitOfMeasurement.Length)
        {
        }

        public static Yards Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitInMeters) => UnitConverters.MetersToInternationalFeet(unitInMeters) / 3;

        public override double ConvertToBaseUnits(double unitInYards) => UnitConverters.InternationalFeetToMeters(unitInYards * 3);
    }
}
