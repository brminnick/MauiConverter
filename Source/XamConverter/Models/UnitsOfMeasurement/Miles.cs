using System;
using Xamarin.Essentials;

namespace XamConverter
{
    class Miles : UnitOfMeasurementModel
    {
        static readonly Lazy<Miles> _instanceHolder = new Lazy<Miles>(() => new Miles());

        Miles() : base(UnitOfMeasurement.Length)
        {
        }

        public static Miles Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInMeters) => UnitConverters.KilometersToMiles(valueInMeters / 1000);

        public override double ConvertToBaseUnits(double valueInMilies) => UnitConverters.MilesToKilometers(valueInMilies) * 1000;
    }
}
