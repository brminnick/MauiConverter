namespace ConverterApp
{
	public abstract class UnitOfMeasurementModel
	{
		protected UnitOfMeasurementModel(UnitOfMeasurement measurementType)
		{
			MeasurementType = measurementType;
		}

		public UnitOfMeasurement MeasurementType { get; }

		public abstract double ConvertToBaseUnits(double unit);
		public abstract double ConvertFromBaseUnits(double baseUnit);
	}

	public enum UnitOfMeasurement { Length, Mass, Temperature };
}
