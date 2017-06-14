namespace XamConverter
{
	public class Celsius : UnitOfMeasurementModel
	{
        static Celsius _instance;

		Celsius() : base(UnitOfMeasurement.Temperature)
		{
		}

        public static Celsius Instance => _instance ?? (_instance = new Celsius());

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
