using System;

namespace XamConverter
{
    public class Miles : UnitOfMeasurementModel
    {
        static readonly Lazy<Miles> _instanceHolder = 
            new Lazy<Miles>(() => new Miles());

        Miles() : base(UnitOfMeasurement.Length)
        {
        }

        public static Miles Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double valueInCentimeters)
        {
            return valueInCentimeters / 160934;
        }

        public override double ConvertToBaseUnits(double valueInMilies)
        {
            return valueInMilies * 160934;
        }
    }
}
