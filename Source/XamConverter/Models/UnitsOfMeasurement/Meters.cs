namespace XamConverter
{
	public class Meters : UnitOfMeasurementModel
	{
        static Meters _instance;

		Meters() : base(UnitOfMeasurement.Length)
		{
		}

        public static Meters Instance => _instance ?? (_instance = new Meters());

		public override double ConvertFromBaseUnits(double valueInMeters)
		{
			return valueInMeters / 100;
		}

		public override double ConvertToBaseUnits(double valueInBaseUnit)
		{
			return valueInBaseUnit * 100;
		}
	}
}
