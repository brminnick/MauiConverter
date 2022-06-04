using XamConverter.Models.Base;

namespace XamConverter
{
    abstract class UnitOfMeasurementModel : ISingleton<UnitOfMeasurementModel>
    {        
        protected UnitOfMeasurementModel(UnitOfMeasurement measurementType) =>
            MeasurementType = measurementType;

        public static UnitOfMeasurementModel Instance { get; }

        public UnitOfMeasurement MeasurementType { get; }

        public abstract double ConvertToBaseUnits(double unit);

        public abstract double ConvertFromBaseUnits(double baseUnit);
    }

    enum UnitOfMeasurement { Length, Mass, Temperature };
}
