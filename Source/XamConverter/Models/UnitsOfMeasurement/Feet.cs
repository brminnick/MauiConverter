using System;
using Xamarin.Essentials;

namespace XamConverter
{
    class Feet : UnitOfMeasurementModel
    {
        readonly static Lazy<Feet> _instanceHolder = new Lazy<Feet>(() => new Feet());

        Feet() : base(UnitOfMeasurement.Length)
        {
        }

        public static Feet Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInMeters) => UnitConverters.MetersToInternationalFeet(valueInMeters);

        public override double ConvertToBaseUnits(double valueInFeet) => UnitConverters.InternationalFeetToMeters(valueInFeet);
    }
}
