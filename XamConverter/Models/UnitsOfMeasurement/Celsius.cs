namespace XamConverter
{
	public class Celsius : ConverterClassSingleton<Celsius>
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
