using System;
namespace XamConverter
{
    class Kelvin : UnitOfMeasurementModel
    {
        Kelvin() : base(UnitOfMeasurement.Temperature)
        {
        }

        public override double ConvertFromBaseUnits(double unitsInKelvin) => unitsInKelvin;

        public override double ConvertToBaseUnits(double unitsInKelvin) => unitsInKelvin;
    }
}
