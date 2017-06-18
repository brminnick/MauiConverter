using System;

namespace XamConverter
{
    public class Pounds : UnitOfMeasurementModel
    {
        static readonly Lazy<Pounds> _instanceHolder = 
            new Lazy<Pounds>(() => new Pounds());

        Pounds() : base(UnitOfMeasurement.Mass)
        {
        }

        public static Pounds Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInGrams)
        {
            return unitsInGrams / 450;
        }

        public override double ConvertToBaseUnits(double unitsInPounds)
        {
            return unitsInPounds * 450;
        }
    }
}
