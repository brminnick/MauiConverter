namespace XamConverter
{
	public class Fahrenheit : UnitOfMeasurementSingleton<Fahrenheit>
	{
		public Fahrenheit() : base(UnitOfMeasurement.Temperature)
		{
		}

		public override double ConvertFromBaseUnits(double unitsInCelsius)
		{
			return unitsInCelsius * 9 / 5 + 32;
		}

		public override double ConvertToBaseUnits(double unitsInFahrenheit)
		{
			return (unitsInFahrenheit - 32) * 5 / 9;
		}
	}
}
