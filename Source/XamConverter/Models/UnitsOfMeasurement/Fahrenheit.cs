namespace XamConverter
{
	public class Fahrenheit : UnitOfMeasurementModel
	{
        static Fahrenheit _instance;

		Fahrenheit() : base(UnitOfMeasurement.Temperature)
		{
		}

        public static Fahrenheit Instance => _instance ?? (_instance = new Fahrenheit());

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
