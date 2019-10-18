using System;

namespace XamConverter
{
    class Pounds : UnitOfMeasurementModel
    {
        static readonly Lazy<Pounds> _instanceHolder = new Lazy<Pounds>(() => new Pounds());

        Pounds() : base(UnitOfMeasurement.Mass)
        {
        }

        public static Pounds Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInGrams) => unitsInGrams / 453.59237;

        public override double ConvertToBaseUnits(double unitsInPounds) => unitsInPounds * 453.59237;
    }
}
