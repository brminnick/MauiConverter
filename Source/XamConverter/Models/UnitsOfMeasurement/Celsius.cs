namespace XamConverter
{
	public class Celsius : UnitOfMeasurementSingleton<Celsius>
	{
		public Celsius() : base(UnitOfMeasurement.Temperature)
		{
		}

		public override double ConvertFromBaseUnits(double unitsInCelsius)
		{
			return unitsInCelsius;
		}

		public override double ConvertToBaseUnits(double unitsInCelsius)
		{
			return unitsInCelsius;
		}
	}
}
