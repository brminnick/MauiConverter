using System;
namespace XamConverter
{
    class Kelvin : UnitOfMeasurementModel
    {
        readonly static Lazy<Kelvin> _instanceHolder = new Lazy<Kelvin>(() => new Kelvin());

        Kelvin() : base(UnitOfMeasurement.Temperature)
        {
        }

        public static Kelvin Instance => _instanceHolder.Value;

        public override double ConvertFromBaseUnits(double unitsInKelvin) => unitsInKelvin;

        public override double ConvertToBaseUnits(double unitsInKelvin) => unitsInKelvin;
    }
}
